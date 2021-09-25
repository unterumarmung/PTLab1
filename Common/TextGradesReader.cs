using System;
using System.Collections.Generic;
using System.IO;

namespace Common
{
    public class TextGradesReader : IGradesReader
    {
        public Grades Read(string path)
        {
            var grades = new Grades();
            Student? currentStudent = null;

            var allLines = File.ReadLines(path);
            foreach (var line in allLines)
            {
                if (line.StartsWith(" ") && currentStudent is not null)
                {
                    var subjectAndScore = line.Trim().Split(":", count: 2, StringSplitOptions.TrimEntries);
                    grades[currentStudent].Add(new Grade(subjectAndScore[0], int.Parse(subjectAndScore[1])));
                }
                else
                {
                    currentStudent = Student.FromString(line.Trim());
                    grades[currentStudent] = new List<Grade>();
                }
            }

            return grades;
        }
    }
}