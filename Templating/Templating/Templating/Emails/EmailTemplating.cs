using RazorEngine;
using System.Reflection;
using Templating.Emails.Data;
using Templating.Templates;

namespace Templating.Emails;

public sealed class EmailTemplating
{
    #region Properties

    public ITemplateEngine TemplateEngine { get; set; }

    #endregion

    #region Constructor

    public EmailTemplating(TemplateEngineType templateEngineType)
    {
        TemplateEngine = TemplateEngineFactory.CreateTemplateEngine(templateEngineType);
    }

    #endregion

    #region Public

    public void Initialize()
    {
        CreateWelcomeEmailTemplate();
    }

    public string GetContent()
    {
        return TemplateEngine.RunTemplate<WelcomeEmailModel>(new WelcomeEmailModel
        {
            Name = "John",
            EmailAddress = "abc@mail.com"
        });
    }

    #endregion

    #region Private

    private void CreateWelcomeEmailTemplate()
    {
        string templateRazor = "Hello @Model.Name with email @Model.EmailAddress, welcome to template engine!!!";
        string templateHandlerbars = "Hello {{Name}} with email {{EmailAddress}}, welcome to template engine!!!";
        string templateScriban = "Hello {{name}} with email {{email_address}}, welcome to template engine!!!";
        TemplateEngine.CreateTemplate<WelcomeEmailModel>(templateScriban, new WelcomeEmailModel());
    }

    #endregion
}
