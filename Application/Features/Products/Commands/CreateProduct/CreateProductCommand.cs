
using Application.DTOs.Product;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<GenericResponse<ProductDTO>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public float price { get; set; }
    }
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, GenericResponse<ProductDTO>>
    {
        private readonly IRepositoryAsync<Product> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IRepositoryAsync<Product> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<ProductDTO>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product newProduct = _mapper.Map<CreateProductCommand, Product>(request);

            var product = await _repositoryAsync.CreateAsync(newProduct);
            await _repositoryAsync.SaveChangesAsync();

            return new GenericResponse<ProductDTO>(_mapper.Map<ProductDTO>(product));
        }
    }
}
