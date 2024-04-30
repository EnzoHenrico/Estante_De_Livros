using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Estante_De_Livros
{
    public class Livro
    {
        string titulo;
        string autores;
        string editora;
        int edicao;
        int quantidadeDePaginas;
        BigInteger ISBN;
        DateOnly dataDeLacamento;

        public Livro(string titulo, string autores, string editora, int edicao, int quantidadeDePaginas, BigInteger iSBN, DateOnly dataDeLacamento)
        {
            this.titulo = titulo;
            this.autores = autores;
            this.editora = editora;
            this.edicao = edicao;
            this.quantidadeDePaginas = quantidadeDePaginas;
            ISBN = iSBN;
            this.dataDeLacamento = dataDeLacamento;
        }

        public void ImprimirDadosDoLivro()
        {
            Console.WriteLine("Titulo: " + this.titulo);
            Console.WriteLine("Autores: " + this.autores);
            Console.WriteLine("Editora: " + this.editora);
            Console.WriteLine("ISDN: " + this.ISBN);
            Console.WriteLine("Edição: " + this.edicao);
            Console.WriteLine("Quantidade de páginas: " + this.quantidadeDePaginas);
            Console.WriteLine("Data de Lançamento: " + this.dataDeLacamento);
        }
    }
}
