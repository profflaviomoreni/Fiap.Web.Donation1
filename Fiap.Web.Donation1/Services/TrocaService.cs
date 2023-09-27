using Fiap.Web.Donation1.Repository;

namespace Fiap.Web.Donation1.Services
{
    public class TrocaService
    {

        private readonly ProdutoRepository produtoRepository;

        private readonly TrocaRepository trocaRepository;

        public TrocaService(ProdutoRepository _produtoRepository, TrocaRepository _trocaRepository)
        {
            produtoRepository = _produtoRepository;
            trocaRepository = _trocaRepository;
        }

        public void TrocarProdutos(Models.TrocaModel trocaModel)
        {
            var produto1 = produtoRepository.FindById(trocaModel.ProdutoId1);
            var produto2 = produtoRepository.FindById(trocaModel.ProdutoId2);

            if (produto1.Disponivel == false)
            {
                throw new Exception("Produto selecionado indisponível");
            }

            if (produto2.Disponivel == false)
            {
                throw new Exception("O seu produto já foi trocado");
            }

            if ((produto2.Valor / produto1.Valor) < 0.9)
            {
                throw new Exception("O seu produto tem o valor menor que 90% do produto selecionado");
            }

            produto1.Disponivel = false;
            produtoRepository.Update(produto1);

            produto2.Disponivel = false;
            produtoRepository.Update(produto2);

            trocaModel.Status = Models.TrocaStatus.Iniciado;
            trocaRepository.Insert(trocaModel);
        }

    }
}
