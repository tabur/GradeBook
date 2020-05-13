using System;
using System.Collections.Generic;

namespace GradeBook
{
  public class InMemoryBook : Book
  {
    private List<double> _grades;
    public Statistics stat;

    public override event GradeAddedDelegate GradeAdded;

    public InMemoryBook(string name) : base(name)
    {
      _grades = new List<double>();
      Name = name;
      stat = new Statistics();
    }

    public override Statistics GetStatistics()
    {
      stat = stat.GetStats(_grades);

      return stat;
    }

    public override void AddGrade(double grade)
    {
      if(grade >= 0 && grade <= 100)
      {
        _grades.Add(grade);
        if(GradeAdded != null) 
        {
          GradeAdded(this, new EventArgs());
        }
      }
      else 
      {
        throw new ArgumentException($"Invalid {nameof(grade)}");
      }
    }

    

    
    
   
  }

}