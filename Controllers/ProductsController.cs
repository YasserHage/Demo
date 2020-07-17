using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Demo.Repositories;
using Demo.Models;
using AutoMapper;
using Demo.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace Demo.Controllers{

    [Route("api/products/")]
    [ApiController]
    public class ProductsController : ControllerBase{

        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<ProductReadDto>> GetProducts()
        {
            var products = _repository.GetProducts();
            
            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));
        }

        [HttpGet("{id}", Name="GetProductById")]
        public ActionResult <ProductReadDto> GetProductById(int id)
        {
            var product = _repository.GetProductById(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProductReadDto>(product));
        }

        [HttpPost]
        public ActionResult <ProductReadDto> CreateProduct(ProductInsertDto NewProduct)
        {
            if (NewProduct == null)
            {
                return NotFound();
            }
            var product = _mapper.Map<Product>(NewProduct);
            _repository.CreateProduct(product);
            _repository.SaveChanges();

            var createdProduct = _mapper.Map<ProductReadDto>(product);
            return CreatedAtRoute(nameof(GetProductById),new{Id = createdProduct.id}, createdProduct);
            
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, ProductInsertDto changedProduct)
        {
            var oldProduct = _repository.GetProductById(id);
            if (oldProduct == null)
            {
                return NotFound();
            }

            _mapper.Map(changedProduct, oldProduct);

            _repository.UpdateProduct(oldProduct);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateProduct(int id, JsonPatchDocument<ProductInsertDto> changes)
        {
            var oldProduct = _repository.GetProductById(id);
            if (oldProduct == null)
            {
                return NotFound();
            }

            var oldProductInsertDto = _mapper.Map<ProductInsertDto>(oldProduct);
            changes.ApplyTo(oldProductInsertDto, ModelState);

            if (!TryValidateModel(oldProductInsertDto))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(oldProductInsertDto, oldProduct);

            _repository.PartialUpdateProduct(oldProduct);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = _repository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            _repository.DeleteProduct(product);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}