using Estante_De_Livros;
using System.Numerics;

Livro[] estante = new Livro[10];
int posicao = 0;
bool cadastrar = true, repetir = true;

Console.WriteLine("Organize a estante de livros!\n");

int Menu()
{
    do
    {
        Console.Write($" - A sua estante possui {posicao} livros, o que você deseja fazer? - \n");
        Console.WriteLine("(1) Armazenar novo livro");
        Console.WriteLine("(2) Exibir todos livros");
        Console.WriteLine("(3) Exibir livro pelo indice");
        Console.WriteLine("(4) Sair");

        int opcao = int.Parse(Console.ReadLine());

        if (opcao < 1 || opcao > 4)
        {
            Console.WriteLine("Opção inválida, tente novamente.\n");
        }
        else
        {
            return opcao;
        }
    }
    while (true);
}

Livro CadastrarLivro()
{
    int edicao, quantidadeDePaginas, contagemAutores = 0;
    string titulo = "", editora = "", autores = "";
    DateOnly dataDeLacamento;
    BigInteger ISBN;


    Console.Write("Titulo: ");
    titulo = (Console.ReadLine());

    bool adicionarAutor = false;
    do
    {
        Console.Write($"Autor(a) {contagemAutores + 1} [Máximo 3] : ");
        autores += Console.ReadLine();
        contagemAutores++;
        if (contagemAutores >= 3)
        {
            break;
        }

        Console.Write("\nDeseja incluir mais algum autor(a)? (S) Sim / (N) Não : ");
        adicionarAutor = Console.ReadLine().ToUpper().First() == 'S';
        if (adicionarAutor)
        {
            autores += ", ";
        }
    }
    while (adicionarAutor);
    
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

void ArmazenarLivro()
{
    do
    {
        Console.Clear();
        if (posicao >= 10)
        {
            Console.WriteLine("Estante cheia, impossível adicionar mais livros.");
            break;
        }
        Console.WriteLine($"Cadastre os dados os dados do livro antes de armazenar: \n");
        estante[posicao] = CadastrarLivro();
        posicao++;

        Console.WriteLine("\n - Livro Armazenado! - \n");

        Console.Write("Deseja armazenar mais um livro? (S) Sim / (N) Não : ");
        cadastrar = Console.ReadLine().ToUpper().First() == 'S';
    }
    while (cadastrar && posicao < 10);
}

void ImprimirTodosLivros()
{
    Console.Clear();
    Console.WriteLine("Livros da estante: \n");
    if (posicao < 1)
    {
        Console.WriteLine($"\nA estante está vazia, armazene um livro para poder exibir.");
    }
    Console.WriteLine();
    for (int livro = 0; livro < posicao; livro++)
    {
        estante[livro].ImprimirDadosDoLivro();
        Console.WriteLine();
    }
}

void ImprimirLivroPorIndice()
{
    Console.Clear();
    bool indiceInvalido = false;
    do
    {
        if (posicao < 1)
        {
            Console.WriteLine($"A estante está vazia, armazene um livro para poder exibir.");
            break;
        }

        Console.Write($"A prateleira possui {posicao} livros, qual você deseja imprimir?  ");
        int indice = int.Parse(Console.ReadLine()) - 1;

        if (indice < 0 || indice >= posicao)
        {
            Console.WriteLine("\nIndice inválido, tente novamente.\n");
            indiceInvalido = true;
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"Livro {indice + 1}: \n");
            estante[indice].ImprimirDadosDoLivro();
            indiceInvalido = false;
        }
    }
    while (indiceInvalido);
}

do
{
    Console.Clear();
    int opcao = Menu();
    switch(opcao)
    {
        case 1:
            ArmazenarLivro();
            break;
        case 2:
            ImprimirTodosLivros();
            Console.WriteLine("\n - Pressione qualquer tecla para voltar ao menu - \n");
            Console.ReadKey();
            break;
        case 3:
            ImprimirLivroPorIndice();
            Console.WriteLine("\n - Pressione qualquer tecla para voltar ao menu - \n");
            Console.ReadKey();
            break;
        case 4:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("\nOpção inválida, tente novamente.\n");
            Console.ReadKey();
            continue;
    }
}
while (true);
