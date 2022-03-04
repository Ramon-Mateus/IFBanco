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
}