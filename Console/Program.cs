using CommandLine;
using Common;
using Console;
using Spectre.Console;

var options = new Options();
Parser.Default.ParseArguments<Options>(args).WithParsed(o => options = (Options)o);

var reader = GradesReaderFactory.GetReader(options.Path);
var gradesWithStudents = reader.Read(options.Path);

System.Console.WriteLine("Студенты:");
DataPrinter.Print(gradesWithStudents);

var ratingCalculator = new RatingCalculator { Grades = gradesWithStudents };
System.Console.WriteLine("Рейтинг: ");
DataPrinter.Print(ratingCalculator.Rating);

internal class Options
{
    [Option('p', "path", Required = true, HelpText = "Input file to read.")]
    public string Path { get; set; }
}


