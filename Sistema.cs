using System;
using System.IO;
namespace sistema
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }

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
                string senha = Console.ReadLine();
                bloco.WriteLine(senha);
                bloco.Close();

                if (senha.Length <= 5)
                {
                    Console.WriteLine("sua senha é curta, informe outra");
                }
                else
                {
                    bool verifCaracterEspecial = false;

                    foreach (var c in senha)
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