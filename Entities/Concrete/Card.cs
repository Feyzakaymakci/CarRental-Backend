﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Card:IEntity
    {
        public int CardId { get; set; }
        public int CustomerId { get; set; }
        public string OwnerName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public decimal? Debts { get; set; }
    }
}
