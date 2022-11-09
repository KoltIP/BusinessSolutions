﻿using AutoMapper;
using BusinessSolutions.Data.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessSolutions.OrderServices.Models
{
    public class AddOrderModel
    {
        public string Number { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
    }

    //public class AddOrderModelValidator : AbstractValidator<AddOrderModel>
    //{
    //    public AddOrderModelValidator()
    //    {
    //        RuleFor(x => x.Number)
    //            .NotEmpty().WithMessage("Number is required.")
    //            .NotNull().WithMessage("Number can not be null")
    //            .MaximumLength(50).WithMessage("Number is long.");
    //        RuleFor(x => x.Date)
    //           .NotEmpty().WithMessage("Date is required.")
    //           .NotNull().WithMessage("Date can not be null");
    //        RuleFor(x => x.ProviderId)
    //           .NotEmpty().WithMessage("Provider Id is required.")
    //           .NotNull().WithMessage("Provider Id can not be null");
    //    }
    //}

    public class AddOrderModelProfile : Profile
    {
        public AddOrderModelProfile()
        {
            CreateMap<AddOrderModel, Order>();
        }
    }

}