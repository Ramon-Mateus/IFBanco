using System;

class Program {
  public static void Main (string[] args) {
    Console.WriteLine("Bem vindo ao IFBanco!");
    Console.WriteLine();
    int n = -1;
    do {
      try {
        n = Menu();
        switch(n) {
          case 1: BancoInserir(); break;
          case 2: BancoListar(); break;
          case 3: BancoAtualizar(); break;
          case 4: BancoExcluir(); break;
          case 5: ClienteInserir(); break;
          case 6: ClienteListar(); break;
          case 7: ClienteAtualizar(); break;
          case 8: ClienteExcluir(); break;
          case 9: ContaInserir(); break;
          case 10: ContaListar(); break;
          case 11: ContaAtualizar(); break;
          case 12: ContaExcluir(); break;
          case 13: ContaListarBanco(); break;
          case 14: ContaListarCliente(); break;
        }
      } catch (Exception e) {
        Console.WriteLine($"Ocorreu um erro: {e.Message}");
      } 
    } while(n != 0);
  }

  public static int Menu() {
    Console.WriteLine("----- Escolha uma das opções abaixo -----");
    Console.WriteLine("01 - Inserir um novo banco");
    Console.WriteLine("02 - Listar os bancos cadastrados");
    Console.WriteLine("03 - Atualizar um banco");
    Console.WriteLine("04 - Excluir um banco");
    Console.WriteLine("05 - Inserir um novo cliente");
    Console.WriteLine("06 - Listar os clientes cadastrados");
    Console.WriteLine("07 - Atualizar um cliente");
    Console.WriteLine("08 - Excluir um cliente");
    Console.WriteLine("09 - Inserir uma nova conta");
    Console.WriteLine("10 - Listar as contas cadastradas");
    Console.WriteLine("11 - Atualizar uma conta");
    Console.WriteLine("12 - Excluir uma conta");
    Console.WriteLine("13 - Listar as contas cadastradas por banco");
    Console.WriteLine("14 - Listar as contas cadastradas por cliente");
    Console.WriteLine("00 - Finalizar o programa");
    Console.WriteLine("-----------------------------------------");
    Console.Write("Digite sua opção: ");
    int n = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return n;
  }

