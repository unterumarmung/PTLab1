using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Common
{
    public class JsonGradesReader : IGradesReader
    {
        public Grades Read(string path)
        {
            var json = JsonDocument.Parse(string.Join("", File.ReadLines(path)));

            var grades = new Grades();

            foreach (var element in json.RootElement.EnumerateObject())
            {
                var student = Student.FromString(element.Name);
                grades[student] = element.Value.EnumerateObject()
                    .Select(gradeJson => new Grade(gradeJson.Name, gradeJson.Value.GetInt32())).ToList();
            }

            return grades;
        }
    }
}