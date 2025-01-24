using CdCSharp.FluentCli;
using CdCSharp.FluentCli.Abstractions;
using CdCSharp.SequentialGenerator;

FCli cli = new FCli()
           .WithDescription("Source Generator Runner")
           .WithErrorHandler(ex => Console.WriteLine(ex.Message))
           .Command<GenerateArgs>("generate")
               .WithAlias("g")
               .WithDescription("Run source generators")
               .OnExecute(async (args)
                    => await GeneratorExecutor.RunGenerators(args.ProjectPath, args.OutputPath));

await cli.ExecuteAsync(args);

public class GenerateArgs
{
    [Arg("project", "Project path", "p")]
    public string ProjectPath { get; set; } = "";

    [Arg("output", "Output path", "o")]
    public string OutputPath { get; set; } = "Generated";
}