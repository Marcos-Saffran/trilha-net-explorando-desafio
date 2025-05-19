using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
// List<Pessoa> hospedes = new List<Pessoa>();

// Pessoa p1 = new Pessoa(nome: "Hóspede 1");
// Pessoa p2 = new Pessoa(nome: "Hóspede 2");

// hospedes.Add(p1);
// hospedes.Add(p2);

// // Cria a suíte
// Suite suite = new Suite(tipoSuite: "Premium", capacidade: 1, valorDiaria: 30);

// // Cria uma nova reserva, passando a suíte e os hóspedes
// Reserva reserva = new Reserva(diasReservados: 10);
// reserva.CadastrarSuite(suite);
// reserva.CadastrarHospedes(hospedes);

// // Exibe a quantidade de hóspedes e o valor da diária
// Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
// Console.WriteLine($"Valor da diária: {reserva.Suite.ValorDiaria.ToString("C2")}");
// Console.WriteLine($"Valor total: {reserva.CalcularValorDiaria().ToString("C2")}, para {reserva.DiasReservados} dias.");
// Console.WriteLine($"Tipo da suíte: {reserva.Suite.TipoSuite}");

// criando menu iterativo para cadastrar reservas
bool continuar = true;
while (continuar)
{
    Console.Clear();
    Console.WriteLine("Bem-vindo ao sistema de reservas!");
    Console.WriteLine("Deseja cadastrar uma nova reserva? (s/n)");
    string resposta = Console.ReadLine().ToLower();

    switch (resposta)
    {
        case "s":
            Console.WriteLine("Você escolheu cadastrar uma nova reserva.");
            List<Pessoa> hospedesMenu = new List<Pessoa>();

        Console.WriteLine("Quantos hóspedes deseja cadastrar?");
        int quantidadeHospedes = int.Parse(Console.ReadLine());

        for (int i = 0; i < quantidadeHospedes; i++)
        {
            Console.WriteLine($"Digite o nome do hóspede {i + 1}:");
            string nomeHospede = Console.ReadLine();
            Pessoa hospede = new Pessoa(nome: nomeHospede);
            hospedesMenu.Add(hospede);
        }

        // Cria a suíte
        Console.WriteLine("Digite o tipo da suíte:");
        string tipoSuite = Console.ReadLine();

        Console.WriteLine("Digite a capacidade da suíte:");
        int capacidadeSuite = int.Parse(Console.ReadLine());

        Console.WriteLine("Quantas diárias deseja reservar?");
        int diasReservados = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o valor da diária:");
        decimal valorDiaria = decimal.Parse(Console.ReadLine());

        Suite suiteMenu = new Suite(tipoSuite: tipoSuite, capacidade: capacidadeSuite, valorDiaria: valorDiaria);

        // Cria uma nova reserva, passando a suíte e os hóspedes
        Reserva reservaMenu = new Reserva(diasReservados: diasReservados);
        reservaMenu.CadastrarSuite(suiteMenu);
        try
        {
            reservaMenu.CadastrarHospedes(hospedesMenu);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Deseja tentar novamente? (s/n)");
            string respostaErro = Console.ReadLine().ToLower();
            if (respostaErro == "s")
            {
                continue;
            }
            else
            {
                continuar = false;
                break;
            }
        }

        // Exibe a quantidade de hóspedes e o valor da diária
        Console.WriteLine($"Hóspedes: {reservaMenu.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor da diária: {reservaMenu.Suite.ValorDiaria.ToString("C2")}");
        Console.WriteLine($"Valor total: {reservaMenu.CalcularValorDiaria().ToString("C2")}, para {reservaMenu.DiasReservados} dias.");
        Console.WriteLine($"Tipo da suíte: {reservaMenu.Suite.TipoSuite}");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
            break;
        case "n":
            Console.WriteLine("Você escolheu não cadastrar uma nova reserva.");
            continuar = false;
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            continue;
    }
}