using System;

class Sistema {
  private static Banco[] bancos = new Banco[5];
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
  
}