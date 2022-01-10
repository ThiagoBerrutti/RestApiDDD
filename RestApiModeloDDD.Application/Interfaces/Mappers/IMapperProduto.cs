using RestApiModeloDDD.Application.Dtos;
using RestApiModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace RestApiModeloDDD.Application.Interfaces.Mappers
{
    public interface IMapperProduto
    {
        Produto MapperDtoToEntity(ProdutoDto produtoDto);

        IEnumerable<ProdutoDto> MapperListEntityToDto(IEnumerable<Produto> produtos);

        ProdutoDto MapperEntityToDto(Produto produto);
    }
}