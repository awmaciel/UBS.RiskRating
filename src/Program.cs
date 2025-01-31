using System;
using System.Collections.Generic;
using System.Globalization;
using UBS.RiskRating.Interface;
using UBS.RiskRating.Model;

namespace UBS.RiskRating
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
            Console.Write("Enter the reference date (mm/dd/aaaa): ");
            DateTime referenceDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

            
            Console.Write("Enter the number of negotiations: ");
            int n = int.Parse(Console.ReadLine());

            
            List<Negotiation> negotiations = new List<Negotiation>();

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Inform the negotiation {i + 1} ( value sector date): ");
                var inputs = Console.ReadLine().Split(' ');
                double value = double.Parse(inputs[0]);
                string setor = inputs[1];
                DateTime paymentDate = DateTime.ParseExact(inputs[2], "MM/dd/yyyy", CultureInfo.InvariantCulture);

                negotiations.Add(new Negotiation
                {
                    Value = value,
                    Sector = setor,
                    NextPaymentDate = paymentDate
                });
            }

            var categories = new List<ICategory>
            {
                new ExpiredCategory(referenceDate),
                new HighRiskCategory(),
                new MediumRiskCategory()
            };

            foreach (var negotiation in negotiations)
            {
                string category = null;
                foreach (var c in categories)
                {
                    category = c.Sort(negotiation);
                    if (category != null)
                        Console.WriteLine(category);
                }
            }
            Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("There was an error during execution, please check if the parameters were passed correctly");
                Console.WriteLine("Start the application and run it again");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine($"Error description: { ex.Message }");

                Console.ReadKey();
            }
        }

    }
}

