using System;
using System.Buffers;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Diagnostics;
// var 5

namespace lab_6
{
    interface ISale
    {
        void CostOnSale();
    }

    public class Product
    {
        public int id;
        public int cost;

        public override string ToString()
        {
            return "PRODUCT_TYPE " + base.ToString();
        }
    }

    public partial class Technics : Product
    {
        public string brand;
        public string model;
        public int termOfService;
        public int releaseY;
    }

    public class Printer : Technics, ISale
    {
        public static int amount;
        public void CostOnSale()
        {
            int coSale;
            coSale = cost - (60 * 100 / cost);
            Console.WriteLine($"Cost on sale: {coSale}");
        }

        new public string ToString()      
        {
            return "PRINTER_TYPE " + base.ToString();
        }

        public Printer(int c, string b, string m,int y)   
        {
            if(amount>=2)
            {
              // throw new IndexOutOfRangeException("Склад для принтеров переполнен.");  //IndexOutOfRange
            }
            else
            {
                amount++;
            }
            if(c==0)
            {
               //throw new TechnicsExeption("Неверный формат цены.");    //TechnicsExeption
            }
            else
            {
                cost = c;
            }
            
            brand = b;
            model = m;
            Random rnd = new Random();
            id = rnd.Next();
            termOfService = 3;
            releaseY = y;
        }

        public virtual void IAmPrinting(Object elem)
        {
            Console.WriteLine(elem.GetType());
            Console.WriteLine(elem.ToString());
        }
    }

    sealed public class Scaner : Technics, ISale 
    {
        public static int amount;
        public void CostOnSale()
        {
            int coSale;
            Debug.Assert(cost != 666, "Мне не нравится это число.");
                coSale = cost - (25 * 100 / cost);
                Console.WriteLine($"Cost on sale: {coSale}");
           
        }

        new public string ToString()
        {
            return "SCANER_TYPE_SEALED " + base.ToString();
        }

        public Scaner(int c, string b, string m, int y)
        {
            amount++;
            cost = c;
            brand = b;
            model = m;
            termOfService = 5;
            Random rnd = new Random();
            id = rnd.Next();
            releaseY = y;

        }
    }

    public abstract class Computer : Technics
    {
        public abstract string Dosmth();   
        public abstract void CostOnSale();

        new public string ToString()
        {
            return "COMPUTER_TYPE_ABSTRACT " + base.ToString();
        }
    }

    public class Tablet : Computer, ISale   
    {
        public static int amount;
        public override string Dosmth()
        {
            return "Hello I'm useless piece of code";
        }

        new public string ToString()
        {
            return "TABLET_TYPE " + base.ToString();
        }

        public Tablet(int c, string b, string m,int y)
        {
            amount++;
            cost = c;
            brand = b;
            model = m;
            termOfService = 2;
            Random rnd = new Random();
            id = rnd.Next();
            releaseY = y;
        }

        void ISale.CostOnSale()
        {
            int coSale;
            coSale = cost - (40 * 100 / cost);
            Console.WriteLine($"Cost on sale: {coSale}");
        }
        public override void CostOnSale()
        {
            int coSale;
            coSale = cost - (38 * 100 / cost);
            Console.WriteLine($"Cost on sale: {coSale}");
        }
    }

    public class Laboratory
    {
        object Item { get; set; }
        public List<Technics> labList = new List<Technics>();
        public static int count;

        public void Add(Technics item)
        {
            if(count>=8)
            {
                //throw new LaboratoryExeption("Не хватает места в списке.");  //LaboratoryExeption
            }
            else
            {
                labList.Add(item);
                count++;
            }
            
        }
        public void Delete(Technics item)
        {
            if(count==0)
            {
                //throw new NullReferenceException("список пуст.");   //NullReferenceExeption
            }
            else
            {
                labList.Remove(item);
                count--;
            }
            
        }
        public void Print()
        {
            foreach (Technics x in labList)
                Console.WriteLine(x.ToString());
        }
    }

    public class Controller:Laboratory
    {
        public void DisplayAllInfo()
        {
            Console.WriteLine("All data");
            foreach (Technics x in labList)
                x.Info();
        }

        public void OldTech()
        {
            Console.WriteLine("items older then they term of service");
            foreach (Technics x in labList)
            {
                if((x.releaseY + x.termOfService)<2005)
                {
                    //throw new ControllerExeption("Ваша техника слишком стара даже для этого списка.");   //ControllerExeption
                }
                else
                {
                    if ((x.releaseY + x.termOfService) < DateTime.Today.Year)
                        x.Info();
                }               
            }
        }

        public void AmountOfEachType()
        {
            Console.WriteLine("Quantity in stock");
            Console.WriteLine($"Amount of printers:{Printer.amount}");
            Console.WriteLine($"Amount of scaners:{Scaner.amount}");
            Console.WriteLine($"Amount of tablets:{Tablet.amount}");
        }

        public void SortByCost()
        {
            Console.WriteLine("Base sort by cost");
            for (int i = 1; i < Laboratory.count; ++i)
            {
                for (int r = 0; r < Laboratory.count - i; r++)
                {
                    if (labList[r].cost < labList[r + 1].cost)
                    {
                        var temp = labList[r];
                        labList[r] = labList[r + 1];
                        labList[r + 1] = temp;
                    }
                }
            }
            DisplayAllInfo();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tablet t = new Tablet(647, "Lenivo", "TB-X080C", 2013);
                Tablet t1 = new Tablet(800, "Samslug", "MTXQ2", 2019);
                Tablet t2 = new Tablet(260, "Dogma", "1523ML", 2023);
                Printer p = new Printer(601, "Cannon", "I-SENSYS", 2012);
                Printer p1 = new Printer(409, "PH", "M304A", 2018);
                Printer p2 = new Printer(0, "PH", "M304A", 1999);
                Scaner s = new Scaner(666, "Cannon", "LIDE300", 2015);
                Scaner s1 = new Scaner(0, "Brother", "ADS-1200", 2017);
                Scaner s2 = new Scaner(351, "Espada", "MDFC-1400", 2021);
                Scaner s3 = new Scaner(2500, "Fujitsu", "FI-7140", 2000);

                Controller lab = new Controller();
                lab.Add(t);
                lab.Add(t1);
                lab.Add(t2);
                lab.Add(p);
                lab.Add(p1);
                lab.Add(p2);
                lab.Add(s);
                lab.Add(s1);
                lab.Add(s2);
                lab.Add(s3);

                lab.OldTech();
                lab.AmountOfEachType();
                lab.SortByCost();

                s.CostOnSale();
                s1.CostOnSale();

                lab.Delete(t);
                lab.Delete(t1);
                lab.Delete(t2);
                lab.Delete(p);
                lab.Delete(p1);
                lab.Delete(p2);
                lab.Delete(s);
                lab.Delete(s1);
                lab.Delete(s2);
                lab.Delete(s3);
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}\nМестонахождение:{ex.StackTrace}");
            }
            catch(TechnicsExeption ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}\nМестонахождение:{ex.StackTrace}");
            }
           catch (ControllerExeption ex)
            {
                Console.WriteLine($"Сообщение ошибки:{ex.Message}\nМестонахождение:{ex.StackTrace}");
            }
            catch(LaboratoryExeption ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}\nМестонахождение:{ex.StackTrace}");
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}\nМестонахождение:{ex.StackTrace}");
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}\nМестонахождение:{ex.StackTrace}");
            }
            finally
            {
                Console.WriteLine("Конец.");
            }
        }
    }
}


