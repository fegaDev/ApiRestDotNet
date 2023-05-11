using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippets
{
    internal class Snippets
    {


        static public void StudentsLinq()
        {
            var classRoom = new[]
            {
            new Student
                {
                    Id = 1,
                    Name = "Eduardo",
                    Grade = 90,
                    Certified = true
                 },
            new Student
                {
                    Id = 2,
                    Name = "Peloncho",
                    Grade = 50,
                    Certified = true
                 },
             new Student
                {
                    Id = 3,
                    Name = "Feloncho",
                    Grade = 35,
                    Certified = false
                 },
             new Student
                {
                    Id = 4,
                    Name = "Felonchito",
                    Grade = 98,
                    Certified = true
                 },
            };

            var certifiedStudents = from student in classRoom
                                    where student.Certified
                                    select student;

            var notCertifiedStudents = from student in classRoom
                                       where student.Certified == false
                                       select student;

            var appovedStudentsNames = from student in classRoom
                                       where student.Grade >= 50 && student.Certified == true
                                       select student.Name;
        }
        //ALL
        static public void AllLinq()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };
            bool allAreSmallerThan10 = numbers.All(x => x < 10);
            bool allAreBiggerOrEqualThan2 = numbers.All(x => x >= 2);

            var emptyList = new List<int>();
            bool allNumbersAreGreaterThan0 = numbers.All(x => x >= 0);
        }
        //Aggregate
        static public void AggregateQueries()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Sum all nunmbers (prevSum = primer elemento , current = el siguiente)
            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);


            string[] words = { "hello", "my", "name", "is", "Eduardo" };
            string greeting = words.Aggregate((prevWord, current) => prevWord + current);
        }
        //Distinct : Valores repetidos
        static public void DistintValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5, 9, 6, 2, 0 };

            IEnumerable<int> distinctValues = numbers.Distinct();

        }
        //GroupBy : Agregar con la condición requerida
        static public void GroupByExamples()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 5, 9, 6, 2, 0 };
            var grouped = numbers.GroupBy(x => x % 2 == 0);


            //We will have two groups:
            // 1. The group that doesn't fit the condition (odd numbers)
            // 2. The group that fits the condition (even numbers)

            foreach ( var group in grouped)
            {
                foreach ( var item in group)
                {
                    Console.WriteLine(item);
                }
            }
            //Another example
            var classRoom = new[]
  {
            new Student
                {
                    Id = 1,
                    Name = "Eduardo",
                    Grade = 90,
                    Certified = true
                 },
            new Student
                {
                    Id = 2,
                    Name = "Peloncho",
                    Grade = 50,
                    Certified = true
                 },
             new Student
                {
                    Id = 3,
                    Name = "Feloncho",
                    Grade = 35,
                    Certified = false
                 },
             new Student
                {
                    Id = 4,
                    Name = "Felonchito",
                    Grade = 98,
                    Certified = true
                 },
            };
            var certifiedQuery = classRoom.GroupBy(student => student.Certified);
                //We obtain two groups
                // 1.- Not certified
                // 2.- Certified

                foreach( var certified in certifiedQuery)
            {
                Console.WriteLine("---------{0}-------", certified.Key);
                foreach( var student in certified)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }
        static public void RelationsLinq()
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Title = "Title",
                    Content = "Mi first Content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 1,
                            Created = DateTime.Now,
                            Title = "My first Comment",
                            Content = "My content"
                        },
                        new Comment()
                        {
                            Id = 2,
                            Created = DateTime.Now,
                            Title = "My Second Comment",
                            Content = "My second content"
                        },
                    }
                },
                new Post()
                {
                    Id = 2,
                    Title = "Title",
                    Content = "Mi first Content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 3,
                            Created = DateTime.Now,
                            Title = "My first Comment",
                            Content = "My content"
                        },
                        new Comment()
                        {
                            Id = 4,
                            Created = DateTime.Now,
                            Title = "My Second Comment",
                            Content = "My second content"
                        }
                    }
                }

            };

            var commentsContent = posts.SelectMany(post => post.Comments, (post, comment) => new { PostId = post.Id, CommentConent = comment.Content });
        } 
    }
}