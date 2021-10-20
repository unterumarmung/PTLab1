using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class UnderachievingStudentsEvaluator
    {
        private static int _minimumValidScore = 61;

        public Grades StudentGrades { get; set; } = new();

        public IEnumerable<Student> Evaluate()
        {
            return StudentGrades
                .Where(studentToGrades => studentToGrades.Value.Any(grade => grade.Score < _minimumValidScore))
                .Select(studentToGrades => studentToGrades.Key);
        }
    }
}