using System;
using System.Data.Common;
using System.IO;
using System.Security.Cryptography.X509Certificates;
namespace sistema
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }

        public string Senha { get; set; }

        public string Nickname { get; set; }

        public int Id { get; set; }



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



        string endereço = "C:\\Users\\Alunos\\3D Objects\\Sistema\\data\\Dados.csv";
        public void Usuario()
        {

            Console.WriteLine("Informe seu nome");
            pessoa1.Nome = Console.ReadLine().ToUpper();

            Console.WriteLine("Informe seu sobrenome");
            pessoa1.Sobrenome = Console.ReadLine().ToUpper();

            Console.WriteLine("Informe sua idade");
            pessoa1.Idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe seu Nickname");
        Return:
            pessoa1.Nickname = Console.ReadLine().Trim(); // Remove espaços extras no início e fim
            pessoa1.Id = 1;

            if (File.Exists(endereço))
            {
                string DadosId; //Criando variavel que ira receber o arquivo
                using (StreamReader y = new StreamReader(endereço)) //chamando metodo do endereço do arquivo(que irá retornar o contéudo do arquivo)
                {
                    FileInfo arquivoInfo = new FileInfo(endereço);

                    if (arquivoInfo.Length > 0)
                    {
                        while ((DadosId = y.ReadLine()) != null) // DadosId irá receber linha por linha do conteúdo arquivo e o 'null' para verificar se a linha é nula(ou esta em branca)
                        {
                            var idArquivos = DadosId.Split(new[] { ";" }, StringSplitOptions.None); //IdArquivos irá receber um array criado a partir das colunas da linhas. A função Split particiona uma string ou uma linha do excel em colunas, começando de [0, 1, 2].

                            foreach (var id in idArquivos) //id esta percorrendo coluna por coluna ou, o id esta percorrendo o array criado a partir das colunas da linha
                            {

                                while (pessoa1.Id <= int.Parse(idArquivos[0])) // pessoa1.Id diz respeito ao id que será usado para preencher o arquivo. Ele irá ser incrementado até que seja maior que o valor do id(int.Parse(idArquivos[0]))) retornado pelo arquivo
                                {

                                    pessoa1.Id++;
                                }

                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("o arquivo esta vazio");
                    }


                }
            }
            else
            {
                using (FileStream fs = File.Create(endereço))
                {

                }
            }



            if (File.Exists(endereço))
            {

                string[] Dados = File.ReadAllLines(endereço);
                foreach (string NickExistente in Dados)
                {
                    if (pessoa1.Nickname.Equals(NickExistente.Trim(), StringComparison.OrdinalIgnoreCase)) // pega a variavel pessoa1.Nickname compara com a variavel que vai percorrer o arquivo
                    {
                        Console.WriteLine("Nickname ja esta sendo usado. Tente outro");
                        goto Return;
                    }

                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\nDados do usuário:");
                Console.WriteLine($"Nome: {pessoa1.Nome} {pessoa1.Sobrenome}");
                Console.WriteLine($"Idade: {pessoa1.Idade} anos");
                Console.WriteLine($"Nickname: ID {pessoa1.Id} {pessoa1.Nickname}");
                Console.ResetColor();
            }
            else
            {
                using (FileStream fs = File.Create(endereço))
                {

                }
            }


        }
        public void Imprimir()
        {

            using (StreamWriter bloco = new StreamWriter("C:\\Users\\Alunos\\3D Objects\\Sistema\\data\\Dados.csv", append: true))
            {


                bloco.WriteLine($"{pessoa1.Id}; {pessoa1.Nome} {pessoa1.Sobrenome}; {pessoa1.Idade}; {pessoa1.Nickname}; {pessoa1.Senha}");
                bloco.Close();

            }

        }
        public void ler()
        {
            string caminhoArquivo = "C:\\Users\\Alunos\\3D Objects\\Sistema\\data\\Dados.csv";
            if (File.Exists(caminhoArquivo))
            {
                string arquivoInfo = File.ReadAllText(endereço);

                if (String.IsNullOrWhiteSpace(arquivoInfo))
                {
                    using (StreamReader x = new StreamReader(caminhoArquivo))
                    {
                        string line;
                        while ((line = x.ReadLine()) != null)  // Continua lendo até o final do arquivo
                        {
                            var teste = line.Split(new[] { ";" }, StringSplitOptions.None);

                            if (teste.Length >= 3)
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write(teste[i]);  // Exibe cada linha
                                    if (teste[1] == teste[i])
                                        Console.Write(" - ");
                                    if (teste[0] == teste[i])
                                        Console.Write(" ");
                                    Console.ResetColor();


                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("O arquivo esta em branco.");
                                Console.ResetColor();
                            }
                            Console.WriteLine();
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






                // Lê a senha digitada pelo usuário
                pessoa1.Senha = Console.ReadLine();

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