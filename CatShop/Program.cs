using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatShop
{
    class Cat
    {
        public Cat(string nickname, int age, string gender, int price)
        {
            Nickname = nickname;
            Age = age;
            Gender = gender;
            Price = price;
        }

        public string Nickname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Price { get; set; }
        public int Energy { get; set; } = 100;
        public int Happiness { get; set; } = 50;
        public int MealQuantity { get; set; } = 0;

        public void Play()
        {
            if (Energy > 0 && Happiness < 100)
            {
                Energy -= 5;
                Happiness += 5;
            }
            else
            {
                Energy = 0;
                Happiness = 100;
                Console.WriteLine("Cat must sleep");
            }
        }
        public void Sleep()
        {
            if (Energy < 50)
            {
                Energy += 50;
            }
            else
            {
                Energy = 100;
            }
            if (Happiness > 0)
            {
                Happiness -= 10;
            }
            else
            {
                Happiness = 0;
            }
        }
        public void Eat()
        {
            if (Energy < 100 && Happiness < 100)
            {
                Happiness += 2;
                Energy += 5;
            }
            else if (Energy < 100 && Happiness == 100)
            {
                Happiness = 100;
                Energy += 5;
            }
            else if (Energy == 100 && Happiness < 100)
            {
                Happiness += 2;
                Energy = 100;
            }
            else
            {
                Happiness = 100;
                Energy = 100;
            }
            MealQuantity += 1;
            Price += 1;
        }
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("--------CAT--------");
            Console.WriteLine($"Nickname: {Nickname}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Energy: {Energy}");
            Console.WriteLine($"Happiness: {Happiness}");
            Console.WriteLine($"Price: ${Price}");
        }
    }
    class CatHouse
    {
        public Cat[] Cats { get; set; }
        public int CatCount { get; set; }

        public void AddCat(ref Cat cat)
        {
            Cat[] temp = new Cat[++CatCount];
            if (Cats != null)
            {
                Cats.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = cat;
            Cats = temp;
        }
        public int TotalMealQuantity()
        {
            int totalQuantity = 0;
            if (Cats != null)
            {
                foreach (var cat in Cats)
                {
                    totalQuantity += cat.MealQuantity;
                }
            }
            return totalQuantity;
        }
        public int GetTotalPrice()
        {
            int totalPrice = 0;
            if (Cats != null)
            {
                foreach (var cat in Cats)
                {
                    totalPrice += cat.Price;
                }
            }
            return totalPrice;
        }
        public void ShowCats()
        {
            if (Cats != null)
            {
                foreach (var cat in Cats)
                {
                    cat.Show();
                }
            }
        }

    }
    class PetShop
    {
        public PetShop(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int TotalPrice { get; set; } = default;
        public int TotalMealQuantity { get; set; } = default;
        public CatHouse[] CatHouses { get; set; }
        public int CatHouseCount { get; set; }

        public void AddCatHouse(ref CatHouse catHouse)
        {
            CatHouse[] temp = new CatHouse[++CatHouseCount];
            if (CatHouses != null)
            {
                CatHouses.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = catHouse;
            CatHouses = temp;
        }
        public void CalculateTotalPrice()
        {
            if (CatHouses!=null)
            {
                foreach (var item in CatHouses)
                {
                    TotalPrice += item.GetTotalPrice();
                }
            }
        }
        public void CalculateTotalMealQuantity()
        {
            if (CatHouses!=null)
            {
                foreach (var item in CatHouses)
                {
                    TotalMealQuantity += item.TotalMealQuantity();
                }
            }
        }
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------PETSHOP--------");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"CatHouse count: {CatHouseCount}");
            Console.WriteLine($"Total price of cats: ${TotalPrice}");
            Console.WriteLine($"Total meal quantity: {TotalMealQuantity}");
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Cat c1 = new Cat("Kitty", 2, "Female", 10);
            Cat c2 = new Cat("Bob", 3, "Male", 5);
            c1.Show();
            for (int i = 0; i < 10; i++)
            {
                c1.Play();
                c2.Play();
            }
            //c1.Show();
            c1.Sleep();
            //c1.Show();
            c1.Eat();
            //c1.Show();

            CatHouse ch1 = new CatHouse();
            ch1.AddCat(ref c1);
            ch1.AddCat(ref c2);
            ch1.ShowCats();
            PetShop ps1 = new PetShop("PetSHOP");
            ps1.AddCatHouse(ref ch1);
            ps1.CalculateTotalMealQuantity();
            ps1.CalculateTotalPrice();
            ps1.Show();
        }
    }
}
