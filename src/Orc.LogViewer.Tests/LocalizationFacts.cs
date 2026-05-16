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

        [Test]
        public void Return_Expected_Example_Strings()
        {
            using var serviceProvider = CreateServiceProvider();
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();

            Assert.Multiple(() =>
            {
                Assert.That(languageService.GetRequiredString("LogViewerExample_MainWindow_TabItem_Header_LogViewer"), Is.EqualTo("LogViewer"));
                Assert.That(languageService.GetRequiredString("LogViewerExample_MainWindow_TabItem_Header_LogViewerWindow"), Is.EqualTo("LogViewer window"));
                Assert.That(languageService.GetRequiredString("LogViewerExample_LogViewerSeparateWindowExample_Button_Content_OpenLogViewerInSeparateWindow"), Is.EqualTo("Open log viewer in separate window"));
                Assert.That(languageService.GetRequiredString("LogViewerExample_MainWindow_Title"), Is.EqualTo("Orc.LogViewer example"));
                Assert.That(languageService.GetRequiredString("LogViewerExample_LogWindow_Title"), Is.EqualTo("Log window"));
            });
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
