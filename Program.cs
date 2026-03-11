// Objetivos / Passo-a-passo

// v1
// 1. Nosso jogo deve aceitar o input do jogador e exibir o valor digitado
// 2. Nosso jogo deve gerar um número aleatório
// 3. Nosso jogo deve validar a tentativa do jogador e exibir uma mensagem
// 4. Nosso jogo deve permitir múltiplas tentativas

// v2
// 1. Nosso jogo deve implementar a funcionalidade de Dificuldade e Tentativas limitadas
// 2. Nosso jogo deve umplementar uma funcionalidade de Validação de Números Repetidos
// 3. Nosso jogo deve mplementar uma funcionalidade de Pontuação

using System; // biblioteca padrão do sistema com classes genêricas
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

// int numeroSecreto = RandomNumberGenerator.GetInt32(1, 21);
class Progam
{
    static int[] ConfigurarPartida(string? dificuldadeEscolhida)
    {
        int numeroMaximo = 0;
        int tentativasMaximas = 0;

        switch (dificuldadeEscolhida)
        {
            case "1":
                numeroMaximo = 20;
                tentativasMaximas = 10;
                break;

            case "2":
                numeroMaximo = 50;
                tentativasMaximas = 5;
                break;

            case "3":
                numeroMaximo = 100;
                tentativasMaximas = 3;
                break;

            default:
                Console.WriteLine("Por favor, selecione uma dificuldade válida!!!");
                break;
        }

        return new int[] { numeroMaximo, tentativasMaximas };
    }

    static void Main(string[] args)
    {

        while (true)
        {

            //1. Desenha a tela de menu e espera o input do usuário(dificuldade)
            string? dificuldadeEscolhida = ExibirMenu();

            //2. Configuração do jogo
            int[] configuracoes = ConfigurarPartida(dificuldadeEscolhida);
            int numeroMaximo = configuracoes[0];
            int tentativasMaximas = configuracoes[1];

            if (numeroMaximo == 0) continue;

            //3. Execução do jogo
            ExecutarPartida(numeroMaximo, tentativasMaximas);

            //4. Pergunta se o jogador vai continuar o jogo
            if (!Jogadordesejacontinuar()) break;
        }
    }

    static string? ExibirMenu()
    {
        Console.Clear();

        Console.WriteLine("--------------------------------");
        Console.WriteLine("------Jogo de Advinhação------");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("1 - Fácil (10 tentativas)");
        Console.WriteLine("2 - Médio (5 tentativas)");
        Console.WriteLine("3 - Difícil (3 tentativas)");
        Console.WriteLine("--------------------------------");

        Console.Write("Digite sua Escolha: ");
        return Console.ReadLine();
    }


    static void ExecutarPartida(int numeroMaximo, int tentativasMaximas)
    {
        int[] numerosDigitados = new int[tentativasMaximas];
        int contadorNumerosDigitados = 0;
        int pontuacao = 1000;

        int numeroAleatorio = RandomNumberGenerator.GetInt32(1, numeroMaximo + 1);

        for (int tentativa = 1; tentativa <= tentativasMaximas; tentativa++)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine($"Tentativa {tentativa} de {tentativasMaximas}.");
            Console.Write($"Digite um número entre 1 e {numeroMaximo}: ");
            string? chute = Console.ReadLine();

            int numeroDigitado = Convert.ToInt32(chute);

            bool numeroEstaRepetido = false;

            for (int i = 0; i < numerosDigitados.Length; i++)
            {
                if (numerosDigitados[i] == numeroDigitado)
                {
                    numeroEstaRepetido = true;
                    break;
                }
            }

            if (numeroEstaRepetido)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("Você já digitou esse número, tente novamente.");
                Console.WriteLine("---------------------------");
                Console.Write("Digite ENTER para continuar...");
                Console.ReadLine();

                tentativa--;

                continue;
            }

            if (contadorNumerosDigitados < numerosDigitados.Length)
            {
                numerosDigitados[contadorNumerosDigitados] = numeroDigitado;
                contadorNumerosDigitados++;
            }

            if (numeroDigitado == numeroAleatorio)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("Parabéns você acertou!!!");
                Console.WriteLine("---------------------------");
            }
            if (numeroDigitado > numeroAleatorio)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("O número digitado foi maior que o número secreto!");
                Console.WriteLine("---------------------------");
            }
            else
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("O número digitado foi menor que o número secreto!");
                Console.WriteLine("--------------------------------------------------");

            }

            int diferencaNumerica = Math.Abs(numeroAleatorio - numeroDigitado);// 90 - 100 = 10

            if (diferencaNumerica >= 10) pontuacao -= 100;

            else if (diferencaNumerica >= 5) pontuacao -= 50;

            else pontuacao -= 20;

            if (tentativa == tentativasMaximas)
            {
                Console.WriteLine($"\nAcabaram as chances! O número era {numeroAleatorio}.");
            }
        }
    }

    static bool Jogadordesejacontinuar()
    {
        Console.Write("\nDeseja continuar? (s/N): ");
        string? opcao = Console.ReadLine();
        return opcao?.ToUpper() == "S";
    }
}