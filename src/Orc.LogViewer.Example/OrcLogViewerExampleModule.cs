namespace Orc;

using Catel.Services;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Example module which allows the registration of example services in the service collection.
/// </summary>
public static class OrcLogViewerExampleModule
{
    /// <summary>
    /// Adds the Orc.LogViewer example services.
    /// </summary>
    /// <param name="serviceCollection">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddOrcLogViewerExample(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ILanguageSource>(new LanguageResourceSource("Orc.LogViewer.Example", "Orc.LogViewer.Example.Properties", "Resources"));

        return serviceCollection;
    }
}
