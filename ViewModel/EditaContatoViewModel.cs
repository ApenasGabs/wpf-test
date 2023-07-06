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
    public RelayCommand OK { get; set; }
    public RelayCommand Cancelar { get; set; }

    private void OkCMD()
    {
      bool comando = true;
      WeakReferenceMessenger.Default.Send(new CloseWindowMessage(comando));
    }
    private void CancelarCMD()
    {
      bool comando = false;
      WeakReferenceMessenger.Default.Send(new CloseWindowMessage(comando));

      contato = null;
    }

    public EditaContatoViewModel()
    {
      OK = new RelayCommand(OkCMD);
      Cancelar = new RelayCommand(CancelarCMD);
      contato = new Contato();
    }
  }

  public class CloseWindowMessage : ValueChangedMessage<bool>
  {
    public CloseWindowMessage(bool value) : base(value)
    {
    }

  }
}