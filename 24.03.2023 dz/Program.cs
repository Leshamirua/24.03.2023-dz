﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24._03._2023_dz
{
    
    abstract class Component
    {
        protected string name;
        protected string price;

        public Component(string name, string price)
        {
            this.name = name;
            this.price = price;
        }

        abstract public void Add(Component c);
        abstract public void Remove(Component c);
        abstract public void Print();
    }

    class Composite : Component
    {
        public List<Component> components = new List<Component>();

        public Composite(string name, string price) : base(name, price)
        {
            this.name = name;
            this.price = price;
        }
        public override void Add(Component c)
        {
            components.Add(c);
        }
        public override void Remove(Component c)
        {
            components.Remove(c);
        }
        public override void Print()
        {
            Console.WriteLine($"{name} - {price}");
            foreach (Component c in components)
            {
                Console.WriteLine(c);
            }
        }

    }

    class Leaf : Component
    {
        public Leaf(string name, string price) : base(name, price)
        {
            this.name = name;
            this.price = price;
        }
        public override void Add(Component c)
        {
            throw new NotImplementedException();
        }
        public override void Print()
        {
            throw new NotImplementedException();
        }
        public override void Remove(Component c)
        {
            throw new NotImplementedException();
        }
    }

    class Client
    {
        public void Print(Component c)
        {
            c.Print();
        }
        public void Add(Component c1, Component c2)
        {
            c1.Add(c2);
            c1.Print();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            
            Client client = new Client();
            Composite reception = new Composite("Приемная", "1000");
            reception.Add(new Leaf("Журнальный столик", "100"));
            reception.Add(new Leaf("Мягкий диван", "350"));
            reception.Add(new Leaf("Стол секретаря", "200"));

            Composite room1 = new Composite("10 столов", "1200");

            client.Add(reception, room1);

        }
    }
}
