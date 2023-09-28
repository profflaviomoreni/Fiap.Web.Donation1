using Fiap.Web.Donation1.Models;

namespace Fiap.Web.Donation1.Repository
{
    public class ProdutoRepositoryXml : IProdutoRepository
    {
        public void Delete(ProdutoModel produtoModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ProdutoModel> FindAll()
        {
            throw new NotImplementedException();
        }

        public IList<ProdutoModel> FindAllByDisponivel(bool disponivel)
        {
            throw new NotImplementedException();
        }

        public IList<ProdutoModel> FindAllDisponivelDoUsuario(bool disponivel, int usuarioId)
        {
            throw new NotImplementedException();
        }

        public IList<ProdutoModel> FindAllDisponivelParaTroca(bool disponivel, int usuarioId)
        {
            throw new NotImplementedException();
        }

        public IList<ProdutoModel> FindAllWithTipo()
        {
            throw new NotImplementedException();
        }

        public IList<ProdutoModel> FindAllWithTipoAndUsuario()
        {
            throw new NotImplementedException();
        }

        public IList<ProdutoModel> FindAllWithTipoOrderByName()
        {
            return new List<ProdutoModel>();
        }

        public ProdutoModel FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ProdutoModel> FindByNome(string nome)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProdutoModel produtoModel)
        {
            throw new NotImplementedException();
        }

        public void Update(ProdutoModel produtoModel)
        {
            throw new NotImplementedException();
        }
    }
}
