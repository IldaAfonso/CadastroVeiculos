
 // Ilda Afonso - RM: 568233
using System;
using System.Text.Json.Serialization;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "tipo")]
[JsonDerivedType(typeof(Moto), "Moto")]
public class Veiculo
{
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public int Ano { get; set; }
    public string Cor { get; set; } = string.Empty;
    public decimal Preco { get; set; }


    public Veiculo()
    {
    }


    public Veiculo(string marca, string modelo, int ano,
                   string cor, decimal preco)
    {
        Marca = marca;
        Modelo = modelo;
        Ano = ano;
        Cor = cor;
        Preco = preco;
    }

   
    public virtual void Apresentar()
    {
        Console.WriteLine(
            $"Marca: {Marca} | Modelo: {Modelo} | " +
            $"Ano: {Ano} | Cor: {Cor} | Preço: {Preco:C}"
        );
    }
}