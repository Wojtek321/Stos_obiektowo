using System;
using System.Linq.Expressions;

namespace Stos
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Stos stos1 = new Stos();
            Stos stos2 = new Stos();
            stos2.Init(10);
            stos1.Init(10);

            int liczba;
            for (int i = 0; i < 10;)
            {
                try
                {
                    Console.Write($"Wprowadz {i + 1}. liczbe do stosu: ");
                    liczba = Convert.ToInt32(Console.ReadLine());
                    stos1.push(liczba);
                    Console.Clear();
                    i++;
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Nalezy podawac tylko liczby calkowite.");
                }
            }

            for (int i = 0; i < 10; i++)
            {
                liczba = stos1.top();
                stos2.push(liczba);
                stos1.pop();
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(stos2.top());
                liczba = stos2.top();
                stos1.push(liczba);
                stos2.pop();
            }
        }
    }

    class Stos
    {
        private int size;
        private int count;
        private int[] array;

        public void Init(int size)
        {
            this.count = 0;
            this.size = size;
            this.array = new int[size];
        }
        
        public bool empty()
        {
            return this.count == 0;
        }

        public bool full()
        {
            return this.count == size;
        }

        public void push(int n)
        {
            if (!full())
            {
                this.array[count] = n;
                this.count++;
            }
            else
            {
                Console.WriteLine("Stos jest pelny.");
            }
                
        }

        public void pop()
        {
            if (!empty())
            {
                this.array[count - 1] = 0;
                this.count--;
            }
            else
            {
                Console.WriteLine("Stos jest pusty");
            }
            
        }

        public int top()
        {
            if (!empty())
            {
                return this.array[count - 1];
            }
            else
            {
                return int.MinValue;
            }
        }
    }
}