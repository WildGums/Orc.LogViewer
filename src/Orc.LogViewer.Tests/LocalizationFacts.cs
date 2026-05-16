namespace Orc.LogViewer.Tests;

using System.Globalization;
using System.IO;
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
    public class The_Extracted_Xaml_Strings
    {
        [Test]
        public void Use_LanguageBinding_Instead_Of_Hardcoded_Text()
        {
            var repositoryRoot = GetRepositoryRoot();

            var advancedLogViewerControl = File.ReadAllText(Path.Combine(repositoryRoot, "src", "Orc.LogViewer", "Views", "AdvancedLogViewerControl.xaml"));
            var mainWindow = File.ReadAllText(Path.Combine(repositoryRoot, "src", "Orc.LogViewer.Example", "Views", "MainWindow.xaml"));
            var separateWindowExample = File.ReadAllText(Path.Combine(repositoryRoot, "src", "Orc.LogViewer.Example", "Views", "LogViewerSeparateWindowExample.xaml"));

            Assert.Multiple(() =>
            {
                Assert.That(advancedLogViewerControl, Does.Contain("Content=\"{catel:LanguageBinding LogViewer_AdvancedLogViewerControl_Button_Content_EditFilterGroups}\""));
                Assert.That(mainWindow, Does.Contain("Header=\"{catel:LanguageBinding LogViewerExample_MainWindow_TabItem_Header_LogViewer}\""));
                Assert.That(mainWindow, Does.Contain("Header=\"{catel:LanguageBinding LogViewerExample_MainWindow_TabItem_Header_LogViewerWindow}\""));
                Assert.That(separateWindowExample, Does.Contain("Content=\"{catel:LanguageBinding LogViewerExample_LogViewerSeparateWindowExample_Button_Content_OpenLogViewerInSeparateWindow}\""));
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

    private static string GetRepositoryRoot()
    {
        var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);

        while (directory is not null)
        {
            if (File.Exists(Path.Combine(directory.FullName, "src", "Orc.LogViewer", "Orc.LogViewer.csproj")))
            {
                return directory.FullName;
            }

            directory = directory.Parent;
        }

        Assert.Fail("Could not locate the repository root from the test directory.");
        return string.Empty;
    }
}
