﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Phone phone, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Phone.PhoneId == phone.PhoneId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Phone = phone,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Phone game)
        {
            lineCollection.RemoveAll(l => l.Phone.PhoneId == game.PhoneId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Phone.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Phone Phone { get; set; }
        public int Quantity { get; set; }
    }
}
