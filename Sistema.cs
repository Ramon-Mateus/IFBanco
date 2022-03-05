using System;
using System.Collections.Generic;

class Sistema {
  private static Banco[] bancos = new Banco[5];
  private static List<Cliente> clientes = new List<Cliente>();
  private static List<ContaBancaria> contas = new List<ContaBancaria>();
  private static int qtd;

  public static void BancoInserir(Banco obj) {
    if (bancos.Length == qtd) Array.Resize(ref bancos, 2 * bancos.Length);
    bancos[qtd] = obj;
    qtd++;
  }

  public static Banco[] BancoListar() {
    Banco[] aux = new Banco[qtd];
    Array.Copy(bancos, aux, qtd);
    return aux;
  }

  public static Banco BancoListar(int id) {
    foreach(Banco x in bancos) if (x != null && x.GetId() == id) return x;
    return null;
  }

  public static void BancoAtualizar(Banco obj) {
    Banco aux = BancoListar(obj.GetId());
    if (aux != null) aux.SetNome(obj.GetNome());
  }

  public static void BancoExcluir(Banco obj) {
    int aux = BancoIndice(obj.GetId());
    if (aux != -1) {
      for (int i = aux; i < qtd - 1; i++)
        bancos[i] = bancos[i + 1];
      qtd--;  
    }
  }

  private static int BancoIndice(int id) {    
    for(int i = 0; i < qtd; i++) {
      if (bancos[i].GetId() == id) return i;
    }
    return -1;
  }

  public static void ClienteInserir(Cliente obj) {
    clientes.Add(obj);
  }

  public static List<Cliente> ClienteListar() {
    return clientes;
  }

  public static Cliente ClienteListar(string cpf) {
    foreach(Cliente x in clientes) if (x.GetCpf() == cpf) return x;
    return null;
  }

  public static void ClienteAtualizar(Cliente obj) {
    Cliente aux= ClienteListar(obj.GetCpf());
    if (aux != null) {
      aux.SetNome(obj.GetNome());
      aux.SetEmail(obj.GetEmail());
    }
  }

  public static void ClienteExcluir(Cliente obj) {
    Cliente aux = ClienteListar(obj.GetCpf());
    if (aux != null) clientes.Remove(aux);
  }
  
  public static void ContaInserir(ContaBancaria obj) {
    contas.Add(obj);
  }

  public static List<ContaBancaria> ContaListar() {
    return contas;
  }

  public static ContaBancaria ContaListar(int id, string cpf) {
    foreach(ContaBancaria x in contas) if (x.GetCpfCliente() == cpf && x.GetIdBanco() == id) return x;
    return null;
  }

  public static void ContaAtualizar(ContaBancaria obj) {
    ContaBancaria aux = ContaListar(obj.GetIdBanco(), obj.GetCpfCliente());
    if (aux != null) {
      aux.SetNumero(obj.GetNumero());
      aux.SetAgencia(obj.GetAgencia());
      aux.SetSaldo(obj.GetSaldo());
    }
  }

  public static void ContaExcluir(ContaBancaria obj) {
    ContaBancaria aux = ContaListar(obj.GetIdBanco(), obj.GetCpfCliente());
    if (aux != null) contas.Remove(aux);
  }
}