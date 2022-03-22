using System;
using System.Collections;

public class Cliente : IComparable {
  private string nome;
  private string cpf;
  private string email;

  public string Nome { 
    get => nome; 
    set => nome = value; 
  }
  public string Cpf { 
    get => cpf; 
    set => cpf = value; 
  }
  public string Email { 
    get => email; 
    set => email = value; 
  }

  public Cliente() { }

  public Cliente(string cpf) {
    this.cpf = cpf;
  }

  public Cliente(string nome, string cpf, string email) {
    this.nome = nome;
    this.cpf = cpf;
    this.email = email;
  }

  public int CompareTo(object obj) {
    Cliente x = (Cliente) obj;
    return this.nome.CompareTo(x.nome);
  }

  public string GetNome() {
    return nome;
  }

  public void SetNome(string nome) {
    this.nome = nome;
  }

  public string GetCpf() {
    return cpf;
  }

  public void SetCpf(string cpf) {
    this.cpf = cpf;
  }

  public string GetEmail() {
    return email;
  }

  public void SetEmail(string email) {
    this.email = email;
  }

  public override string ToString() {
    return $"Nome: {nome} - CPF: {cpf} - Email: {email}";
  }
}

class ClienteNomeComp : IComparer {
  public int Compare(object x, object y) {
    Cliente a = (Cliente) x;
    Cliente b = (Cliente) y;
    return a.GetNome().CompareTo(b.GetNome());
  }
}