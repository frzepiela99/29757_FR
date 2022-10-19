using System;

namespace HelloWorld
{
    abstract class Container<T>
    {
        protected int pointer = -1;
        protected T[] buffer = new T[10];
        protected int size = 10;
        public abstract void show();
        public abstract T pop();
        public abstract void push(T value);
        public Container() { }
        public Container(int size_)
        {
            if (size > 0)
            {
                buffer = new T[size_];
                size = size_;
            }
        }
        public void Clear()
        {
            buffer = new T[10];
            pointer = -1;
        }
        public int GetCount()
        {
            return pointer + 1;
        }
        public Boolean IsEmpty()
        {
            if (pointer == -1)
                return true;
            else
                return false;
        }
        public Boolean IsFull()
        {
            if (pointer == size - 1)
                return true;
            else
                return false;
        }
    }
    class Kolejka<T> : Container<T>
    {
        public Kolejka(int size) : base(size)
        {

        }
        public override T pop()
        {
            T wartosc = buffer[0];
            for (int i = 1; i <= pointer; i++)
            {
                buffer[i - 1] = buffer[i];
            }
            pointer--;
            if (pointer < -1)
                pointer = -1;
            return wartosc;
        }

        public override void push(T value)
        {
            pointer++;
            if (pointer < size)
                buffer[pointer] = value;
            else
                pointer = size - 1;
        }

        public override void show()
        {
            Console.WriteLine("Kolejka");
            for (int i = 0; i <= pointer; i++)
            {
                Console.Write(buffer[i]);
                Console.Write(" ");
            }
            Console.WriteLine(" ");
        }
    }
    class Stos<T> : Container<T>
    {
        public Stos(int size) : base(size)
        {

        }



        public override T pop()
        {
            if (pointer < 0)
                pointer = 0;
            T val = buffer[pointer];
            pointer--;
            return val;
        }

        public override void push(T value)
        {
            pointer++;
            if (pointer < size)
                buffer[pointer] = value;
            else
                pointer = size - 1;
        }

        public override void show()
        {

            Console.WriteLine("Stos");
            for (int i = 0; i <= pointer; i++)
            {
                Console.Write(buffer[i]);
                Console.Write(" ");
            }
            Console.WriteLine(" ");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Filip Rzepiela Grupa P2");

            Kolejka<int> kolejka1 = new Kolejka<int>(4);
            kolejka1.push(1);
            kolejka1.push(5);
            kolejka1.show();
            kolejka1.push(7);
            kolejka1.show();
            kolejka1.push(9);
            kolejka1.show();
            kolejka1.pop();
            kolejka1.show();
            Console.WriteLine(kolejka1.GetCount());
            kolejka1.push(4);
            kolejka1.push(5);
            kolejka1.show();
            Console.WriteLine(kolejka1.GetCount());
            kolejka1.Clear();
            kolejka1.show();
            Console.WriteLine(kolejka1.GetCount());
            Console.WriteLine(kolejka1.IsEmpty());
            kolejka1.push(2);
            Console.WriteLine(kolejka1.IsEmpty());
            kolejka1.push(2);
            kolejka1.push(2);
            kolejka1.push(2);
            kolejka1.push(2);
            kolejka1.push(2);
            kolejka1.push(2);
            kolejka1.push(2);
            kolejka1.push(2);
            kolejka1.push(2);
            kolejka1.show();
            Console.WriteLine(kolejka1.GetCount());
            Console.WriteLine(kolejka1.IsFull());

            Stos<int> stosik1 = new Stos<int>(3);
            stosik1.push(2);
            stosik1.push(4);
            stosik1.show();
            stosik1.push(6);
            stosik1.show();
            stosik1.pop();
            stosik1.show();
            Console.WriteLine(stosik1.GetCount());
            Console.WriteLine(stosik1.IsFull());
            stosik1.pop();
            stosik1.pop();
            stosik1.show();
            Console.WriteLine(stosik1.IsEmpty());
        }
    }
}