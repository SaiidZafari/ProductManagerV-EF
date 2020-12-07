using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using ProductManagerV_EF.Model;

namespace ProductManagerV_EF.Domain.Product
{
    class ProductMethods
    {
        //var db = new AppDbContext();

        public static string AddName(int left, int top)
        {
            string name;
            Regex nameRegex = new Regex(@"^[A-Za-z][a-zA-Z0-9]*");
            do
            {
                Console.SetCursorPosition(left + 18, top + 4);
                Console.WriteLine("                        ");
                Console.SetCursorPosition(left + 18, top + 4);
                name = Console.ReadLine()?.ToUpper();
            } while (!nameRegex.IsMatch(name ?? string.Empty));

            return name;
        }

        public static int AddPrice(int left, int top)
        {
            Regex priceRegex = new Regex(@"^[0-9]+$");
            string priceTemp;
            do
            {
                Console.SetCursorPosition(left + 18, top + 6);
                Console.WriteLine("                           ");
                Console.SetCursorPosition(left + 18, top + 6);
                priceTemp = Console.ReadLine();

            } while (!priceRegex.IsMatch(priceTemp ?? string.Empty));

            var price = int.Parse(priceTemp);
            return price;
        }

        public static string AddMaterial(int left, int top)
        {
            string material;
            Regex nameRegex = new Regex(@"^[A-Za-z][a-zA-Z0-9]*");
            do
            {
                Console.SetCursorPosition(left + 58, top + 2);
                Console.WriteLine("                                               ");
                Console.SetCursorPosition(left + 58, top + 2);
                material = Console.ReadLine()?.ToUpper();
            } while (!nameRegex.IsMatch(material ?? string.Empty));

            return material;
        }

        public static string AddColor(int left, int top)
        {
            string color;
            Regex nameRegex = new Regex(@"^[A-Za-z][a-zA-Z0-9]*");
            do
            {
                Console.SetCursorPosition(left + 58, top + 4);
                Console.WriteLine("                                               ");
                Console.SetCursorPosition(left + 58, top + 4);
                color = Console.ReadLine()?.ToUpper();
            } while (!nameRegex.IsMatch(color ?? string.Empty));

            return color;
        }

        public static string AddDescription(int left, int top)
        {
            string description;
            Regex descriptionRegex = new Regex(@"^[A-Za-z][a-zA-Z0-9]*");
            do
            {
                Console.SetCursorPosition(left + 58, top + 6);
                Console.WriteLine("                               ");
                Console.SetCursorPosition(left + 58, top + 6);
                description = Console.ReadLine();
            } while (!descriptionRegex.IsMatch(description ?? string.Empty));

            return description;
        }

        public static void MessageByAction(int successRow, int left, int top, string action)
        {

            if (successRow > 0)
            {
                Console.SetCursorPosition(left, top + 10);
                Console.Write($" This Article is {action} !");
                Thread.Sleep(2000);
            }
            else
            {
                Console.SetCursorPosition(left, top + 10);
                Console.Write($" This Article dosen't {action } !");
                Thread.Sleep(2000);
            }

            Console.SetCursorPosition(left, top + 10);
            Console.WriteLine("                                      ");
        }

    }
}
