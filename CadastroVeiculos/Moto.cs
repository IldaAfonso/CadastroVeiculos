
 // Ilda Afonso - RM:568233
using System;

public class Moto : Veiculo
{
    public int Cilindradas { get; set; }

    // Construtor vazio
    public Moto()
    {
    }

    // Construtor completo, chamando a classe mãe
    public Moto(string marca, string modelo, int ano,
                string cor, decimal preco, int cilindradas)
        : base(marca, modelo, ano, cor, preco)
    {
        Cilindradas = cilindradas;
    }

    // Sobrescrita do método da classe mãe
    public override void Apresentar()
    {
        Console.WriteLine(
            $"Marca: {Marca} | Modelo: {Modelo} | " +
            $"Ano: {Ano} | Cor: {Cor} | Preço: {Preco:C} | " +
            $"Cilindradas: {Cilindradas} cc"
        );
    }
}