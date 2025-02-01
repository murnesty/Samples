using Templating.Templates.HandlebarsTemplates;
using Templating.Templates.RazorEngineTemplates;
using Templating.Templates.ScribanTemplates;

namespace Templating.Templates;

public enum TemplateEngineType
{
    RazorEngine,
    Scriban,
    Handlebars
}

public class TemplateEngineFactory
{
    public static ITemplateEngine CreateTemplateEngine(TemplateEngineType engineType)
    {
        switch (engineType)
        {
            case TemplateEngineType.RazorEngine:
                return new RazorEngineTemplate();
            case TemplateEngineType.Scriban:
                return new ScribanTemplate();
            case TemplateEngineType.Handlebars:
                return new HandlebarsTemplate();
            default:
                throw new ArgumentException("Unsupported template engine type", nameof(engineType));
        }
    }
}