using Abp.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pos.Order;
using Pos.Orders.Dto;
using Pos.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Products
{
    public class ProductAppService : IProductAppService
    {
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<OrderItem> orderItemRepository;
        private readonly IMapper mapper;

        public ProductAppService(IRepository<Product> productRepository, IRepository<OrderItem> orderItemRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.orderItemRepository = orderItemRepository;
            this.mapper = mapper;
        }

        public List<ProductDto> GetAllProducts()
        {
            var result = productRepository.GetAll();
            return mapper.Map<List<ProductDto>>(result);
        }

        //Reduce qty in stock for a given product
        [ApiExplorerSettings(IgnoreApi = true)]
        public void UpdateProductQuantityInStock(List<OrderItemDto> orderItems)
        {

            foreach (var item in orderItems)
            {
                var product = productRepository.GetAll().FirstOrDefault(i => i.Id == item.Product.Id);
                var existingOrderItem = orderItemRepository.GetAll().AsNoTracking().FirstOrDefault(i => i.Id == item.Id);
                var existingQty = 0;
                //if order item is added for the first time
                if (existingOrderItem != null)
                {
                    existingQty = existingOrderItem.Quantity;
                }
                var placedQty = item.Quantity;
                var currentQtyInStock = product.ProductQtyInStock;
                var qtyToBeUpdated = 0;
                decimal newQty = 0;

                //check if qty is to be added or reduced
                if (placedQty < existingQty)
                {
                    //check qty to be added to stock
                    qtyToBeUpdated = existingQty - placedQty;
                    //add the qty to stock for relevant product
                    newQty = currentQtyInStock + qtyToBeUpdated;


                }
                else if (placedQty > existingQty)
                {
                    qtyToBeUpdated = placedQty - existingQty;
                    //reduce the qty to stock for relevant product
                    newQty = currentQtyInStock - qtyToBeUpdated;

                }
                else if (placedQty == existingQty)
                {

                    newQty = currentQtyInStock - placedQty;
                }

                //check if product is available in stock
                if (currentQtyInStock <= 0)
                {
                    throw new NoItemInStockException();
                }

                product.ProductQtyInStock = newQty;
                productRepository.Update(product);
            }


        }

    }
}
