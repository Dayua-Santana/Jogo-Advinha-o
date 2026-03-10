using System.Security.Cryptography;

// int numeroAleatorio = RandomNumberGenerator.GetInt32(1, 101);

Console.WriteLine("--------------------------------");
Console.WriteLine("------Jogo de Advinhação------");
Console.WriteLine("--------------------------------");

int numeroSecreto = RandomNumberGenerator.GetInt32(1, 21);


while (true)
{
    Console.Clear();

    Console.Write("Digite um número entre 1 e 21: ");
    int numeroDigitado = Convert.ToInt32(Console.ReadLine());

    if (numeroDigitado == numeroSecreto)
    {
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine($"Parabéns você acertou o número é {numeroSecreto}");
        Console.WriteLine("-----------------------------------------------------");

        Console.ReadLine();

        Console.WriteLine("(C) para continuar ou (S) para Sair ");
        string? letraDigitada = Console.ReadLine();
        if (letraDigitada == "C" || letraDigitada == "c")
        {
            continue;
        }
        else if (letraDigitada == "S" || letraDigitada == "s")
        {
            break;
        }
    }
    else if (numeroDigitado > numeroSecreto)
    {
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("O número digitador é maior do que o número secreto!!!!");
        Console.WriteLine("-----------------------------------------------------");
    }
    else if (numeroDigitado < numeroSecreto)
    {
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("O número digitador é menor do que o número secreto!!!!");
        Console.WriteLine("-----------------------------------------------------");
    }
    else
    {
        Console.Write("Digite um número válido: ");
        Console.ReadLine();
    }

    Console.ReadLine();
}
