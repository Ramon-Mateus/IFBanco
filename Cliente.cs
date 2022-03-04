using System;

class Cliente {
  private string nome;
  private string cpf;
  private string email;

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