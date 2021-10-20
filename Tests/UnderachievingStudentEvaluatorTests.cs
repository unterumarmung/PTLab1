using Common;
using FluentAssertions;
using NUnit.Framework;
using static Common.Student;

// ReSharper disable ArrangeObjectCreationWhenTypeNotEvident

namespace Tests
{
    public class UnderachievingStudentEvaluatorTests
    {
        [Test]
        public void NoneUnderachieving()
        {
            // Arrange
            var grades = new Grades
            {
                [FromString("Иванов Константин Дмитриевич")] = new()
                {
                    new("математика", 91),
                    new("химия", 100)
                },
                [FromString("Петров Петр Семенович")] = new()
                {
                    new("русский язык", 87),
                    new("литература", 78)
                }
            };
            var evaluator = new UnderachievingStudentsEvaluator { StudentGrades = grades };
            
            // Act
            var actual = evaluator.Evaluate();
            
            // Assert
            actual.Should().BeEmpty();
        }
        
        [Test]
        public void OneUnderachieving()
        {
            // Arrange
            var grades = new Grades
            {
                [FromString("Иванов Константин Дмитриевич")] = new()
                {
                    new("математика", 60),
                    new("химия", 100)
                },
                [FromString("Петров Петр Семенович")] = new()
                {
                    new("русский язык", 87),
                    new("литература", 78)
                }
            };
            var evaluator = new UnderachievingStudentsEvaluator { StudentGrades = grades };
            var expected = new[] { FromString("Иванов Константин Дмитриевич") };
            // Act
            var actual = evaluator.Evaluate();
            
            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
        
        [Test]
        public void AllUnderachieving()
        {
            // Arrange
            var grades = new Grades
            {
                [FromString("Иванов Константин Дмитриевич")] = new()
                {
                    new("математика", 60),
                    new("химия", 100)
                },
                [FromString("Петров Петр Семенович")] = new()
                {
                    new("русский язык", 87),
                    new("литература", 40)
                }
            };
            var evaluator = new UnderachievingStudentsEvaluator { StudentGrades = grades };
            var expected = new[] { FromString("Иванов Константин Дмитриевич"), FromString("Петров Петр Семенович") };
            // Act
            var actual = evaluator.Evaluate();
            
            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}