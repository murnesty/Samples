using HandlebarsDotNet;

namespace Templating.Templates.HandlebarsTemplates;

public class HandlebarsTemplate : ITemplateEngine
{
    public Dictionary<string, HandlebarsTemplate<object, object>> Templates = [];

    public void CreateTemplate<T>(string template, T model = default)
    {
        try
        {
            var compiledTemplate = Handlebars.Compile(template);

            Templates.TryAdd(typeof(T).FullName!, compiledTemplate);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating Handlebars template: {ex.Message}");
            throw;
        }
    }

    public string RunTemplate<T>(T model)
    {
        try
        {
            var isSuccess = Templates.TryGetValue(typeof(T).FullName!, out var parsedTemplate);
            if (!isSuccess || parsedTemplate is null)
            {
                throw new Exception($"Can't find Scriban template for {typeof(T).FullName!}");
            }

            return parsedTemplate(model!);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error rendering Handlebars template: {ex.Message}");
            throw;
        }
    }
}
