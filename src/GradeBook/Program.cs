using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      //create a new book object
      IBook book = new DiskBook("test book, please ignore");

      //subscribe handler to event
      book.GradeAdded += OnGradeAdded;

      EnterGrades(book);

      ShowStats(book);

      Console.ReadLine();

    }

    //get and print the statistics of the given book
    public static void ShowStats(IBook book)
    {
      Statistics stat = book.GetStatistics();
      
      Console.WriteLine($"The average is {stat.Average:N1}, minimum is {stat.Min} and maximum is {stat.Max}");
      Console.WriteLine($"The Letter grade is {stat.Letter}");
    }

    //data entry loop
    private static void EnterGrades(IBook book)
    {
      Console.WriteLine("Please enter a grade. Press \'q\' to stop.");
      while (true)
      {
        var input = Console.ReadLine();

        if (input == "q")
        {
          break;
        }

        else
        {
          //try to enter a grade or catch exceptions from incorrectly formatted input 
          try
          {
            
            var grade = double.Parse(input);
            book.AddGrade(grade);
          }
          catch (ArgumentException ex)
          {
            Console.WriteLine(ex.Message);
          }
          catch (FormatException ex)
          {
            Console.WriteLine(ex.Message);
          }
        }
      }
    }

    //event handler
    static void OnGradeAdded(object sender, EventArgs e) 
    {
      Console.WriteLine("*");
    }
  }
  
}
