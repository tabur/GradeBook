using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GradeBook
{
  public class DiskBook : Book
  {
    private readonly string _path;

    public DiskBook(string name) : base(name)
    {
      _path = Path.GetInvalidFileNameChars()
                  .Aggregate(name, (current, c) => current.Replace(c, '_'));
      _path = _path + ".txt";

    }

    public override event GradeAddedDelegate GradeAdded;

    public override void AddGrade(double grade)
    {
      
      if(!File.Exists(_path))
      {
        File.CreateText(_path);
      }

      using (StreamWriter sw = File.AppendText(_path))
      {
        sw.WriteLine(grade);
        if(GradeAdded != null) 
        {
          GradeAdded(this, new EventArgs());
        }
      }
    }

    public override Statistics GetStatistics()
    {
      Statistics stat = new Statistics();

      List<double> grades = new List<double>();
      using (StreamReader sr = File.OpenText(_path))
      {
        string line;
        while((line = sr.ReadLine()) != null) {
          grades.Add(Convert.ToDouble(line));
        }
      }
      stat = stat.GetStats(grades);

      return stat;    
    }
  }
}