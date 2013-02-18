﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsentialTools.Models
{
    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }


    public class DefaultDiscountHelper : IDiscountHelper
    {
        private decimal discountSize;

        public DefaultDiscountHelper(decimal discountParam)
        {
            discountSize = discountParam;
        }

        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (discountSize / 100m * totalParam));
        }
    }

    public class FlexibleDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal totalParam)
        {
            decimal discount = totalParam > 100 ? 70 : 25;
            return (totalParam - (discount / 100m * totalParam));
        }
    }
}