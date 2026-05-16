namespace Orc.LogViewer.Tests;

using System.Globalization;
using Catel.Services;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

public class LocalizationFacts
{
    [TestFixture]
    public class The_Registered_Localization_Resources
    {
        [Test]
        public void Return_Expected_LogViewer_Strings()
        {
            using var serviceProvider = CreateServiceProvider();
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();

            Assert.That(languageService.GetRequiredString("LogViewer_AdvancedLogViewerControl_Button_Content_EditFilterGroups"), Is.EqualTo("..."));
        }
    }

    private static ServiceProvider CreateServiceProvider()
    {
        var serviceCollection = ServiceCollectionHelper.CreateServiceCollection();
        serviceCollection.AddSingleton<ILanguageSource>(new LanguageResourceSource("Orc.LogViewer.Example", "Orc.LogViewer.Example.Properties", "Resources"));

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var languageService = serviceProvider.GetRequiredService<ILanguageService>();
        languageService.PreferredCulture = new CultureInfo("en-US");
        languageService.FallbackCulture = new CultureInfo("en-US");

        return serviceProvider;
    }
}
