using System;

namespace NSI_01_FR
{
    abstract class Container
    {
        protected int pointer = -1;
        protected int[] buffer = new int[10];
        public abstract int pop();
        public abstract void push(int value);
        public abstract void show();

        public void clear()
        {
            buffer = new int[10];
            pointer = -1;
        }

        public int getcount()
        {
            return pointer + 1;
        }

        public Boolean isempty()
        {
            if (pointer == -1)
                return true;
            else
                return false;
        }

        public Boolean isfull()
        {
            if (pointer + 1 == 10)
                return true;
            else
                return false;
        }

    }
    class Kolejka : Container
    {
        public override int pop()
        {
            int tmp = buffer[0];
            for (int i = 1; i <= pointer; i++)
            {
                buffer[i - 1] = buffer[i];
            }
            pointer--;
            if (pointer < -1)
            {
                pointer = -1;
            }
            return tmp;
        }
        public override void push(int value)
        {
            pointer++;
            if (pointer < 10)
            {
                buffer[pointer] = value;
            }
            else
            {
                pointer--;
            }
        }

        public override void show()
        {
            Console.Write("Kolejka: ");
            for (int i = 0; i <= pointer; i++)
            {
                Console.Write(buffer[i]);
                Console.Write("  ");
            }
            Console.WriteLine("  ");
        }
    }
    class Stos : Container
    {
        public override void push(int value)
        {
            pointer++;
            if (pointer < 10)
            {
                buffer[pointer] = value;
            }
            else
            {
                pointer--;
            }
        }

        public override int pop()
        {

            if (pointer < 0)
            {
                pointer = 0;
            }
            int tmp1 = buffer[pointer];
            pointer--;
            return tmp1;
        }

        public override void show()
        {
            Console.Write("Stos: ");
            for (int i = 0; i <= pointer; i++)
            {
                Console.Write(buffer[i]);
                Console.Write("  ");
            }
            Console.WriteLine("  ");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Filip Rzepiela Grupa P2");

            Kolejka kolejka1 = new Kolejka();
            kolejka1.push(1);
            kolejka1.push(5);
            kolejka1.show();
            kolejka1.push(7);
            kolejka1.show();
            kolejka1.push(9);
            kolejka1.show();
            kolejka1.pop();
            kolejka1.show();
            Console.WriteLine(kolejka1.getcount());
            kolejka1.push(4);
            kolejka1.push(5);
            kolejka1.show();
            Console.WriteLine(kolejka1.getcount());
            kolejka1.clear();
            kolejka1.show();
            Console.WriteLine(kolejka1.getcount());
            Console.WriteLine(kolejka1.isempty());
            kolejka1.push(2);
            Console.WriteLine(kolejka1.isempty());
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
            Console.WriteLine(kolejka1.getcount());
            Console.WriteLine(kolejka1.isfull());

            Stos stosik1 = new Stos();
            stosik1.push(2);
            stosik1.push(4);
            stosik1.show();
            stosik1.push(6);
            stosik1.show();
            stosik1.pop();
            stosik1.show();
            Console.WriteLine(stosik1.getcount());
            Console.WriteLine(stosik1.isfull());
            stosik1.pop();
            stosik1.pop();
            stosik1.show();
            Console.WriteLine(stosik1.isempty());
        }
    }
}