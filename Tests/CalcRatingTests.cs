// ReSharper disable ArrangeObjectCreationWhenTypeNotEvident
using Common;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class CalcRatingTests
    {
        [Test]
        public void CalculateRating()
        {
            // Assert
            var inputData = new Grades
            {
                [Student.FromString("Абрамов Петр Сергеевич")] = new()
                {
                    new("математика", 80),
                    new("русский язык", 76),
                    new("программирование", 100)
                },
                [Student.FromString("Петров Игорь Владимирович")] = new()
                {
                    new("математика", 61),
                    new("русский язык", 80),
                    new("программирование", 78),
                    new("литература", 97)
                }
            };

            var expected = new Rating
            {
                [Student.FromString("Абрамов Петр Сергеевич")] = 85.33M,
                [Student.FromString("Петров Игорь Владимирович")] = 79.00M
            };
            
            // Act
            var ratingCalculator = new RatingCalculator { Grades = inputData };
            var actual = ratingCalculator.Rating;
            
            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}