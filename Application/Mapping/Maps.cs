using AutoMapper;
using Domain.CommonRecords;
using Domain.Customers;
using Domain.OrderItems;
using Domain.Orders;
using Domain.Products;
using Shared.DTO.Address;
using Shared.DTO.Customers;
using Shared.DTO.OrderItems;
using Shared.DTO.Orders;
using Shared.DTO.Products;
using Shared.DTO.Quantity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class Maps : Profile
    {

        public Maps()
        {
            CreateMap<AddressRecord, AddressRecordDTO>().ReverseMap();
            CreateMap<AddressRecordDTO, AddressRecord>().ReverseMap();

            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<CustomerDTO, Customer>().ReverseMap();

            CreateMap<Customer, UpdateCustomerDTO>().ReverseMap();
            CreateMap<UpdateCustomerDTO, Customer>().ReverseMap();

            CreateMap<QuantityRecord, QuantityRecordDTO>().ReverseMap();
            CreateMap<QuantityRecordDTO, QuantityRecord>().ReverseMap();

            CreateMap<PriceRecord, PriceRecordDTO>().ReverseMap();
            CreateMap<PriceRecordDTO, PriceRecord>().ReverseMap();

            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderDTO, Order>().ReverseMap();

            CreateMap<Order, UpdateOrderDTO>().ReverseMap();
            CreateMap<UpdateOrderDTO, Order>().ReverseMap();

            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<OrderItemDTO, OrderItem>().ReverseMap();

            CreateMap<OrderItem, UpdateOrderItemDTO>().ReverseMap();
            CreateMap<UpdateOrderItemDTO, OrderItem>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();

            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<UpdateProductDTO, Product>().ReverseMap();

        }
    }
}
