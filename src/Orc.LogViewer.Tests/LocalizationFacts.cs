namespace Orc.LogViewer.Tests;

using System.Globalization;
using Catel.Services;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Orc.LogViewer.Examples.ViewModels;

public class LocalizationFacts
{
    [TestFixture]
    public class The_Example_ViewModel_Title_Property
    {
        [Test]
        public void MainWindowViewModel_Uses_Localized_Title()
        {
            using var serviceProvider = CreateServiceProvider();
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            var viewModel = new MainWindowViewModel(serviceProvider, languageService);

            Assert.That(viewModel.Title, Is.EqualTo("Orc.LogViewer example"));
        }

        [Test]
        public void LogWindowViewModel_Uses_Localized_Title()
        {
            using var serviceProvider = CreateServiceProvider();
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            var viewModel = new LogWindowViewModel(serviceProvider, languageService);

            Assert.That(viewModel.Title, Is.EqualTo("Log window"));
        }
    }

    [TestFixture]
    public class The_Registered_Localization_Resources
    {
        [Test]
        public void Return_Expected_Strings()
        {
            using var serviceProvider = CreateServiceProvider();
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();

            Assert.Multiple(() =>
            {
                Assert.That(languageService.GetRequiredString("LogViewer_AdvancedLogViewerControl_Button_Content_EditFilterGroups"), Is.EqualTo("..."));
                Assert.That(languageService.GetRequiredString("LogViewerExample_MainWindow_TabItem_Header_LogViewer"), Is.EqualTo("LogViewer"));
                Assert.That(languageService.GetRequiredString("LogViewerExample_MainWindow_TabItem_Header_LogViewerWindow"), Is.EqualTo("LogViewer window"));
                Assert.That(languageService.GetRequiredString("LogViewerExample_LogViewerSeparateWindowExample_Button_Content_OpenLogViewerInSeparateWindow"), Is.EqualTo("Open log viewer in separate window"));
            });
        }
    }

    private static ServiceProvider CreateServiceProvider()
    {
        var serviceCollection = ServiceCollectionHelper.CreateServiceCollection();
        serviceCollection.AddOrcLogViewerExample();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var languageService = serviceProvider.GetRequiredService<ILanguageService>();
        languageService.PreferredCulture = new CultureInfo("en-US");
        languageService.FallbackCulture = new CultureInfo("en-US");

        return serviceProvider;
    }
}
