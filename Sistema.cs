using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;

class Sistema {
  private static Banco[] bancos = new Banco[5];
  private static List<Cliente> clientes = new List<Cliente>();
  private static List<ContaBancaria> contas = new List<ContaBancaria>();
  private static int qtd;

  public static void ArquivosAbrir() {
    Arquivo<Banco[]> a1 = new Arquivo<Banco[]>();
    bancos = a1.Abrir("./bancos.xml");
    qtd = bancos.Length;

    Arquivo<List<Cliente>> a2 = new Arquivo<List<Cliente>>();
    clientes = a2.Abrir("./clientes.xml");

    Arquivo<List<ContaBancaria>> a3 = new Arquivo<List<ContaBancaria>>();
    contas = a3.Abrir("./contas.xml");
  }

  public static void ArquivosSalvar() {
    Arquivo<Banco[]> a1 = new Arquivo<Banco[]>();
    a1.Salvar("./bancos.xml", BancoListar());

    Arquivo<List<Cliente>> a2 = new Arquivo<List<Cliente>>();
    a2.Salvar("./clientes.xml", clientes);

    Arquivo<List<ContaBancaria>> a3 = new Arquivo<List<ContaBancaria>>();
    a3.Salvar("./contas.xml", contas);
  }

  public static void BancoInserir(Banco obj) {
    if (bancos.Length == qtd) Array.Resize(ref bancos, 2 * bancos.Length);
    bancos[qtd] = obj;
    qtd++;
  }

  public static Banco[] BancoListar() {
    Banco[] aux = new Banco[qtd];
    Array.Copy(bancos, aux, qtd);
    BancoIdComp comp = new BancoIdComp();
    Array.Sort(aux, comp);
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
    clientes.Sort();
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

  public static string ClienteSacar(string numero, double valor) {
    ContaBancaria conta = null;
    foreach(ContaBancaria x in contas) if (x.GetNumero() == numero) conta = x;
    if(conta != null) {
      int i = conta.Sacar(valor);
      if (i == 1) return "----- Operação realizada com sucesso -----";
      else return "----- Saldo insuficiente -----";
    }
    return "----- Conta não encontrada -----";
  }

  public static string ClienteDepositar(string numero, double valor) {
    ContaBancaria conta = null;
    foreach(ContaBancaria x in contas) if (x.GetNumero() == numero) conta = x;
    if(conta != null) {
      int i = conta.Depositar(valor);
      if (i == 1) return "----- Operação realizada com sucesso -----";
      else return "----- Valor inválido para depósito -----";
    }
    return "----- Conta não encontrada -----";
  }

  public static string ClientePixar(string numero, double valor, string numero2) {
    ContaBancaria conta = null;
    ContaBancaria conta2 = null;
    foreach(ContaBancaria x in contas) if (x.GetNumero() == numero) conta = x;
    foreach(ContaBancaria y in contas) if (y.GetNumero() == numero2) conta2 = y;
    if(conta != null && conta2 != null) {
      int i = conta.Sacar(valor);
      if (i == 1) {
        int j = conta2.Depositar(valor);
        if (j == 1) return "----- Operação realizada com sucesso -----";
        else return "----- Valor inválido para Pix -----";
      } else return "----- Valor insuficiente para fazer o Pix -----";
    }
    return "----- Conta não encontrada -----";
  }
  
  public static void ContaInserir(ContaBancaria obj) {
    Boolean t = false;
    foreach(Cliente x in clientes) if (obj.GetCpfCliente() == x.GetCpf()) t = true;
    foreach(Banco y in bancos) if (obj.GetIdBanco() == y.GetId() && t) contas.Add(obj);
  }

  public static List<ContaBancaria> ContaListar() {
    contas.Sort();
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

  public static List<ContaBancaria> ContaListarBanco(int id) {
    List<ContaBancaria> aux = new List<ContaBancaria>();
    foreach(ContaBancaria x in contas) if(x.GetIdBanco() == id) aux.Add(x);
    aux.Sort();
    return aux;
  }

  public static List<ContaBancaria> ContaListarCliente(string cpf) {
    List<ContaBancaria> aux = new List<ContaBancaria>();
    foreach(ContaBancaria x in contas) if(x.GetCpfCliente() == cpf) aux.Add(x);
    aux.Sort();
    return aux;
  }
}

class Arquivo<T> {
  public T Abrir(string arquivo) {
    XmlSerializer xml = new XmlSerializer(typeof(T));
    StreamReader f = new StreamReader(arquivo, Encoding.Default);
    T obj = (T) xml.Deserialize(f);
    f.Close();
    return obj;
  }

  public void Salvar(string arquivo, T obj) {
    XmlSerializer xml = new XmlSerializer(typeof(T));
    StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
    xml.Serialize(f, obj);
    f.Close();
  }
}