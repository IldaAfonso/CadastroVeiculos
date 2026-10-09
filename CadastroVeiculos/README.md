# Cadastro de Veículos — Linguagem C#

Projeto acadêmico desenvolvido em C# com o objetivo de praticar os conceitos de **Programação Orientada a Objetos**, especialmente herança, polimorfismo e persistência de dados em JSON.

## Objetivo

Desenvolver uma aplicação de console que permita cadastrar e listar veículos, armazenando as informações em um arquivo JSON para que os dados permaneçam disponíveis após o encerramento do programa.

## Tecnologias utilizadas

* C#
* .NET
* JSON
* `System.Text.Json`
* Visual Studio Code
* Git e GitHub

## Conceitos aplicados

* **Herança:** a classe `Moto` herda características da classe `Veiculo`.
* **Polimorfismo:** o método `Apresentar()` é sobrescrito na classe `Moto`.
* **Encapsulamento:** utilização de propriedades para organizar os dados dos objetos.
* **Persistência de dados:** leitura e gravação dos cadastros no arquivo `veiculos.json`.
* **Validação de entradas:** tratamento de entradas inválidas durante o cadastro.
* **Tratamento de exceções:** identificação de situações como arquivo vazio, JSON inválido e erros de leitura.

## Estrutura do projeto

```text
CadastroVeiculos/
├── Program.cs
├── Veiculo.cs
├── Moto.cs
├── Repositorio.cs
├── .gitignore
└── README.md
```

O arquivo `veiculos.json` é gerado localmente para armazenar os registros cadastrados.

## Funcionalidades

* Cadastrar veículos comuns.
* Cadastrar motos com informação adicional de cilindradas.
* Listar os veículos cadastrados.
* Exibir o total de registros.
* Salvar e carregar os dados em JSON.
* Validar informações digitadas pelo usuário.
* Tratar situações de arquivo vazio ou JSON corrompido.

## Como executar

É necessário ter o SDK do .NET instalado.

1. Clone o repositório:

   ```bash
   git clone URL_DO_REPOSITORIO
   ```

2. Entre na pasta do projeto:

   ```bash
   cd CadastroVeiculos
   ```

3. Execute a aplicação:

   ```bash
   dotnet run
   ```

## Menu da aplicação

* `1` — Cadastrar
* `2` — Listar
* `0` — Sair

## Contexto acadêmico

Projeto desenvolvido como atividade acadêmica da FIAP para praticar herança, polimorfismo e persistência de dados em JSON utilizando C#.

**Autora:** Ilda Afonso
