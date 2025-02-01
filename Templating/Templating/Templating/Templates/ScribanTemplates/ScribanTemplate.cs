using Scriban;

namespace Templating.Templates.ScribanTemplates;

public class ScribanTemplate : ITemplateEngine
{
    public Dictionary<string, Template> Templates = [];

    public void CreateTemplate<T>(string template, T model = default)
    {
        try
        {
            var compiledTemplate = Template.Parse(template);

            Templates.TryAdd(typeof(T).FullName!, compiledTemplate);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating Scriban template: {ex.Message}");
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

            return parsedTemplate.Render(model);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error rendering Scriban template: {ex.Message}");
            throw;
        }
    }
}
