namespace Orc.LogViewer.Tests;

using Catel;
using Catel.Services;
using Microsoft.Extensions.DependencyInjection;
using Orc.Controls;

internal static class ServiceCollectionHelper
{
    public static IServiceCollection CreateServiceCollection()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddLogging();
        serviceCollection.AddCatelCore();
        serviceCollection.AddCatelMvvm();
        serviceCollection.AddOrcControls();
        serviceCollection.AddOrcLogViewer();

        return serviceCollection;
    }

    public static IServiceCollection CreateServiceCollectionWithExampleLocalization()
    {
        var serviceCollection = CreateServiceCollection();

        serviceCollection.AddSingleton<ILanguageSource>(new LanguageResourceSource("Orc.LogViewer.Example", "Orc.LogViewer.Example.Properties", "Resources"));

        return serviceCollection;
    }
}
