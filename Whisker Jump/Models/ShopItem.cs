﻿using System.Numerics;

namespace Whisker_Jump.Models
{
    public class ShopItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public bool IsPurchased { get; private set; }

        public ShopItem(string name, int price, string type)
        {
            Name = name;
            Price = price;
            Type = type;
            IsPurchased = false;
        }

        public bool Purchase(int fishCount)
        {
            if (!IsPurchased && fishCount >= Price)
            {
                IsPurchased = true;
                return true;
            }
            return false;
        }
    }
}