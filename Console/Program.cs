using System;
using System.Collections.Generic;
using CommandLine;
using Common;
using Spectre.Console;

var options = new Options();
Parser.Default.ParseArguments<Options>(args).WithParsed(o => options = (Options)o);

var reader = new TextGradesReader();
var gradesWithStudents = reader.Read(options.Path);

Console.WriteLine("Студенты:");
AnsiConsole.Render(DumpStudentWithGrades(gradesWithStudents));

var ratingCalculator = new RatingCalculator { Grades = gradesWithStudents };
Console.WriteLine("Рейтинг: ");
AnsiConsole.Render(DumpRating(ratingCalculator.Rating));

Table DumpStudentWithGrades(Grades grades)
{
    var table = new Table().Border(TableBorder.Rounded);
    table.AddColumn("Студент");
    table.AddColumn("Оценки");

    foreach (var (student, g) in grades)
    {
        table.AddRow(new Markup(student.ToString()), DumpGrades(g));
    }

    return table;
}

Table DumpGrades(List<Grade> grades)
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

Table DumpRating(Rating rating)
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

class Options
{
    [Option('p', "path", Required = true, HelpText = "Input file to read.")]
    public string Path { get; set; }
}


