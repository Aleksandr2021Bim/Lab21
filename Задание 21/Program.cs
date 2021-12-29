using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Задание_21
{
    class Program
    {
        // работники сада по прямоугольному участку
        static int[,] pole;
        static object locker = new object();
        static void Main(string[] args)
        {
            pole = new int[4, 4];
            ThreadStart threadStart = new ThreadStart(sad1);
            Thread thread = new Thread(threadStart);
            thread.Start();
            sad2();

            for (int i = 0; i < 4; i++)
            {
                for (int j= 0; j < 4; j++)
                {
                    Console.WriteLine(pole[i, j]);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        // движение садовника первого
        static void sad1()
        {
            lock (locker)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (pole[i, j] == 0)
                            pole[i, j] = 1;
                        Thread.Sleep(1);
                        
                    }
                }
            }
        }

        // движение садовника второго
        static void sad2()
        {
          for (int i = 3; i > 0; i--)
                {
                    for (int j = 3; j >= 0; j--)
                    {
                        if (pole[j, i] == 1)
                            pole[j, i] = 2;
                        Thread.Sleep(1);

                    }
                }
            
        }

    }
}
