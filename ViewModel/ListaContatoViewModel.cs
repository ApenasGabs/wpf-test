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
    // Coleção de Objetos
    public ObservableCollection<Contato> listaContato { get; set; }

    // Contato selecionado
    private Model.Contato _contatoSelecionado;

    // Objeto que lida com o comando novo
    public RelayCommand Novox { get; set; }

    // Objeto que lida com o comando deletar
    public RelayCommand Deletarx { get; set; }

    // Objeto que lida com o comando editar
    public RelayCommand Editarx { get; set; }

    // Objeto que lida com o comando sair
    public RelayCommand Sairx { get; set; }

    // Executa comando de novo contato
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

    // Executa comando deletar
    private void DeletarCMD()
    {
      this.listaContato.Remove(this.ContatoSelecionado);
      if (this.listaContato.Count > 0)
        this.ContatoSelecionado = this.listaContato[0];
      else
        this.ContatoSelecionado = null;
    }

    // Executa comando editar
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

    // Executa comando sair
    private void SairCMD()
    {
      System.Windows.Application.Current.Shutdown();
    }

    //Executa can deletar
    private bool CanDeletarCMD()
    {
      return this.ContatoSelecionado != null;
    }

    //Executa can deletar
    private bool CanEditarCMD()
    {
      return this.ContatoSelecionado != null;
    }

    // Quando o selecionado muda notificar CanExecute dos botões Editar e Deletar
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


    // Construtor
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

  // Cria uma casse de messagem OpenWindowMessage
  public class OpenWindowMessage : ValueChangedMessage<EditaContatoViewModel>
  {
    public OpenWindowMessage(EditaContatoViewModel contatoViewModel) : base(contatoViewModel)
    {
    }

  }
}

