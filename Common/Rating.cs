using System.Collections.Generic;

namespace Common
{
    public class Rating : Dictionary<Student, decimal> 
    {
        public Rating()
        {
        }

        internal Rating(IDictionary<Student, decimal> dictionary) : base(dictionary)
        {
        }
    }

    public static class RatingExtensions
    {
        public static Rating ToRating(this Dictionary<Student, decimal> rating) => new (rating);
    }
}