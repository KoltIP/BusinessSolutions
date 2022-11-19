using AutoMapper;
using BusinessSolutions.Data.Entities;
using FluentValidation;

namespace BusinessSolutions.OrderItemServices.Models;

public class UpdateOrderItemModel
{
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = string.Empty;
    public int OrderId { get; set; }
}

public class UpdateOrderItemModelProfile : Profile
{
    public UpdateOrderItemModelProfile()
    {
        CreateMap<UpdateOrderItemModel, OrderItem>();
    }
}


//public class UpdateOrderItemModelValidator : AbstractValidator<UpdateOrderItemModel>
//{
//    public UpdateOrderItemModelValidator()
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