using Templating.Emails;
using Templating.Templates;

namespace Templating;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var engines = new List<TemplateEngineType>
        {
            TemplateEngineType.RazorEngine,
            TemplateEngineType.Handlebars,
            TemplateEngineType.Scriban
        };

        foreach(var engine in engines)
        {
            var templateEngine = new EmailTemplating(engine);
            templateEngine.Initialize();
            var content = templateEngine.GetContent();

            Console.WriteLine($"{engine.ToString()}:: {content}");
        }
    }
}
