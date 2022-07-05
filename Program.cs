using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoEntity();
            RecuperarProdutos();
            ExcluirProdutos();
            RecuperarProdutos();
        }

        private static void ExcluirProdutos()
        {
            using(var repo = new LojaContext())
            {
                IList<Produto> produtos = repo.Produtos.ToList();
                foreach (var item in produtos)
                {
                    repo.Produtos.Remove(item);
                }
                repo.SaveChanges();
            }
        }

        private static void RecuperarProdutos()
        {
           using(var repo = new LojaContext())
            {
                IList<Produto> produtos = repo.Produtos.ToList(); //Através da propriedade Clientes acessamos os metodos de DbSet(Classe), um deles é o ToList que serve para recuperar a lista de todos clientes do banco.
                Console.WriteLine("Foram encontrados {0} produtos(s).", produtos.Count);
                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                }
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter";
            p.Categoria = "Livros";
            p.Preco = 19.99;


            using (var contexto = new LojaContext())
            {
                contexto.Produtos.Add(p);
                contexto.SaveChanges();
            }

        }
    }
}
    

