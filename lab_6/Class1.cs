using System;
using System.Buffers;
using System.Diagnostics;

namespace lab_6
{
    public partial class Technics : Product
    {
        public virtual void Info()
        {
            Console.WriteLine($"ID:{id}");
            Console.WriteLine($"Brand:{brand}");
            Console.WriteLine($"Model:{model}");
            Console.WriteLine($"Release Year: {releaseY}");
            Console.WriteLine($"Term of service: {termOfService} years");
            Console.WriteLine($"Cost:{cost}$");
            Console.WriteLine(" ");
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "TECHNICS_TYPE " + base.ToString();
        }

        public void IsAs()
        {
            if (this is Tablet)
            {
                Console.WriteLine("Это планшет, успокойтесь.");
            }
            else
            {
                Console.WriteLine("Это не планшет, сейчас исправим");
                var tmp = this;
                tmp = this as Tablet;
                Console.WriteLine("Теперь это точно планшет");
            }
        }
    }

    class TechnicsExeption : NullReferenceException
    {
        public TechnicsExeption (string message)
            : base(message)
        { }
    }

    class LaboratoryExeption: ArgumentException
    {
        public LaboratoryExeption (string message)
            : base(message)
        { }
    }

    class ControllerExeption : Exception
    {
        public ControllerExeption(string message)
            :base(message)
        { }
    }
}

