using AutoMapper;
using BusinessSolutions.Data.Entities;
using BusinessSolutions.MVC.Models.OrderItem;
using BusinessSolutions.OrderServices.Models;
using FluentValidation;

namespace BusinessSolutions.MVC.Models.Order
{
    public class AddOrderRequest
    {
        public string Number { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int? ProviderId { get; set; }
        public List<OrderItemResponse> Content { get; set; }
    }

    //public class AddOrderRequestValidator : AbstractValidator<AddOrderRequest>
    //{
    //    public AddOrderRequestValidator()
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

    public class AddOrderRequestProfile : Profile
    {
        public AddOrderRequestProfile()
        {
            CreateMap<AddOrderRequest, AddOrderModel>();
        }
    }

}
