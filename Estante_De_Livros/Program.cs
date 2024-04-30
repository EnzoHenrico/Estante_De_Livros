using Estante_De_Livros;
using System.Numerics;

Livro[] estante = new Livro[10];
int quantidadeDeLivros = 0;

Livro ArmazenarLivro()
{
    Livro livro = new Livro();

    Console.Write("Titulo: ");
    livro.DefinirTitulo(Console.ReadLine());

    Console.Write("Autores : ");
    livro.DefinirAutores(Console.ReadLine());

    Console.Write("Editora: ");
    livro.DefinirEditora(Console.ReadLine());

    Console.Write("ISBN: ");
    livro.DefinirISBN(BigInteger.Parse(Console.ReadLine()));

    Console.Write("Edição: ");
    livro.DefinirEdicao(int.Parse(Console.ReadLine()));

    Console.Write("Quantidade de páginas: ");
    livro.DefinirQuantidadeDePaginas(int.Parse(Console.ReadLine()));

    Console.Write("Data de lançamento: ");
    livro.DefinirDataDeLancamento(DateOnly.Parse(Console.ReadLine()));

    return livro;
}

void ImprimirTodosLivros()
{
    Console.WriteLine();
    for (int livro = 0; livro < quantidadeDeLivros; livro++)
    {
        estante[livro].ExibirDadosDoLivro();
        Console.WriteLine();
    }
}

void ImprimirLivroPorIndice()
{
    bool indiceInvalido = false;
    do
    {
        Console.Write($"A prateleira possui {quantidadeDeLivros} livros, qual você deseja imprimir?  ");
        int indice = int.Parse(Console.ReadLine()) - 1;

        if (indice < 0 || indice > quantidadeDeLivros)
        {
            Console.WriteLine("Indice inválido, tente novamente.\n");
            indiceInvalido = true;
        }
        else
        {
            Console.WriteLine();
            estante[indice].ExibirDadosDoLivro();
            indiceInvalido = false;
        }
    }
    while (indiceInvalido);
}

Console.WriteLine("Organize a estante de livros!\n");

// Interação inicial
do
{
    Console.Write("Quantos livros deseja armazenar?  ");
    quantidadeDeLivros = int.Parse(Console.ReadLine());

    if (quantidadeDeLivros < 1 && quantidadeDeLivros > 10)
    {
        Console.WriteLine("A quantidade deve ser de 1 a 10, tente novamente.\n");
    }
}
while (quantidadeDeLivros < 1 && quantidadeDeLivros > 10);

// Armazenamento dos livros
for (int posicao = 0; posicao < quantidadeDeLivros; posicao++)
{
    Console.Write($"\nCadastre os dados os dados do livro {posicao + 1} antes de armazenar: \n");
    estante[posicao] = ArmazenarLivro();
    Console.WriteLine("\nLivro armazenado!\n");
}

Console.ReadKey();

// Impressão dos livros
bool repetirBusca = true;
do
{
    Console.Clear();
    Console.WriteLine("Como deseja visualizar os livros da estante?");
    Console.WriteLine("\n(1) Exibir todos");
    Console.WriteLine("\n(2) Escolher pelo indice");
    int resposta = int.Parse(Console.ReadLine());
    
    if (resposta == 1)
    {
        ImprimirTodosLivros();
    }
    else if (resposta == 2)
    {
        ImprimirLivroPorIndice();
    }
    else
    {
        Console.WriteLine("\nOpção inválida, tente novamente.\n");
        continue;
    }

    Console.Write("\nDeseja visualizar mais algum livro? (S) Sim | (N) Não :  ");
    char buscarNovamente = Console.ReadLine().ToUpper().First();
    if (buscarNovamente == 'S')
    {
        repetirBusca = true;
    }
    else
    {
        repetirBusca = false;
    }
}
while (repetirBusca);