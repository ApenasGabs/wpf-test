using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Teste_Toolkit.Model
{
  public class Contato : ObservableObject, ICloneable
  {
    private string? _nome;
    private string? _sobrenome;
    private string? _telefone;
    private string? _email;
    public string Nome
    {
      get { return _nome; }
      set { SetProperty(ref _nome, value); }
    }
    public string Email
    {
      get { return _email; }
      set { SetProperty(ref _email, value); }
    }
    public string Sobrenome
    {
      get { return _sobrenome; }
      set { SetProperty(ref _sobrenome, value); }
    }
    public string Telefone
    {
      get { return _telefone; }
      set { SetProperty(ref _telefone, value); }
    }
    public object Clone()
    {
      return this.MemberwiseClone();
    }
  }
}


