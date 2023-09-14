using System.Text;
using DesafioProjetoHospedagem.Models;

class Program
{
    static Reserva reserva = new Reserva();
    static List<Pessoa> hospedes = new List<Pessoa>();
    static Suite suite;

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        hospedes = new List<Pessoa>();
        suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);
        reserva = new Reserva(diasReservados: 5);

        bool exibirMenu = true;

        while (exibirMenu)
        {
            exibirMenu = ExibirMenu();
        }

        Console.WriteLine("O programa se encerrou");
    }

    private static bool ExibirMenu()
    {
        Console.Clear();
        Console.WriteLine("Acessando dados da Suite...");
        Thread.Sleep(3000);
        reserva.CadastrarSuite(suite);
        Console.WriteLine("Dados concluidos.");

        Console.WriteLine();
        Console.Clear();

        Console.WriteLine("HOTEL DIO");
        Console.WriteLine("Digite a sua opção:");
        Console.WriteLine("1 - Cadastrar hospedes");
        Console.WriteLine("2 - Calcular Diaria");
        Console.WriteLine("3 - Obter Quantidade de Hospedes");
        Console.WriteLine("4 - Encerrar");

        Console.WriteLine();

        switch (Console.ReadLine())
        {
            case "1":
                reserva.CadastrarHospedes(hospedes);
                break;

            case "2":
                reserva.CalcularValorDiaria();
                break;

            case "3":
                reserva.ObterQuantidadeHospedes();
                break;

            case "4":
                return false;

            default:
                Console.WriteLine("Opção inválida");
                break;
        }

        Console.WriteLine("Pressione uma tecla para continuar");
        Console.ReadLine();
        return true;
    }
}