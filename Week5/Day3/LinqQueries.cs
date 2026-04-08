using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqCodeTemplate
{
    internal class Product
    {
        public int ProCode { get; set; }
        public string ProName { get; set; }
        public string ProCategory { get; set; }
        public double ProMrp { get; set; }

        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{ProCode=1001,ProName="Colgate-100gm",ProCategory="FMCG",ProMrp=55 },
                new Product{ProCode=1002,ProName="Colgate-50gm",ProCategory="FMCG",ProMrp=30 },
                new Product{ProCode=1009,ProName="DaburRed-100gm",ProCategory="FMCG",ProMrp=50 },
                new Product{ProCode=1006,ProName="DaburRed-50gm",ProCategory="FMCG",ProMrp=28 },
                new Product{ProCode=1008,ProName="Himalaya Neem Face Wash",ProCategory="FMCG",ProMrp=70 },
                new Product{ProCode=1007,ProName="Niviea Face Wash",ProCategory="FMCG",ProMrp=120 },
                new Product{ProCode=1010,ProName="Daawat-Basmati",ProCategory="Grain",ProMrp=130 },
                new Product{ProCode=1011,ProName="Delhi Gate-Basmati",ProCategory="Grain",ProMrp=120 },
                new Product{ProCode=1014,ProName="Saffola-Oil",ProCategory="Edible-Oil",ProMrp=160 },
                new Product{ProCode=1016,ProName="Fortune-Oil",ProCategory="Edible-Oil",ProMrp=150 },
                new Product{ProCode=1018,ProName="Nescafe",ProCategory="FMCG",ProMrp=70 },
                new Product{ProCode=1019,ProName="Bru",ProCategory="FMCG",ProMrp=90},
                new Product{ProCode=1015,ProName="Parachut",ProCategory="Edible-Oil",ProMrp=60}
            };
        }
    }

    internal class AllLinqQueries
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();

            Console.WriteLine("========== Problem 1: Products with Category FMCG ==========");
            var result1 = products.Where(p => p.ProCategory == "FMCG").ToList();
            foreach (var item in result1)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProCategory}\t{item.ProMrp}");
            }

            Console.WriteLine("\n========== Problem 2: Products with Category Grain ==========");
            var result2 = products.Where(p => p.ProCategory == "Grain").ToList();
            foreach (var item in result2)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProCategory}\t{item.ProMrp}");
            }

            Console.WriteLine("\n========== Problem 3: Products Sorted by Product Code (Ascending) ==========");
            var result3 = products.OrderBy(p => p.ProCode).ToList();
            foreach (var item in result3)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProCategory}\t{item.ProMrp}");
            }

            Console.WriteLine("\n========== Problem 4: Products Sorted by Product Category (Ascending) ==========");
            var result4 = products.OrderBy(p => p.ProCategory).ToList();
            foreach (var item in result4)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProCategory}\t{item.ProMrp}");
            }

            Console.WriteLine("\n========== Problem 5: Products Sorted by Product Mrp (Ascending) ==========");
            var result5 = products.OrderBy(p => p.ProMrp).ToList();
            foreach (var item in result5)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProCategory}\t{item.ProMrp}");
            }

            Console.WriteLine("\n========== Problem 6: Products Sorted by Product Mrp (Descending) ==========");
            var result6 = products.OrderByDescending(p => p.ProMrp).ToList();
            foreach (var item in result6)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProCategory}\t{item.ProMrp}");
            }

            Console.WriteLine("\n========== Problem 7: Products Grouped by Product Category ==========");
            var result7 = products.GroupBy(p => p.ProCategory);
            foreach (var group in result7)
            {
                Console.WriteLine($"\nCategory: {group.Key}");
                foreach (var item in group)
                {
                    Console.WriteLine($"  {item.ProCode}\t{item.ProName}\t{item.ProMrp}");
                }
            }

            Console.WriteLine("\n========== Problem 8: Products Grouped by Product Mrp ==========");
            var result8 = products.GroupBy(p => p.ProMrp);
            foreach (var group in result8)
            {
                Console.WriteLine($"\nMrp: {group.Key}");
                foreach (var item in group)
                {
                    Console.WriteLine($"  {item.ProCode}\t{item.ProName}\t{item.ProCategory}");
                }
            }

            Console.WriteLine("\n========== Problem 9: Product with Highest Price in FMCG Category ==========");
            var fmcgProducts = products.Where(p => p.ProCategory == "FMCG").ToList();
            var result9 = fmcgProducts.OrderByDescending(p => p.ProMrp).FirstOrDefault();
            if (result9 != null)
            {
                Console.WriteLine($"{result9.ProCode}\t{result9.ProName}\t{result9.ProCategory}\t{result9.ProMrp}");
            }

            Console.WriteLine("\n========== Problem 10: Total Count of Products ==========");
            var result10 = products.Count();
            Console.WriteLine($"Total Products: {result10}");

            Console.WriteLine("\n========== Problem 11: Total Count of Products with Category FMCG ==========");
            var result11 = products.Count(p => p.ProCategory == "FMCG");
            Console.WriteLine($"Total FMCG Products: {result11}");

            Console.WriteLine("\n========== Problem 12: Maximum Price ==========");
            var result12 = products.Max(p => p.ProMrp);
            Console.WriteLine($"Max Price: {result12}");

            Console.WriteLine("\n========== Problem 13: Minimum Price ==========");
            var result13 = products.Min(p => p.ProMrp);
            Console.WriteLine($"Min Price: {result13}");

            Console.WriteLine("\n========== Problem 14: Check if All Products are Below Mrp Rs.30 ==========");
            var result14 = products.All(p => p.ProMrp < 30);
            Console.WriteLine($"All products below Rs.30: {result14}");

            Console.WriteLine("\n========== Problem 15: Check if Any Products are Below Mrp Rs.30 ==========");
            var result15 = products.Any(p => p.ProMrp < 30);
            Console.WriteLine($"Any products below Rs.30: {result15}");

            Console.ReadLine();
        }
    }
}