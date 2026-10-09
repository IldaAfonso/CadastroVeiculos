
 // Ilda Afonso - RM: 568233
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Repositorio
{
    private readonly string _caminhoArquivo = "veiculos.json";

    // Carrega os veículos salvos no arquivo JSON
    public List<Veiculo> Carregar()
    {
        // Estado 1: arquivo não existe
        if (!File.Exists(_caminhoArquivo))
        {
            Console.WriteLine(
                "Arquivo não existe. Iniciando lista vazia."
            );

            return new List<Veiculo>();
        }

        try
        {
            string conteudo = File.ReadAllText(_caminhoArquivo);

            // Estado 2: arquivo vazio ou só com espaços
            if (string.IsNullOrWhiteSpace(conteudo))
            {
                Console.WriteLine(
                    "Arquivo vazio. Iniciando lista vazia."
                );

                return new List<Veiculo>();
            }

            List<Veiculo>? veiculos =
                JsonSerializer.Deserialize<List<Veiculo>>(conteudo);

            if (veiculos == null)
            {
                Console.WriteLine(
                    "Arquivo sem dados. Iniciando lista vazia."
                );

                return new List<Veiculo>();
            }

            Console.WriteLine(
                $"{veiculos.Count} item(ns) carregado(s) do arquivo."
            );

            return veiculos;
        }
        // Estado 3: JSON inválido
        catch (JsonException)
        {
            Console.WriteLine(
                "JSON inválido. Tentando preservar o arquivo corrompido."
            );

            try
            {
                File.Copy(
                    _caminhoArquivo,
                    _caminhoArquivo + ".corrompido",
                    true
                );

                Console.WriteLine(
                    "Cópia de segurança criada: veiculos.json.corrompido"
                );
            }
            catch (IOException erroCopia)
            {
                Console.WriteLine(
                    $"Não foi possível copiar o arquivo: {erroCopia.Message}"
                );
            }

            return new List<Veiculo>();
        }
        // Estado 4: erro de leitura
        catch (IOException erro)
        {
            Console.WriteLine(
                $"Erro ao ler o arquivo: {erro.Message}"
            );

            return new List<Veiculo>();
        }
    }

    // Salva os veículos no arquivo JSON
    public bool Salvar(List<Veiculo> veiculos)
    {
        try
        {
            string json = JsonSerializer.Serialize(
                veiculos,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                }
            );

            File.WriteAllText(_caminhoArquivo, json);

            return true;
        }
        catch (IOException erro)
        {
            Console.WriteLine(
                $"Erro ao salvar o arquivo: {erro.Message}"
            );

            return false;
        }
    }
}