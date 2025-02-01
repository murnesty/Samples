namespace Templating.Templates;

public interface ITemplateEngine
{
    void CreateTemplate<T>(string template, T model = default);

    string RunTemplate<T>(T model);
}
