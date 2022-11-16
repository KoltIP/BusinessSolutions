using AutoMapper;
using BusinessSolutions.MVC.Models.OrderItem;
using BusinessSolutions.OrderServices.Models;

namespace BusinessSolutions.MVC.Models.Order;

public class UpdateOrderRequest
{
    public string Number { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int ProviderId { get; set; }
    public List<OrderItemResponse> Content { get; set; }
}

//public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
//{
//    public UpdateOrderRequestValidator()
//    {
//        RuleFor(x => x.Number)
//            .NotEmpty().WithMessage("Number is required.")
//            .MaximumLength(50).WithMessage("Number is long.");
//        RuleFor(x => x.Date)
//            .NotEmpty().WithMessage("Date can not be empty")
//            .NotNull().WithMessage("Date can not be null");
//        RuleFor(x => x.ProviderId)
//            .NotEmpty().WithMessage("Provider Id can not be empty")
//            .NotNull().WithMessage("Provider Id can not be null");
//    }
//}

public class UpdateOrderRequestProfile : Profile
{
    public UpdateOrderRequestProfile()
    {
        CreateMap<UpdateOrderRequest, UpdateOrderModel>();
    }
}

