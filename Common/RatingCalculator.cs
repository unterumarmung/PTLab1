using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Sources;

namespace Common
{
    public class RatingCalculator
    {
        private const int DecimalPlaces = 2;
        public Grades Grades { get; set; } = new Grades();

        public Rating Rating =>
            Grades
                .Select(studentToGrades => (student: studentToGrades.Key,
                    score: CalculateRatingForStudent(studentToGrades.Value)))
                .ToDictionary(rating => rating.student, rating => rating.score).ToRating();

        private static decimal CalculateRatingForStudent(IReadOnlyCollection<Grade> grades)
        {
            return decimal.Round(grades.Select(grade => grade.Score).Sum() / (decimal)grades.Count, DecimalPlaces);
        }
    }
}