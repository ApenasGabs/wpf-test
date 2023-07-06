using CommunityToolkit.Mvvm.ComponentModel;
using Teste_Toolkit.Model;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Teste_Toolkit.ViewModel
{
  public class EditaContatoViewModel : ObservableObject
  {
    public Contato? contato { get; set; }
    // Objeto que lida com o comando OK
    public RelayCommand OK { get; set; }
    // Objeto que lida com o comando Cancelar
    public RelayCommand Cancelar { get; set; }

    // Executa comando de OK
    private void OkCMD()
    {
      bool comando = true;
      WeakReferenceMessenger.Default.Send(new CloseWindowMessage(comando));
    }
    // Executa comando de Cancelar
    private void CancelarCMD()
    {
      bool comando = false;
      WeakReferenceMessenger.Default.Send(new CloseWindowMessage(comando));

      // Anula alteração
      contato = null;
    }

    // Construtor
    public EditaContatoViewModel()
    {
      OK = new RelayCommand(OkCMD);
      Cancelar = new RelayCommand(CancelarCMD);
      contato = new Contato();
    }
  }

  // Cria uma casse de messagem OpenWindowMessage
  public class CloseWindowMessage : ValueChangedMessage<bool>
  {
    public CloseWindowMessage(bool value) : base(value)
    {
    }

  }
}