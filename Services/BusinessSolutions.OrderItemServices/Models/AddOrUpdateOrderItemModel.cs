using AutoMapper;
using BusinessSolutions.Data.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessSolutions.OrderItemServices.Models;

public class AddOrUpdateOrderItemModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = string.Empty;
    public int OrderId { get; set; }
}


public class AddOrUpdateOrderItemModelProfile : Profile
{
    public AddOrUpdateOrderItemModelProfile()
    {
        CreateMap<AddOrUpdateOrderItemModel, OrderItem>();
    }
}

//public class AddOrUpdateOrderItemModelValidator : AbstractValidator<AddOrUpdateOrderItemModel>
//{
//    public AddOrUpdateOrderItemModelValidator()
//    {
//        RuleFor(x => x.Name)
//            .NotEmpty().WithMessage("Name is required.")
//            .NotNull().WithMessage("Name can not be null")
//            .MaximumLength(50).WithMessage("Name is long.");
//        RuleFor(x => x.Quantity)
//           .NotEmpty().WithMessage("Quantity is required.");
//        RuleFor(x => x.Unit)
//           .NotEmpty().WithMessage("Unit is required.")
//           .NotNull().WithMessage("Unit can not be null")
//           .MaximumLength(50).WithMessage("Unit is long.");
//        RuleFor(x => x.OrderId)
//           .NotEmpty().WithMessage("OrderId is required.")
//           .NotEqual(x => 0);

//    }
//}