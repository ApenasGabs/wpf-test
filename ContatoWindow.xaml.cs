
using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using Teste_Toolkit.ViewModel;

namespace Teste_Toolkit
{
  // C#
  public partial class ContatoWindow : Window
  {
    public ContatoWindow()
    {

      InitializeComponent();

      WeakReferenceMessenger.Default.Register<CloseWindowMessage>(this, (r, m) =>
      {
        this.Hide();
      });

      DataContext = new EditaContatoViewModel();
    }
  }
}

