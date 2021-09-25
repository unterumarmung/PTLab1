using System.Collections.Generic;
using Common;
using Spectre.Console;

namespace Console
{
    public class DataPrinter
    {
        public static void Print(Grades grades) => AnsiConsole.Render(Dump(grades));
        public static void Print(Rating rating) => AnsiConsole.Render(Dump(rating));
        private static Table Dump(Grades grades)
        {
            var table = new Table().Border(TableBorder.Rounded);
            table.AddColumn("Студент");
            table.AddColumn("Оценки");

            foreach (var (student, g) in grades)
            {
                table.AddRow(new Markup(student.ToString()), Dump(g));
            }

            return table;
        }
        private static Table Dump(List<Grade> grades)
        {
            var table = new Table().Border(TableBorder.Rounded);
            table.AddColumn("Предмет");
            table.AddColumn("Оценка");

            foreach (var (subject, score) in grades)
            {
                table.AddRow(subject, score.ToString());
            }

            return table;
        }

        private static Table Dump(Rating rating)
        {
            var table = new Table().Border(TableBorder.Rounded);
            table.AddColumn("Студент");
            table.AddColumn("Рейтинг");
    
            foreach (var (student, score) in rating)
            {
                table.AddRow(student.ToString(), score.ToString());
            }

            return table;
        }
    }
}