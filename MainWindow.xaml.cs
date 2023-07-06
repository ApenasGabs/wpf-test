using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using Teste_Toolkit.ViewModel;

namespace Teste_Toolkit
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      WeakReferenceMessenger.Default.Register<OpenWindowMessage>(this, (r, m) =>
      {
        var fw = new Teste_Toolkit.ContatoWindow();

        fw.DataContext = m.Value;

        fw.ShowDialog();
      });

      DataContext = new ViewModel.ListaContatoViewModel();
    }
  }
}

