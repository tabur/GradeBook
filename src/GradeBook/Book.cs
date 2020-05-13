
namespace GradeBook
{
  
  public interface IBook
  {
    void AddGrade(double book);
    Statistics GetStatistics();
    string Name {get;}
    event GradeAddedDelegate GradeAdded;
  }

  //a parent abstract class
  public abstract class Book : NamedObject, IBook
  {
    public Book(string name) : base(name)
    {
    }

    public abstract event GradeAddedDelegate GradeAdded;

    public abstract void AddGrade(double grade);
    public abstract Statistics GetStatistics();
  }

}