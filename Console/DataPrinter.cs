using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Spectre.Console;
using static System.ConsoleColor;

namespace Console
{
    public class DataPrinter
    {
        public static void Print(Grades grades)
        {
            AnsiConsole.Render(Dump(grades));
        }

        public static void Print(Rating rating)
        {
            AnsiConsole.Render(Dump(rating));
        }

        public static void PrintUnderachieving(IEnumerable<Student> students)
        {
            var table = new Table().Border(TableBorder.Rounded);
            table.AddColumn("Неуспевающие студенты");

            foreach (var student in students)
            {
                table.AddRow(student.ToString());
            }

            if (table.Rows.Count == 0)
            {
                table.AddRow("<пусто>");
            }
            
            AnsiConsole.Render(table);
        } 
        
        private static Table Dump(Grades grades)
        {
            var table = new Table().Border(TableBorder.Rounded);
            table.AddColumn("Студент");
            table.AddColumn("Оценки");

            foreach (var (student, g) in grades) table.AddRow(new Markup(student.ToString()), Dump(g));

            return table;
        }

        private static Table Dump(List<Grade> grades)
        {
            var table = new Table().Border(TableBorder.Rounded);
            table.AddColumn("Предмет");
            table.AddColumn("Оценка");

            foreach (var (subject, score) in grades) table.AddRow(subject, score.ToString());

            return table;
        }

        private static BarChart Dump(Rating rating)
        {
            var barChart = new BarChart().Label("[blue bold]Рейтинг[/]").Width(60).CenterLabel().AddItems(rating,
                element => new BarChartItem(element.Key.ToString(), (double)element.Value, GetRandomColor()));
            
            return barChart;
        }

        private static ConsoleColor GetRandomColor()
        {
            return new[]
                {
                    Black, DarkBlue, DarkGreen, DarkCyan,
                    DarkRed, DarkMagenta, DarkYellow, Gray,
                    DarkGray, Blue, Green, Cyan,
                    Red, Magenta, Yellow, White
                }
                .OrderBy(_ => Guid.NewGuid())
                .FirstOrDefault()!;
        }
    }
}