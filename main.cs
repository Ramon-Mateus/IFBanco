using System;

class Program {

  private static Cliente clienteLogin = null;
  
  public static void Main (string[] args) {

    try {
      Sistema.ArquivosAbrir();
    }
    catch (Exception erro) {
      Console.WriteLine(erro.Message);
    }
    
    Console.WriteLine("Bem vindo ao IFBanco!");
    int n = 0;
    int perfil = 0;
    do {
      try {
        if (perfil == 0) {
          n = 0;
          perfil = MenuUsuario();
        }
        if (perfil == 1) {
          n = MenuAdmin();
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
            case 99: perfil = 0; break;
          }
        }
        if (perfil == 2 && clienteLogin == null) {
          n = MenuClienteLogin();
          switch(n) {
            case 1 : ClienteLogin(); break;
            case 99: perfil = 0; break;
          }
        }
        if (perfil == 2 && clienteLogin != null) {
          n = MenuClienteLogout();
          switch(n) {
            case 1 : ClienteSacar(); break;
            case 2 : ClienteDepositar(); break;
            case 3 : ClientePixar(); break;
            case 4 : ClienteListarContas(); break;
            case 5 : ClienteContaInformacoes(); break;
            case 99: ClienteLogout(); break;
          }
        }
      } catch (Exception e) {
        Console.WriteLine($"Ocorreu um erro: {e.Message}");
        Console.WriteLine();
      } 
    } while(n != 0);

