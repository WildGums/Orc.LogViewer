namespace Orc;

using System;
using Catel;
using Catel.IoC;
using Catel.Logging;
using Catel.MVVM;
using Catel.Services;
using Catel.ThirdPartyNotices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Orc.LogViewer;

/// <summary>
/// Core module which allows the registration of default services in the service collection.
/// </summary>
public static class OrcLogViewerModule
{
    public static IServiceCollection AddOrcLogViewer(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddSingleton<CommandInitializer>();

        serviceCollection.AddSingleton<ILanguageSource>(new LanguageResourceSource("Orc.LogViewer", "Orc.LogViewer.Properties", "Resources"));

        serviceCollection.AddSingleton<IThirdPartyNotice>((x) => new LibraryThirdPartyNotice("Orc.LogViewer", "https://github.com/wildgums/orc.logviewer"));

        return serviceCollection;
    }

    private class CommandInitializer : IConstructAtStartup
    {
        public CommandInitializer(IServiceProvider serviceProvider, ICommandManager commandManager)
        {
            commandManager.CreateCommandWithGesture(serviceProvider, typeof(LogViewerCommands.Logging), "ToggleError");
            commandManager.CreateCommandWithGesture(serviceProvider, typeof(LogViewerCommands.Logging), "ToggleWarning");
            commandManager.CreateCommandWithGesture(serviceProvider, typeof(LogViewerCommands.Logging), "ToggleDebug");
            commandManager.CreateCommandWithGesture(serviceProvider, typeof(LogViewerCommands.Logging), "ToggleInfo");

            commandManager.CreateCommandWithGesture(serviceProvider, typeof(LogViewerCommands.Logging), "ToggleTimestamp");
            commandManager.CreateCommandWithGesture(serviceProvider, typeof(LogViewerCommands.Logging), "Clear");
            commandManager.CreateCommandWithGesture(serviceProvider, typeof(LogViewerCommands.Logging), "CopyToClipboard");
            commandManager.CreateCommandWithGesture(serviceProvider, typeof(LogViewerCommands.Logging), "OpenInEditor");
        }
    }
}
