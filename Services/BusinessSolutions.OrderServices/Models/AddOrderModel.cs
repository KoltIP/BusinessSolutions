﻿using System;
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
}
