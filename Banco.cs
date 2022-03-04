using System;

class Banco {
  private int id;
  private string nome;

  public Banco(int id, string nome) {
    this.id = id;
    this.nome = nome;
  }

  public int GetId() {
    return id;
  }

  public void SetId(int id) {
    this.id = id;
  }

  public string GetNome() {
    return nome;
  }

  public void SetNome(string nome) {
    this.nome = nome;
  }

  public override string ToString() {
    return $"Id: {id} - Nome: {nome}";
  }
}