    try {
      Sistema.ArquivosSalvar();
    }
    catch (Exception erro) {
      Console.WriteLine(erro.Message);
    }
    
  }

  public static void ClienteLogin() {
    Console.WriteLine("----- Login do Cliente -----");
    ClienteListar();
    Console.Write("Informe o cpf do cliente para logar: ");
    string cpf = Console.ReadLine();
    clienteLogin = Sistema.ClienteListar(cpf);
  }
  
  public static void ClienteLogout() { 
    Console.WriteLine("----- Logout do Cliente -----");
    clienteLogin = null;
  }
  
  public static int MenuUsuario() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("1 - Entrar como Administrador");
    Console.WriteLine("2 - Entrar como Cliente");
    Console.WriteLine("0 - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma op????o: ");
    int n = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return n; 
  }
  
  public static int MenuAdmin() {
    Console.WriteLine("----- Escolha uma das op????es abaixo -----");
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
    Console.WriteLine("99 - Voltar ao menu anterior");
    Console.WriteLine("00 - Finalizar o programa");
    Console.WriteLine("-----------------------------------------");
    Console.Write("Digite sua op????o: ");
    int n = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return n;
  }

  public static int MenuClienteLogin() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("01 - Login");
    Console.WriteLine("99 - Voltar");
    Console.WriteLine("00 - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma op????o: ");
    int n = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return n; 
  }

  public static int MenuClienteLogout() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("Bem vindo(a), " + clienteLogin.GetNome());
    Console.WriteLine("----------------------------------");
    Console.WriteLine("01 - Saque");
    Console.WriteLine("02 - Dep??sito");
    Console.WriteLine("03 - Pix");
    Console.WriteLine("04 - Listar minhas contas");
    Console.WriteLine("05 - Informa????es de uma conta");
    Console.WriteLine("99 - Logout");
    Console.WriteLine("0  - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma op????o: ");
    int n = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return n; 
  }

  public static void ClienteSacar() {
    Console.WriteLine("----- Saque -----");
    int u = 1;
    Console.WriteLine($"----- Contas cadastradas no seu nome -----");
    foreach(ContaBancaria x in Sistema.ContaListarCliente(clienteLogin.GetCpf())) {
      Console.WriteLine($"{u} {x}");
      u++;
    }
    Console.WriteLine("------------------------------------------------------------------");
    Console.WriteLine();
    Console.Write("Informe o n??mero da conta que voc?? quer sacar: ");
    string numero = Console.ReadLine();
    Console.Write("Informe o valor que deseja sacar: ");
    double valor = double.Parse(Console.ReadLine());
    Console.WriteLine(Sistema.ClienteSacar(numero, valor));
  }

  public static void ClienteDepositar() {
    Console.WriteLine("----- Dep??sito -----");
    Console.WriteLine($"----- Contas cadastradas no seu nome -----");
    foreach(ContaBancaria x in Sistema.ContaListarCliente(clienteLogin.GetCpf())) Console.WriteLine(x);
    Console.WriteLine("------------------------------------------------------------------");
    Console.WriteLine();
    Console.Write("Informe o n??mero da conta que voc?? quer depositar: ");
    string numero = Console.ReadLine();
    Console.Write("Informe o valor que deseja depositar: ");
    double valor = double.Parse(Console.ReadLine());
    Console.WriteLine(Sistema.ClienteDepositar(numero, valor));
  }

  public static void ClientePixar() {
    Console.WriteLine("----- Pix -----");
    Console.WriteLine($"----- Contas cadastradas no seu nome -----");
    foreach(ContaBancaria x in Sistema.ContaListarCliente(clienteLogin.GetCpf())) Console.WriteLine(x);
    Console.WriteLine("------------------------------------------------------------------");
    Console.WriteLine();
    Console.Write("Informe o n??mero da conta que voc?? quer realizar o Pix: ");
    string numero = Console.ReadLine();
    Console.WriteLine($"----- Contas de terceiros -----");
    foreach(ContaBancaria x in Sistema.ContaListar()) if(x.GetCpfCliente() != clienteLogin.GetCpf()) Console.WriteLine(x);
    Console.WriteLine("------------------------------------------------------------------");
    Console.WriteLine();
    Console.Write("Informe o n??mero da conta que voc?? quer enviar o Pix: ");
    string numero2 = Console.ReadLine();
    Console.Write("Informe o valor que deseja enviar como Pix: ");
    double valor = double.Parse(Console.ReadLine());
    Console.WriteLine(Sistema.ClientePixar(numero, valor, numero2));
  }

  public static void ClienteListarContas() {
    Console.WriteLine("----- Suas Contas -----");
    int u = 1;
    foreach(ContaBancaria x in Sistema.ContaListarCliente(clienteLogin.GetCpf())) {
      Console.WriteLine($"{u} N??mero: {x.GetNumero()} - Banco: {Sistema.BancoListar(x.GetIdBanco()).GetNome()}");
    u++;
    }
    Console.WriteLine("------------------------------");
    Console.WriteLine();
  }

  public static void ClienteContaInformacoes() {
    Console.WriteLine("----- Informa????es da conta -----");
    Console.WriteLine($"----- Bancos cadastrados -----");
    Console.WriteLine();
    BancoListar();
    Console.Write("Informe o ID do banco que a conta est?? cadastrada: ");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("------------- Conta ------------");
    Console.WriteLine(Sistema.ContaListar(id, clienteLogin.GetCpf()));
    Console.WriteLine("--------------------------------");
    Console.WriteLine();
  }

  public static void BancoInserir() {
    Console.WriteLine("----- Cadastrar novo banco -----");
    Console.Write("Informe o id: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Banco obj = new Banco(id, nome);
    Sistema.BancoInserir(obj);
    Console.WriteLine("------ Opera????o conclu??da ------");
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
    Console.WriteLine("--- Opera????o Conclu??da ---");
    Console.WriteLine();
  }

  public static void BancoExcluir() {
    Console.WriteLine("----- Excluir banco -----");
    Console.Write("Informe o id do banco a ser exclu??do: ");
    int id =  int.Parse(Console.ReadLine());
    Banco x = new Banco(id, "");
    Sistema.BancoExcluir(x);
    Console.WriteLine("--- Opera????o Conclu??da ---");
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
    Console.WriteLine("------ Opera????o conclu??da ------");
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
    Console.WriteLine();
    ClienteListar();
    Console.Write("Informe o CPF do cliente a ser atualizado: ");
    string cpf =  Console.ReadLine();
    Console.Write("Informe o novo nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o novo email: ");
    string email = Console.ReadLine();
    Cliente x = new Cliente(nome, cpf, email);
    Sistema.ClienteAtualizar(x);
    Console.WriteLine("---- Opera????o Conclu??da ----");
    Console.WriteLine();
  }

  public static void ClienteExcluir() {
    Console.WriteLine("----- Excluir cliente -----");
    Console.Write("Informe o cpf do cliente a ser exclu??do: ");
    string cpf =  Console.ReadLine();
    Cliente x = new Cliente(cpf);
    Sistema.ClienteExcluir(x);
    Console.WriteLine("--- Opera????o Conclu??da ---");
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
    Console.Write("Informe a ag??ncia: ");
    string agencia = Console.ReadLine();
    Console.WriteLine();
    ClienteListar();
    Console.Write("Informe o CPF do cliente: ");
    string cpf = Console.ReadLine();
    Console.Write("Informe o saldo: ");
    double saldo = double.Parse(Console.ReadLine());
    ContaBancaria obj = new ContaBancaria(numero, agencia, saldo, idBanco, cpf);
    Sistema.ContaInserir(obj);
    Console.WriteLine("------ Opera????o conclu??da ------");
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
    Console.Write("Informe o id do banco em que a conta est?? cadastrada: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o novo numero: ");
    string numero = Console.ReadLine();
    Console.Write("Informe a nova ag??ncia: ");
    string agencia = Console.ReadLine();
    Console.Write("Informe o novo saldo: ");
    double saldo = double.Parse(Console.ReadLine());
    ContaBancaria x = new ContaBancaria(numero, agencia, saldo, id, cpf);
    Sistema.ContaAtualizar(x);
    Console.WriteLine("---- Opera????o Conclu??da ----");
    Console.WriteLine();
  }
  
  public static void ContaExcluir() {
    Console.WriteLine("----- Excluir conta -----");
    Console.WriteLine();
    ContaListar();
    Console.Write("Informe o cpf do cliente presente na conta a ser exclu??da: ");
    string cpf =  Console.ReadLine();
    Console.Write("Informe o id do banco presente na conta a ser exclu??da: ");
    int id = int.Parse(Console.ReadLine());
    ContaBancaria x = new ContaBancaria(id, cpf);
    Sistema.ContaExcluir(x);
    Console.WriteLine("--- Opera????o Conclu??da ---");
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
    Console.WriteLine("------------------------------------------------------------------");
    Console.WriteLine();
  }
}