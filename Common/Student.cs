namespace Common
{
    public record Student(string FirstName, string SecondName, string Patronymic)
    {
        public static Student FromString(string student)
        {
            var strings = student.Split(' ');
            return new Student(strings[1], strings[0], strings[2]);
        }

        public override string ToString()
        {
            return string.Join(' ', SecondName, FirstName, Patronymic);
        }
    }
}