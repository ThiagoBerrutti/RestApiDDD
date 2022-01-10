using RestApiModeloDDD.Application.Dtos;
using RestApiModeloDDD.Domain.Entities;
using RestApiModeloDDD.Infrastructure.CrossCutting.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RestApiModeloDDD.Infrastructure.CrossCutting.Mapper
{
    public class MapperCliente : IMapperCliente
    {
        public Cliente MapperDtoToEntity(ClienteDto clienteDto)
        {
            Cliente cliente = new Cliente
            {
                Id = clienteDto.Id,
                Nome = clienteDto.Nome,
                Sobrenome = clienteDto.Sobrenome,
                Email = clienteDto.Email
            };

            return cliente;
        }

        public ClienteDto MapperEntityToDto(Cliente cliente)
        {
            ClienteDto clienteDto = new ClienteDto
            {
                Id = cliente.Id,
                Email = cliente.Email,
                Nome = cliente.Nome,
                Sobrenome = cliente.Sobrenome
            };

            return clienteDto;
        }

        public IEnumerable<ClienteDto> MapperListEntityToDto(IEnumerable<Cliente> clientes)
        {
            IEnumerable<ClienteDto> clientesDto = clientes.Select(c => new ClienteDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Sobrenome = c.Sobrenome,
                Email = c.Email
            });

            return clientesDto;
        }
    }
}