  public static void BancoInserir() {
    Console.WriteLine("----- Cadastrar novo banco -----");
    Console.Write("Informe o id: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Banco obj = new Banco(id, nome);
    Sistema.BancoInserir(obj);
    Console.WriteLine("------ Operação concluída ------");
    Console.WriteLine();
  }

  public static void BancoListar() {
    Console.WriteLine("----- Bancos cadastrados -----");
    foreach(Banco x in Sistema.BancoListar()) Console.WriteLine(x);
    Console.WriteLine("------------------------------");
    Console.WriteLine();
  }

  public static void BancoAtualizar() {
    Console.WriteLine("----- Atualizar banco -----");
    Console.Write("Informe o id do banco a ser atualizado: ");
    int id =  int.Parse(Console.ReadLine());
    Console.Write("Informe o novo nome: ");
    string nome = Console.ReadLine();
    Banco x = new Banco(id, nome);
    Sistema.BancoAtualizar(x);
    Console.WriteLine("--- Operação Concluída ---");
    Console.WriteLine();
  }

  public static void BancoExcluir() {
    Console.WriteLine("----- Excluir banco -----");
    Console.Write("Informe o id do banco a ser excluído: ");
    int id =  int.Parse(Console.ReadLine());
    Banco x = new Banco(id, "");
    Sistema.BancoExcluir(x);
    Console.WriteLine("--- Operação Concluída ---");
    Console.WriteLine();
  }

  public static void ClienteInserir() {
    Console.WriteLine("----- Cadastrar novo cliente -----");
    Console.Write("Informe o Nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o CPF: ");
    string cpf = Console.ReadLine();
    Console.Write("Informe o Email: ");
    string email = Console.ReadLine();
    Cliente obj = new Cliente(nome, cpf, email);
    Sistema.ClienteInserir(obj);
    Console.WriteLine("------ Operação concluída ------");
    Console.WriteLine();
  }

  public static void ClienteListar() {
    Console.WriteLine("----- Clientes cadastrados -----");
    foreach(Cliente x in Sistema.ClienteListar()) Console.WriteLine(x);
    Console.WriteLine("------------------------------");
    Console.WriteLine();
  }

  public static void ClienteAtualizar() {
    Console.WriteLine("----- Atualizar Cliente -----");
    Console.Write("Informe o CPF do cliente a ser atualizado: ");
    string cpf =  Console.ReadLine();
    Console.Write("Informe o novo nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o novo email: ");
    string email = Console.ReadLine();
    Cliente x = new Cliente(nome, cpf, email);
    Sistema.ClienteAtualizar(x);
    Console.WriteLine("---- Operação Concluída ----");
    Console.WriteLine();
  }

  public static void ClienteExcluir() {
    Console.WriteLine("----- Excluir cliente -----");
    Console.Write("Informe o cpf do cliente a ser excluído: ");
    string cpf =  Console.ReadLine();
    Cliente x = new Cliente(cpf);
    Sistema.ClienteExcluir(x);
    Console.WriteLine("--- Operação Concluída ---");
    Console.WriteLine();
  }

  public static void ContaInserir() {
    Console.WriteLine("----- Cadastrar nova conta -----");
    Console.Write("Informe o numero da conta: ");
    string numero = Console.ReadLine();
    Console.WriteLine();
    BancoListar();
    Console.Write("Informe o id do Banco: ");
    int idBanco =  int.Parse(Console.ReadLine());
    Console.Write("Informe a agência: ");
    string agencia = Console.ReadLine();
    Console.WriteLine();
    ClienteListar();
    Console.Write("Informe o CPF do cliente: ");
    string cpf = Console.ReadLine();
    Console.Write("Informe o saldo: ");
    double saldo = double.Parse(Console.ReadLine());
    ContaBancaria obj = new ContaBancaria(numero, agencia, saldo, idBanco, cpf);
    Sistema.ContaInserir(obj);
    Console.WriteLine("------ Operação concluída ------");
    Console.WriteLine();
  }
  
  
  public static void ContaListar() {
    Console.WriteLine("----- Contas cadastradas -----");
    foreach(ContaBancaria x in Sistema.ContaListar()) Console.WriteLine(x);
    Console.WriteLine("------------------------------");
    Console.WriteLine();
  }
  
  
  public static void ContaAtualizar() {
    Console.WriteLine("----- Atualizar Conta -----");
    Console.WriteLine();
    ContaListar();
    Console.Write("Informe o CPF do cliente presente na conta: ");
    string cpf =  Console.ReadLine();
    Console.Write("Informe o id do banco em que a conta está cadastrada: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o novo numero: ");
    string numero = Console.ReadLine();
    Console.Write("Informe a nova agência: ");
    string agencia = Console.ReadLine();
    Console.Write("Informe o novo saldo: ");
    double saldo = double.Parse(Console.ReadLine());
    ContaBancaria x = new ContaBancaria(numero, agencia, saldo, id, cpf);
    Sistema.ContaAtualizar(x);
    Console.WriteLine("---- Operação Concluída ----");
    Console.WriteLine();
  }
  
  public static void ContaExcluir() {
    Console.WriteLine("----- Excluir conta -----");
    Console.WriteLine();
    ContaListar();
    Console.Write("Informe o cpf do cliente presente na conta a ser excluída: ");
    string cpf =  Console.ReadLine();
    Console.Write("Informe o id do banco presente na conta a ser excluída: ");
    int id = int.Parse(Console.ReadLine());
    ContaBancaria x = new ContaBancaria(id, cpf);
    Sistema.ContaExcluir(x);
    Console.WriteLine("--- Operação Concluída ---");
    Console.WriteLine();
  }

  public static void ContaListarBanco() {
    Console.WriteLine("----- Listar contas cadastradas por banco -----");
    Console.WriteLine();
    BancoListar();
    Console.Write("Informe o id do banco: ");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine();
    Console.WriteLine($"----- Contas cadastradas no banco {id} -----");
    foreach(ContaBancaria x in Sistema.ContaListarBanco(id)) Console.WriteLine(x);
    Console.WriteLine("---------------------------------------------");
    Console.WriteLine();
  }

  public static void ContaListarCliente() {
    Console.WriteLine("----- Listar contas cadastradas por cliente -----");
    Console.WriteLine();
    ClienteListar();
    Console.Write("Informe o CPF do cliente: ");
    string cpf = Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine($"----- Contas cadastradas no cliente com o cpf {cpf} -----");
    foreach(ContaBancaria x in Sistema.ContaListarCliente(cpf)) Console.WriteLine(x);
    Console.WriteLine("---------------------------------------------");
    Console.WriteLine();
  }
}