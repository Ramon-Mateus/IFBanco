using System;
using System.Collections;

public class Banco : IComparable {
  private int id;
  private string nome;

  public int Id { 
    get => id; 
    set => id = value; 
  }
  public string Nome { 
    get => nome; 
    set => nome = value; 
  }

  public Banco() { }

  public Banco(int id, string nome) {
    this.id = id;
    this.nome = nome;
  }

  public int CompareTo(object obj) {
    Banco x = (Banco) obj;
    return this.id.CompareTo(x.id);
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

class BancoIdComp : IComparer {
  public int Compare(object x, object y) {
    Banco a = (Banco) x;
    Banco b = (Banco) y;
    return a.GetId().CompareTo(b.GetId());
  }
}