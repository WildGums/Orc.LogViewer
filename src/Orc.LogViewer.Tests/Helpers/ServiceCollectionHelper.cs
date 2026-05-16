namespace Orc.LogViewer.Tests;

using Catel;
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
}
