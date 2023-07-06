using System.Collections.ObjectModel;
using Teste_Toolkit.Model;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Teste_Toolkit.ViewModel
{
  public class ListaContatoViewModel : ObservableObject
  {
    public ObservableCollection<Contato> listaContato { get; set; }

    private Model.Contato _contatoSelecionado;

    public RelayCommand Novox { get; set; }

    public RelayCommand Deletarx { get; set; }

    public RelayCommand Editarx { get; set; }

    public RelayCommand Sairx { get; set; }

    private void NovoCMD()
    {
      var contatoViewModel = new EditaContatoViewModel();

      WeakReferenceMessenger.Default.Send(new OpenWindowMessage(contatoViewModel));
      if (contatoViewModel.contato != null)
      {
        this.listaContato.Add(contatoViewModel.contato);
        this.ContatoSelecionado = contatoViewModel.contato;
      }
    }

    private void DeletarCMD()
    {
      this.listaContato.Remove(this.ContatoSelecionado);
      if (this.listaContato.Count > 0)
        this.ContatoSelecionado = this.listaContato[0];
      else
        this.ContatoSelecionado = null;
    }

    private void EditarCMD()
    {
      var contatoViewModel = new EditaContatoViewModel();
      var cloneContato = (Model.Contato)this.ContatoSelecionado.Clone();

      contatoViewModel.contato = cloneContato;

      WeakReferenceMessenger.Default.Send(new OpenWindowMessage(contatoViewModel));

      if (contatoViewModel.contato != null)
      {
        this.ContatoSelecionado.Nome = cloneContato.Nome;
        this.ContatoSelecionado.Sobrenome = cloneContato.Sobrenome;
        this.ContatoSelecionado.Telefone = cloneContato.Telefone;
        this.ContatoSelecionado.Email = cloneContato.Email;
      }
    }

    private void SairCMD()
    {
      System.Windows.Application.Current.Shutdown();
    }

    private bool CanDeletarCMD()
    {
      return this.ContatoSelecionado != null;
    }

    private bool CanEditarCMD()
    {
      return this.ContatoSelecionado != null;
    }

    public Contato? ContatoSelecionado
    {
      get { return _contatoSelecionado; }
      set
      {
        SetProperty(ref _contatoSelecionado, value);
        Deletarx.NotifyCanExecuteChanged();
        Editarx.NotifyCanExecuteChanged();
      }
    }


    public ListaContatoViewModel()
    {
      Novox = new RelayCommand(NovoCMD);
      Deletarx = new RelayCommand(DeletarCMD, CanDeletarCMD);
      Editarx = new RelayCommand(EditarCMD, CanEditarCMD);
      Sairx = new RelayCommand(SairCMD);
      listaContato = new ObservableCollection<Contato>();
      PreparaContatoCollection();
    }


    private void PreparaContatoCollection()
    {
      var Contato1 = new Contato
      {
        Nome = "Rodrigo",
        Sobrenome = "Bonacin",
        Email = "rbonacin@unicamp.br",
        Telefone = "019-9999-9999"
      };
      this.listaContato.Add(Contato1);
      var Contato2 = new Contato
      {
        Nome = "José",
        Sobrenome = "Silva",
        Email = "Josesilv@email.com",
        Telefone = "019-9999-9999"
      };
      this.listaContato.Add(Contato2);
      var Contato3 = new Contato
      {
        Nome = "John",
        Sobrenome = "Snow",
        Email = "johnSnow@email.com",
        Telefone = "019-9999-9999"
      };
      this.listaContato.Add(Contato3);
      ContatoSelecionado = this.listaContato[0];
    }
  }

  public class OpenWindowMessage : ValueChangedMessage<EditaContatoViewModel>
  {
    public OpenWindowMessage(EditaContatoViewModel contatoViewModel) : base(contatoViewModel)
    {
    }

  }
}

