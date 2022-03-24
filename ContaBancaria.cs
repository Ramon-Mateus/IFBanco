using System;
using System.Collections;

public class ContaBancaria : IComparable {
  private string numero;
  private string agencia;
  private double saldo;
  private int idBanco;
  private string cpfCliente;

  public string Numero {
    get => numero; 
    set => numero = value; 
  }
  public string Agencia { 
    get => agencia; 
    set => agencia = value; 
  }
  public double Saldo { 
    get => saldo; 
    set => saldo = value; 
  }
  public int IdBanco { 
    get => idBanco;
    set => idBanco = value; 
  }
  public string CpfCliente { 
    get => cpfCliente;
    set => cpfCliente = value; 
  }

  public ContaBancaria() { }

  public ContaBancaria(int idBanco, string cpfCliente) {
    this.idBanco = idBanco;
    this.cpfCliente = cpfCliente;
  }

  public ContaBancaria(string numero, string agencia, double saldo, int idBanco, string cpfCliente) {
    this.numero = numero;
    this.agencia = agencia;
    this.saldo = saldo;
    this.idBanco = idBanco;
    this.cpfCliente = cpfCliente;
  }

  public int CompareTo(object obj) {
    ContaBancaria x = (ContaBancaria) obj;
    return x.saldo.CompareTo(this.saldo);
  }

  public string GetNumero() {
    return numero;
  }

  public void SetNumero(string numero) {
    this.numero = numero;
  }

  public string GetAgencia() {
    return agencia;
  }

  public void SetAgencia(string agencia) {
    this.agencia = agencia;
  }

  public double GetSaldo() {
    return saldo;
  }

  public void SetSaldo(double saldo) {
    this.saldo = saldo;
  }

  public int GetIdBanco() {
    return idBanco;
  }

  public void SetIdBanco(int idBanco) {
    this.idBanco = idBanco;
  }

  public string GetCpfCliente() {
    return cpfCliente;
  }

  public void SetCpfCliente(string cpfCliente) {
    this.cpfCliente = cpfCliente;
  }

  public int Sacar(double valor) {
    if(saldo > 0 && saldo >= valor) {
      saldo -= valor;
      return 1;
    } else {
      return -1;
    }
  }

  public int Depositar(double valor) {
    if(valor > 0) {
      saldo += valor;
        return 1;
    } else {
      return -1;
    }
  }

  public override string ToString() {
    return $"Numero: {numero} - Agencia: {agencia} - Saldo: R$ {saldo:0.00} - Banco: {Sistema.BancoListar(idBanco).GetNome()} - Cliente: {Sistema.ClienteListar(cpfCliente).GetNome()} - CPF do Cliente: {cpfCliente}";
  }
}