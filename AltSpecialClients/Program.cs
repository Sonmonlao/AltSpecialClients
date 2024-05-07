using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltSpecialClients
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество клиентов от 1 до 1000:\n");

            int allClients;
            while (true)
            {
                try
                {
                    allClients = Convert.ToInt32(Console.ReadLine());
                    if (allClients >= 1 && allClients <= 1000)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Количество клиентов должно быть от 1 до 1000. Пожалуйста, попробуйте еще раз.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный формат ввода. Пожалуйста, введите целое число.");
                }
            }

            Console.WriteLine("Введите номер клиента и его ник через пробел:");

            Dictionary<int, string> clientsDict = new Dictionary<int, string>();

            for (int i = 0; i < allClients; i++)
            {
                while (true)
                {
                    try
                    {
                        string client = Console.ReadLine();
                        string[] parts = client.Split(' ');

                        if (parts.Length != 2)
                        {
                            throw new FormatException("Номер и ник должны быть разделены пробелом.");
                        }

                        if (!char.IsDigit(client[0]))
                        {
                            throw new FormatException("Номер клиента должен начинаться с цифры.");
                        }

                        clientsDict.Add(Convert.ToInt32(parts[0]), parts[1]);
                        break;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            clientsDict = clientsDict.OrderBy(n => n.Key).ToDictionary(n => n.Key, n => n.Value);

            Dictionary<int, string> specialClients = new Dictionary<int, string>();

            foreach (KeyValuePair<int,string> client in clientsDict)
            {
                int number = client.Key;
                int sum = 0;
                for(int i = 1;i < number+1;i++) 
                {
                    if(number % i == 0)
                        {
                            sum += i;
                        }
                    else
                    {
                        continue;
                    }
                }
                if (sum % 2 != 0)
                {
                    specialClients.Add(client.Key, client.Value);
                }
                else { continue; }
            }

            Console.WriteLine("\nСписок особенных клиентов:");

            if (specialClients.Count > 0)
            {
                foreach(KeyValuePair<int, string> client in specialClients)
                {
                    Console.WriteLine(client.Key+" "+client.Value);
                }   
            }
            else
            {
                Console.WriteLine("empty");
            }
            Console.ReadKey();
        }
    }
}
