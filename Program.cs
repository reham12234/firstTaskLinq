using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ftask_linq
{
    internal class Program
    {
        static void Main(string[] args)
        {  
            //point1

            List<book> books = new List<book>
            {
                new book() { ID = 1, title = "c++", isAvailable = true ,genre="programming" ,cost=30m ,publishYear=2020 ,autherName="alice" ,decade=1990 ,ReturnDate= new DateTime(2020,9,1) ,BorrowwedTimes=4 ,DueDate= DateTime.Now},
                new book() { ID = 2, title = "java", isAvailable = true ,genre="programming"  ,cost=50m ,publishYear=2004 ,autherName="william" ,decade=1990 ,ReturnDate= new DateTime(2020,8,1) ,BorrowwedTimes=3 ,DueDate= new DateTime(2024,9,1)},
                new book() { ID = 3, title = "science", isAvailable = false ,genre="science" ,cost=40m ,publishYear=2025 ,autherName="Jane" ,decade=1980 ,ReturnDate= new DateTime(2020,6,1) ,BorrowwedTimes=0 ,DueDate= new DateTime(2026,9,1)},
                 new book() { ID = 4, title = "maths", isAvailable = false ,genre="science" ,cost=20m ,publishYear=2010 ,autherName="Jane" ,decade=2000 ,ReturnDate= new DateTime(2020,5,1) ,BorrowwedTimes=1, DueDate= new DateTime(2027,9,1)},
                 new book() { ID = 5, title = "arabic", isAvailable = false ,genre="science" ,cost=90m ,publishYear=2006 ,autherName="george" ,decade=1980 ,ReturnDate= null ,BorrowwedTimes=1 ,DueDate= new DateTime(2022,9,1)},
                   new book() { ID = 6, title = "english", isAvailable = false ,genre="science" ,cost=10m ,publishYear=2011 ,autherName="ernest" ,decade=2000 ,ReturnDate= null ,BorrowwedTimes=10 ,DueDate= new DateTime(2025,11,12)}

            };
            //point 1
            var res = books.Where(a => a.isAvailable == true);
            foreach (var h in res)
            {
                Console.WriteLine( $"{h.ID} , {h.title} ,{h.isAvailable}");
               
            }
            Console.WriteLine("##############################");
            //point 2
            var res2 = books.Select(a => a);
            foreach (var h in res)
            {
                Console.WriteLine(h.title);

            }
            Console.WriteLine("##############################");
            //point 3
            var res3=books.Where(a=> a.genre=="programming").Select(b => b);
            foreach (var h in res3)
            {
                Console.WriteLine($"{h.ID} , {h.title} ,{h.isAvailable} ,{h.genre}");

            }
            Console.WriteLine("##############################");
            //point 4
            var res4 = books.Select(a => a).OrderBy(a => a.title);

            foreach(var h in res4)
            {
                Console.WriteLine($"{h.ID} , {h.title} ,{h.isAvailable} ,{h.genre}");
            }
            Console.WriteLine("##############################");
            //point 5

            var res5 = books.Where(a => a.cost > 30).Select(a=>a);
            foreach (var h in res5)
            {
                Console.WriteLine($"{h.ID} , {h.title} ,{h.isAvailable} ,{h.genre} ,{h.cost}");
            }
            Console.WriteLine("##############################");
            //point 6
            var res6 = books.Select(a => a.genre).Distinct();
            foreach (var h in res6)
            {
                Console.WriteLine($"{h} ");

            }
            Console.WriteLine("##############################");
            //point 7
            var res7 = books.GroupBy(a => a.genre).Select(a=> new { genre= a.Key, count = a.Count() });

            foreach (var h in res7)
            {
                Console.WriteLine(h);

            }
            Console.WriteLine("##############################");
            //point 8

            var res8 = books.Where(a => a.publishYear > 2010);
            foreach( var h in res8)
            {
                Console.WriteLine($"{h.ID} , {h.title} ,{h.isAvailable} ,{h.genre} ,{h.cost} ,{h.publishYear}");
            }
            Console.WriteLine("##############################");
            //point 9
            var res9 = books.Take(5);
            foreach (var h in res9)
            {
                Console.WriteLine($"{h.ID} , {h.title} ,{h.isAvailable} ,{h.genre} ,{h.cost} ,{h.publishYear}");
            }
            Console.WriteLine("##############################");
            //point 10
            var res10 = books.Any(a => a.cost > 50);
            if (res10)
                Console.WriteLine("True ,exist ele price >50$ ");
            else Console.WriteLine("false ,not exist");
            Console.WriteLine("##############################");
            //point 11
            var res11 = books.Select(a => new { title = a.title, auther = a.autherName, genre = a.genre });
            foreach( var h in res11)
            {
                Console.WriteLine($" title : {h.title} : auther : {h.auther} : genre : {h.genre}");
            }
            Console.WriteLine("##############################");
            //point 12
            var res12 = books.GroupBy(a => a.genre).Select(a => new { genre = a.Key, avgPrice = a.Average(b => b.cost) });
            foreach( var h in res12)
            {
                Console.WriteLine(h);
            }
            Console.WriteLine("##############################");
            //point 13

            var max_price = books.Max(a => a.cost);
            var most_expensive = books.FirstOrDefault(a => a.cost == max_price);
            Console.WriteLine($"title of most_expensive=  {most_expensive.title} , cost= {most_expensive.cost}");

            Console.WriteLine("##############################");
            //point 14
            var res14 = books.GroupBy(a => a.decade).Select(a => new { decade = a.Key,books=a.ToList() });
            foreach (var h in res14)
            {
                Console.WriteLine(h.decade);
                foreach( var a in h.books)
                {
                    Console.WriteLine($"{a.ID} , {a.title} ,{a.isAvailable} ,{a.genre} ,{a.cost} ,{a.publishYear}");
                }
            }
            Console.WriteLine("##############################");
            //point 15
            var res15 = books.Where(a => a.ReturnDate == null);
            foreach(var a in res15)
            {
                Console.WriteLine($"{a.ID} , {a.title} ,{a.isAvailable} ,{a.genre} ,{a.cost} ,{a.publishYear} ,{a.decade}");
            }
            Console.WriteLine("##############################");
            //point 16

            var res16 = books.Where(a => a.BorrowwedTimes > 1);
            foreach(var a in res16)
            {
                Console.WriteLine($"{a.ID} , {a.title} ,{a.isAvailable} ,{a.genre} ,{a.cost} ,{a.publishYear} ,{a.decade} ,{a.BorrowwedTimes}");
            }
            Console.WriteLine("##############################");
            //point 17
            var res17=books.Where(a=> a.DueDate<DateTime.Now && a.ReturnDate==null);
            foreach(var a  in res17)
            {
                Console.WriteLine($"{a.ID} , {a.title} ,{a.isAvailable} ,{a.genre} ,{a.cost} ,{a.publishYear} ,{a.decade} ,{a.BorrowwedTimes} ,{a.DueDate}");
            }
            Console.WriteLine("##############################");
            //point 18
            var res18 = books.GroupBy(a => a.autherName).OrderByDescending(a => a.Count()).Select(a => new { auther = a.Key, count = a.Count() });
            foreach(var a in res18)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("##############################");
            //point 19
            var res19 = books.GroupBy(a => a.cost < 20 ? "cheap" : a.cost >= 20 && a.cost <= 40 ? "medium" : "expensive")
                .Select(a => new { a.Key, count = a.Count() });
            foreach( var a in res19)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("##############################");
            //point 20








        }
    }
    class book
    {
        public int ID { get; set; }
        public string title { get; set; }
        public bool isAvailable { get; set; }
        public string genre { get; set; }
        public decimal cost { get; set; }
        public int publishYear { get; set; }
        public string autherName {  get; set; }
        public int decade { get; set; }
 
        public DateTime? ReturnDate { get; set; }

        public int BorrowwedTimes { get; set; }
        public DateTime DueDate { get; set; }
    }
}
