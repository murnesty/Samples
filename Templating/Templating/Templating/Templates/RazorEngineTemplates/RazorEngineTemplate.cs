using RazorEngine;
using RazorEngine.Templating;

namespace Templating.Templates.RazorEngineTemplates;

public sealed class RazorEngineTemplate : ITemplateEngine
{
    public void CreateTemplate<T>(string template, T model = default)
    {
        try
        {
            // Add the template and compile it
            var templateKey = typeof(T).FullName;  // This should match the key you use in `Run`
            //Engine.Razor.AddTemplate(templateKey, template); // Add template to RazorEngine
            //Engine.Razor.Compile(template, templateKey);  // Compile the template
            //string template = "Hello @Model.Name (@Model.EmailAddress), welcome to RazorEngine!";
            Engine.Razor.RunCompile(template, templateKey, typeof(T), model);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating RazorEngine template: {ex.Message}");
        }
    }

    public string RunTemplate<T>(T model)
    {
        try
        {
            var templateKey = typeof(T).FullName;  // This should match the key you use in `Run`
            return Engine.Razor.Run(templateKey, typeof(T), model);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error rendering RazorEngine template: {ex.Message}");
            throw;
        }
    }
}
