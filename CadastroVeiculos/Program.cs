
 // Ilda Afonso - RM:568233
using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main()
    {
        Repositorio repositorio = new Repositorio();

       
        List<Veiculo> veiculos = repositorio.Carregar();

        bool executando = true;

        while (executando)
        {
            Console.WriteLine("\n=== CADASTRO DE VEÍCULOS ===");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Listar");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine() ?? "";

            switch (opcao)
            {
                case "1":
                    Cadastrar(veiculos, repositorio);
                    break;

                case "2":
                    Listar(veiculos);
                    break;

                case "0":
                    executando = false;
                    Console.WriteLine("Programa encerrado.");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void Cadastrar(
        List<Veiculo> veiculos,
        Repositorio repositorio)
    {
        bool cadastrarOutro;

        do
        {
            Console.WriteLine("\n=== NOVO CADASTRO ===");
            Console.WriteLine("1 - Veículo");
            Console.WriteLine("2 - Moto");

            int tipo = LerInteiro("Escolha o tipo (1 ou 2): ", 1, 2);

            string marca = LerTexto("Marca: ");
            string modelo = LerTexto("Modelo: ");
            int ano = LerInteiro("Ano: ", 1886, 2100);
            string cor = LerTexto("Cor: ");
            decimal preco = LerDecimal("Preço: ");

            Veiculo veiculo;

            if (tipo == 2)
            {
                int cilindradas = LerInteiro(
                    "Cilindradas: ", 1, 3000);

                veiculo = new Moto(
                    marca, modelo, ano, cor, preco, cilindradas);
            }
            else
            {
                veiculo = new Veiculo(
                    marca, modelo, ano, cor, preco);
            }

            veiculos.Add(veiculo);

            if (repositorio.Salvar(veiculos))
            {
                Console.WriteLine("Cadastrado com sucesso!");
            }
            else
            {
        
                veiculos.Remove(veiculo);
                Console.WriteLine(
                    "Cadastro não salvo. Tente novamente.");
            }

            cadastrarOutro = LerSimNao(
                "Deseja cadastrar outro? (s/n): ");

        } while (cadastrarOutro);
    }

    static void Listar(List<Veiculo> veiculos)
    {
        Console.WriteLine("\n=== VEÍCULOS CADASTRADOS ===");

        if (veiculos.Count == 0)
        {
            Console.WriteLine("Nenhum cadastro encontrado.");
        }
        else
        {
            foreach (Veiculo veiculo in veiculos)
            {
                veiculo.Apresentar();
            }
        }

        Console.WriteLine($"Total de itens: {veiculos.Count}");
    }

    
    static string LerTexto(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            string texto = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(texto))
            {
                return texto.Trim();
            }

            Console.WriteLine(
                "Campo obrigatório. Digite novamente.");
        }
    }


    static int LerInteiro(
        string mensagem, int minimo, int maximo)
    {
        while (true)
        {
            Console.Write(mensagem);
            string entrada = Console.ReadLine() ?? "";

            int valor;

            try
            {
                valor = int.Parse(entrada);
            }
            catch (FormatException)
            {
                Console.WriteLine(
                    "Digite um número inteiro válido.");
                continue;
            }

            if (valor < minimo || valor > maximo)
            {
                Console.WriteLine(
                    $"Digite um valor entre {minimo} e {maximo}.");
                continue;
            }

            return valor;
        }
    }

        static decimal LerDecimal(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            string entrada = Console.ReadLine() ?? "";

            decimal valor;

            try
            {
                valor = decimal.Parse(
                    entrada, CultureInfo.CurrentCulture);
            }
            catch (FormatException)
            {
                Console.WriteLine(
                    "Digite um preço numérico válido.");
                continue;
            }

            if (valor < 0)
            {
                Console.WriteLine(
                    "O preço não pode ser negativo.");
                continue;
            }

            return valor;
        }
    }

    static bool LerSimNao(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            string resposta = (
                Console.ReadLine() ?? "").Trim().ToLower();

            if (resposta == "s")
                return true;

            if (resposta == "n")
                return false;

            Console.WriteLine("Digite apenas s ou n.");
        }
    }
}