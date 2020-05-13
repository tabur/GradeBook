using System.Collections.Generic;

namespace GradeBook
{
  public class Statistics {
    public double Average;
    public double Min;
    public double Max;
    public char Letter;

    private List<double> _grades;

    public Statistics GetStats(List<double> grades)
    {
      _grades = grades;
      Statistics stat = new Statistics();
      stat.Average = 0.0;
      stat.Min = FindMin();
      stat.Max = FindMax();
      stat.Average = CalculateAverage();
      stat.Letter = DefineLetter(stat.Average);
      return stat;
    }

    public char DefineLetter(double average) 
    {
      char letter;

      switch(average)
      {
        case var d when d >= 90.0:
          letter = 'A';
          break;
        case var d when d >= 80.0:
          letter = 'B';
          break;
        case var d when d >= 70.0:
          letter = 'C';
          break;
        case var d when d >= 60.0:
          letter = 'D';
          break;
        default:
          letter = 'F';
          break;
      }
      return letter;
    }

    public double CalculateAverage()
    {
      double result = 0;
      double avg = 0;

      foreach (double num in _grades)
        result += num;
      
      return avg = result / _grades.Count;
    }

    public double FindMax() 
    {
      double max = double.MinValue;
      foreach (double num in _grades)
      {
          if(num > max)
            max = num;
      }
      return max;
    }



    public double FindMin() 
    {
      double min = double.MaxValue;
      foreach (double num in _grades)
      {
          if(num < min)
            min = num;
      }
      return min;
    }

  }
}
