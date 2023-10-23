using System;
using System.Collections.Generic;
using System.IO;

public class Order
{
    private string shape;
    private string size;
    private string flavor;
    private int quantity;
    private string glazing;
    private string decoration;

    public void StartOrder()
    {
        Console.WriteLine("Добро пожаловать в CandyDanya! Что бы вы хотели заказать?");

        shape = ShowMenuAndGetSelection("Форма", new List<string> { "Круглый ", "Прямоугольный","Ваша форма(обсудить по горячей линии 89778125252)" });
        size = ShowMenuAndGetSelection("Размер", new List<string> { "Маленький", "Средний", "Большой","Огромный" });
        flavor = ShowMenuAndGetSelection("Вкус", new List<string> { " Шоколадный", "Ванильный", " Фруктовый","Ореховый","Веганский" });

        Console.Write("Введите количество: ");
        quantity = int.Parse(Console.ReadLine());

        glazing = ShowMenuAndGetSelection("Глазурь", new List<string> { "Шоколадная", "Сливочная", "Фруктовая" });
        decoration = ShowMenuAndGetSelection("Декор", new List<string> { "Цветы", "Фигурки", " Шоколадные детали", "Несъедобные детали(обсудить по горячей линии 89778125252)" });

        Console.WriteLine("Спасибо за заказ! Итоговая цена: " + CalculatePrice());

        SaveOrderToFile();

        Console.WriteLine(" Хотите оформить еще один заказ? Это 2?");
        string answer = Console.ReadLine().ToLower();

        if (answer == "y")
        {
            StartOrder();
        }
        else
        {
            Console.WriteLine("Спасибо за покупку! ");
        }
    }

    private string ShowMenuAndGetSelection(string menuItem, List<string> submenuItems)
    {
        Console.WriteLine("Выберите " + menuItem);

        int selectedIdx = 0;
        int maxIdx = submenuItems.Count - 1;

        while (true)
        {
            for (int i = 0; i <= maxIdx; i++)
            {
                if (i == selectedIdx)
                {
                    Console.WriteLine("> " + submenuItems[i]);
                }
                else
                {
                    Console.WriteLine("  " + submenuItems[i]);
                }
            }

            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.UpArrow)
            {
                if (selectedIdx > 0)
                {
                    selectedIdx--;
                }
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (selectedIdx < maxIdx)
                {
                    selectedIdx++;
                }
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                return submenuItems[selectedIdx];
            }
        }
    }

    private decimal CalculatePrice()
    {
        decimal price = 0;

        if ("Круглый")
        {
            price += 300;
        }
        else if ("Прямоугольный")
        {
            price += 250;
        }
        else if ("Ваша форма")
        {
            price += 600;
        }

        if ("Маленький")
        {
            price += 700;
        }
        else if ("Средний")
        {
            price += 1500;
        }
        else if ("Большой")
        {
            price += 2000;
        }
        else if  ("Огромный")
        {
            price += 4000;
        }

      

        return price;
    }

    private void SaveOrderToFile()
    {
        string filename = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt";
        using (StreamWriter sw = new StreamWriter(filename))
        {
            sw.WriteLine("Форма");
            sw.WriteLine("Размер");
            sw.WriteLine("Вкус:");
            sw.WriteLine("Количество");
            sw.WriteLine("Глазурь");
            sw.WriteLine("Декор");
        }

        Console.WriteLine("Заказ сохранен в файл " + filename);
    }
}

