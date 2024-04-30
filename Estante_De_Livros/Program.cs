using Estante_De_Livros;
using System.Numerics;

Livro[] estante = new Livro[10];
int posicao = 0;
bool cadastrar = true, repetir = true;

Livro ArmazenarLivro()
{
    int edicao, quantidadeDePaginas;
    string titulo, autores, editora;
    DateOnly dataDeLacamento;
    BigInteger ISBN;

    Console.Write("Titulo: ");
    titulo = (Console.ReadLine());

    Console.Write("Autores : ");
    autores = (Console.ReadLine());

    Console.Write("Editora: ");
    editora = (Console.ReadLine());

    Console.Write("Edição: ");
    edicao = (int.Parse(Console.ReadLine()));

    Console.Write("Quantidade de páginas: ");
    quantidadeDePaginas = (int.Parse(Console.ReadLine()));

    Console.Write("ISBN: ");
    ISBN = (BigInteger.Parse(Console.ReadLine()));

    Console.Write("Data de lançamento: ");
    dataDeLacamento = (DateOnly.Parse(Console.ReadLine()));

    return new(titulo, autores, editora, edicao, quantidadeDePaginas, ISBN, dataDeLacamento);
}

void ImprimirTodosLivros(int quantidade)
{
    Console.WriteLine();
    for (int livro = 0; livro < quantidade; livro++)
    {
        estante[livro].ImprimirDadosDoLivro();
        Console.WriteLine();
    }
}

void ImprimirLivroPorIndice()
{
    bool indiceInvalido = false;
    do
    {
        Console.Write($"A prateleira possui {posicao} livros, qual você deseja imprimir?  ");
        int indice = int.Parse(Console.ReadLine()) - 1;

        if (indice < 0 || indice > posicao)
        {
            Console.WriteLine("Indice inválido, tente novamente.\n");
            indiceInvalido = true;
        }
        else
        {
            Console.WriteLine();
            estante[indice].ImprimirDadosDoLivro();
            indiceInvalido = false;
        }
    }
    while (indiceInvalido);
}

Console.WriteLine("Organize a estante de livros!\n");

// Armazenamento dos livros
do
{
    Console.Write($"\nCadastre os dados os dados do livro antes de armazenar: \n");
    estante[posicao] = ArmazenarLivro();
    posicao++;

    Console.Clear();
    Console.WriteLine("\nLivro armazenado!\n");
    Console.Write("Deseja armazenar mais um livro? (S) Sim / (N) Não : ");
    cadastrar = Console.ReadLine().ToUpper().First() == 'S';
}
while (cadastrar && posicao < 10);

// Impressão dos livros
do
{
    Console.Clear();
    Console.WriteLine("Como deseja visualizar os livros da estante?\n");
    Console.WriteLine("(1) Exibir todos");
    Console.WriteLine("(2) Escolher pelo indice");
    int resposta = int.Parse(Console.ReadLine());
    
    if (resposta == 1)
    {
        ImprimirTodosLivros(posicao);
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
    repetir = Console.ReadLine().ToUpper().First() == 'S';
}
while (repetir);