using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
namespace sistema
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }

        public string Senha { get; set;}

        // public Pessoa(string nome, string sobrenome, int idade)
        // {
        //     Nome = nome;
        //     Sobrenome = sobrenome;
        //     Idade = idade;
        // }
    }

    public class Sistema
    {

        Pessoa pessoa1 = new Pessoa();

        public void Usuario()
        {
            Console.WriteLine("Informe seu nome");
            pessoa1.Nome = Console.ReadLine().ToUpper();

            Console.WriteLine("Informe seu sobrenome");
            pessoa1.Sobrenome = Console.ReadLine().ToUpper();

            Console.WriteLine("Informe sua idade");
            pessoa1.Idade = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nDados do usuário:");
            Console.WriteLine($"Nome: {pessoa1.Nome} {pessoa1.Sobrenome}");
            Console.WriteLine($"Idade: {pessoa1.Idade} anos");
            Console.ResetColor();
        }
        public void Imprimir()
        {

            using (StreamWriter bloco = new StreamWriter("C:\\Users\\Alunos\\3D Objects\\Sistema\\data\\Dados.csv", append: true))
            {
                Usuario();
                bloco.WriteLine($"{pessoa1.Nome} {pessoa1.Sobrenome};{pessoa1.Idade};");
                bloco.Close();

            }

        }
        public void ler()
        {
            string caminhoArquivo = "C:\\Users\\Alunos\\3D Objects\\Sistema\\data\\Dados.csv";
            if (File.Exists(caminhoArquivo))
            {
                FileInfo arquivoInfo = new FileInfo(caminhoArquivo);

                if (arquivoInfo.Length > 0)
                {
                    using (StreamReader x = new StreamReader(caminhoArquivo))
                    {
                        string line;
                        while ((line = x.ReadLine()) != null)  // Continua lendo até o final do arquivo
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(line);  // Exibe cada linha
                            Console.ResetColor();
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("O arquivo está vazio.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("O arquivo não existe.");
                Console.ResetColor();
            }
        }
        public void Senha()
        {
            // Solicita que o usuário informe uma senha
            while (true)
            {

                Console.WriteLine("Nos informe sua senha");

                StreamWriter bloco = new StreamWriter("C:\\Users\\Alunos\\3D Objects\\Sistema\\data\\Senhas.csv");




                // Lê a senha digitada pelo usuário
                pessoa1.Senha = Console.ReadLine();
                bloco.WriteLine($"{pessoa1.Nome} {pessoa1.Sobrenome}; {pessoa1.Idade}; {pessoa1.Senha} ");
                bloco.Close();

                if (pessoa1.Senha.Length <= 5)
                {
                    Console.WriteLine("sua senha é curta, informe outra");
                }
                else
                {
                    bool verifCaracterEspecial = false;

                    foreach (var c in pessoa1.Senha)
                    {
                        if (char.IsPunctuation(c))
                        {
                            verifCaracterEspecial = true;
                            break;
                        }
                    }
                    if (verifCaracterEspecial)
                    {
                        Console.WriteLine("senha válida");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Sua senha deve conter ao menos um caracter especial");
                    }


                }
            }



        }
       
    }
}
public class formatação
{
    public void EscreverComBorda()
    {
        string texto = "Cadastro";
        int largura = texto.Length + 4; // Define a largura total da borda
        int telaLargura = Console.WindowWidth;  // Largura da tela 
        int espacosAntes = (telaLargura - largura) / 2;  // Calcular a quantidade de espaços para centralizar

        // Caracteres especiais para formar a borda
        char cantoSupEsq = '╔';
        char cantoSupDir = '╗';
        char cantoInfEsq = '╚';
        char cantoInfDir = '╝';
        char horizontal = '═';
        char vertical = '║';

        string linhaTexto = $"{vertical} {texto} {vertical}";

        // Cria a linha superior
        string linhaSuperior = cantoSupEsq + new string(horizontal, largura - 2) + cantoSupDir;

        // Cria a linha inferior
        string linhaInferior = cantoInfEsq + new string(horizontal, largura - 2) + cantoInfDir;

        // Exibe a borda completa
        Console.SetCursorPosition(espacosAntes, Console.CursorTop); // Move o cursor para a posição certa
        Console.WriteLine(linhaSuperior);

        Console.SetCursorPosition(espacosAntes, Console.CursorTop); // Mover o cursor novamente
        Console.WriteLine(linhaTexto);

        Console.SetCursorPosition(espacosAntes, Console.CursorTop); // Mover o cursor novamente
        Console.WriteLine(linhaInferior);
    }


}