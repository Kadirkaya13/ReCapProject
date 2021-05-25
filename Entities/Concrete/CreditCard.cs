using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard:IEntity
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string CardholderFirstName { get; set; }
        public string CardholderLastName { get; set; }
        public string Cvc { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal MoneyInCard { get; set; }
        public int FindeksNote { get; set; }

    }
}
