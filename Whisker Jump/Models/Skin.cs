using System.Numerics;

namespace Whisker_Jump.Models
{
    public class Skin
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int Price { get; set; }
        public bool IsPurchased { get; set; }

        public Skin(string name = "Default", string imagePath = "default_skin.png", int price = 0)
        {
            Name = name;
            ImagePath = imagePath;
            Price = price;
            IsPurchased = price == 0;
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

        public void ApplyTo(Character character)
        {
            character.CurrentSkin = this;
        }
    }
}