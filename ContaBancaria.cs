using System;

class ContaBancaria {
  private string numero;
  private string agencia;
  private double saldo;
  private int idBanco;
  private string cpfCliente;

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

  public override string ToString() {
    return $"Numero: {numero} - Agencia: {agencia} - Saldo: R$ {saldo:0.00} - Id do Banco: {idBanco} - CPF do Cliente: {cpfCliente}";
  }
}