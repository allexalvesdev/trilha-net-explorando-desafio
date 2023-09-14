namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            Console.WriteLine("Registre os Hospedes");
            Console.WriteLine("Quantos hospedes deseja cadastrar?");
            var qtdHospede = int.Parse(Console.ReadLine());

            if (ValidaCapacidadeHospedagem(qtdHospede))
            {
                for (int i = 0; i < qtdHospede; i++)
                {
                    Console.WriteLine("Digite o Nome: ");
                    var nome = Console.ReadLine();

                    Console.WriteLine("Digite o Sobrenome: ");
                    var sobrenome = Console.ReadLine();

                    hospedes.Add(new Pessoa()
                    {
                        Nome = nome,
                        Sobrenome = sobrenome
                    });
                }

                Hospedes = hospedes;
            }
            else
            {
                Console.WriteLine($"Desculpe, não há capacidade para essa quantidade de pessoas para a Suite. Limite Máximo permitido: {Suite?.Capacidade}");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            if (Hospedes is not null)
            {
                Console.WriteLine($"Obter quantidade de Hospedes: {Hospedes.Count}");
                return Hospedes.Count;
            }

            Console.WriteLine($"Nenhum hospede registrado!");
            return 0;
        }

        public decimal CalcularValorDiaria()
        {
            decimal total = 0;

            Console.WriteLine("Digite a quantidade de dias para reserva: ");
            DiasReservados = int.Parse(Console.ReadLine());

            var possuiDescontoDiaria = ValidaDescontoDiaria(DiasReservados);

            if (possuiDescontoDiaria)
            {
                decimal desconto = Suite?.ValorDiaria * 0.10m ?? 0m;
                decimal valorComDesconto = Suite?.ValorDiaria - desconto ?? 0m;
                total = DiasReservados * valorComDesconto;

                Console.WriteLine($"Valor total da diaria: R$: {total}");

                return total;
            }

            total = DiasReservados * (Suite?.ValorDiaria ?? 0m);

            Console.WriteLine($"Valor total da diaria: R$: {total}");
            return total;
        }

        private bool ValidaCapacidadeHospedagem(int quantidadePessoas)
        {
            return quantidadePessoas <= (Suite?.Capacidade ?? 0);
        }

        private bool ValidaDescontoDiaria(int diasReservados)
        {
            return DiasReservados >= 10;
        }

    }
}