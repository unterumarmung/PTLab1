// ReSharper disable ArrangeObjectCreationWhenTypeNotEvident

using System.Linq;
using Common;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class TextDataReaderTests
    {
        [Test]
        public void ReadFromText()
        {
            // Arrange
            using var file = new TempFile();

            var fileLines = @"
Иванов Константин Дмитриевич
 математика:91
 химия:100
Петров Петр Семенович
 русский язык:87
 литература:78
".Split('\n').Except(new []{string.Empty, "\r", "\n"}).Select(str => str.TrimEnd('\r'));
            
            using (var stream = file.FileInfo.CreateText())
            {
                foreach (var line in fileLines) stream.WriteLine(line);
            }
            
            var expected = new Grades
            {
                [Student.FromString("Иванов Константин Дмитриевич")] = new()
                {
                    new("математика", 91),
                    new("химия", 100)
                },
                [Student.FromString("Петров Петр Семенович")] = new()
                {
                    new("русский язык", 87),
                    new("литература", 78)
                }
            };
            
            // Act
            var textGradesReader = new TextGradesReader();
            var actual = textGradesReader.Read(file.FileInfo.FullName);
            
            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}