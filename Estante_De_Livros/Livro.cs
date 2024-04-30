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
        public string titulo;
        public string autores;
        public string editora;
        public int edicao;
        public int quantidadeDePaginas;
        public BigInteger ISBN;
        public DateOnly dataDeLacamento;

        public Livro() {
        }

        public void DefinirTitulo(string titulo)
        {
            this.titulo = titulo;
        }

        public void DefinirAutores(string autores)
        {
            this.autores = autores;
        }

        public void DefinirEditora(string editora)
        {
            this.editora = editora;
        }

        public void DefinirISBN(BigInteger ISBN)
        {
            this.ISBN = ISBN;
        }

        public void DefinirEdicao(int edicao)
        {
            this.edicao = edicao;
        }

        public void DefinirQuantidadeDePaginas(int paginas)
        {
            this.quantidadeDePaginas = paginas;
        }

        public void DefinirDataDeLancamento(DateOnly data)
        {
            this.dataDeLacamento = data;
        }

        public void ExibirDadosDoLivro()
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
