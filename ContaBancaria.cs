using System;

class ContaBancaria {
  private string numero;
  private string agencia;
  private double saldo;

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

  public override string ToString() {
    return $"Numero: {numero} - Agencia: {agencia} - Saldo: {saldo}";
  }
}