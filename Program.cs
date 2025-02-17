// See https://aka.ms/new-console-template for more information
using sistema;

Console.Clear();
Sistema x = new Sistema();
while (true)
{
    Console.WriteLine("Digite 'sair' para encerrar o código");
    string s = Console.ReadLine().ToLower();
    if (s == "sair")
    {
        break;
    }
    else
    {
        x.ler();
        x.Imprimir();
        x.Senha();
    }
}

