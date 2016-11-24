using System;
using System.Linq;
using System.Collections.Generic;

using App.Entities;
using App.Models;
using System.Threading;

namespace App
{
    class Program
    {
        static ShopContext context = new ShopContext();

        static List<Goods> goods;

        static List<Goods> DisplayGoods(int catId, int manId)
        {
            string query = $"EXEC dbo.GetGoods ";
            query += (catId != -1) ? catId.ToString() : String.Empty;
            query += (manId != -1) ? catId.ToString() : String.Empty;

            List<Goods> goods = context.Database
                .SqlQuery<Goods>($"EXEC dbo.GetGoods {catId}")
                .ToList();

            return goods;
        }

        static void DisplayResult()
        {
            foreach (Goods g in goods)
                Console.WriteLine(g);
        }

        static void Main(string[] args)
        {
            var action = new Func<int, int, List<Goods>>(DisplayGoods);
            IAsyncResult result = action.BeginInvoke(1, -1, null, null);

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Main thread {0}", i);
            }

            goods = action.EndInvoke(result);

            var action2 = new Action(DisplayResult);
            IAsyncResult result2 = action2.BeginInvoke(null, null);

            for (int i = 10; i < 20; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Main thread {0}", i);
            }

            action2.EndInvoke(result2);
        }
    }
}
