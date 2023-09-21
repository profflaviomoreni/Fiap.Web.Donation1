using Fiap.Web.Donation1.Data;
using Fiap.Web.Donation1.Models;

namespace Fiap.Web.Donation1.Repository
{
    public class ProdutoRepository
    {

        private readonly DataContext dataContext;

        public ProdutoRepository(DataContext ctx) {
            dataContext = ctx;
        }

        // Listar Todos
        public IList<ProdutoModel> FindAll()
        {
            var produtos = dataContext.Produtos.ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }

        // Detalhe (Consulta por Id)
        public ProdutoModel FindById(int id)
        {
                                               //  WHERE          ProdutoId = {id}   
            var produto = dataContext.Produtos.FirstOrDefault( p => p.ProdutoId == id );

            return produto;
        }

        // Inserir
        public int Insert(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Add(produtoModel);
            dataContext.SaveChanges();
            
            return produtoModel.ProdutoId;
        }

        // Alterar
        public void Update(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Update(produtoModel);
            dataContext.SaveChanges();
        }

        // Excluir
        public void Delete(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Remove(produtoModel);
            dataContext.SaveChanges();
        }


        public void Delete(int id)
        {
            var produtoModel = new ProdutoModel()
            {
                ProdutoId = id,
            };

            Delete(produtoModel);
        }


    }
}
