using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
      static Statistics result;
      public BookTests() {
        //arrange
        var book = new InMemoryBook("testBook");
        book.AddGrade(89.1);
        book.AddGrade(90.5);
        book.AddGrade(77.3);
        //act
        result = book.GetStatistics();
      }
        //assert
        [Fact]
        public void BookCalculatesAverageGrade()
        {
          Assert.Equal(85.6, result.Average, 1);
 
        }
        [Fact]
        public void BookCalculatesMin()
        {
          Assert.Equal(77.3, result.Min);

        }
        [Fact]
        public void BookCalculatesMax()
        {
          Assert.Equal(90.5, result.Max);

        }
        [Fact]
        public void BookAssignsLetter()
        {
          Assert.Equal('B', result.Letter);

        }
    }
}
