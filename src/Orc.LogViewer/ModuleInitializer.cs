﻿using Catel;
using Catel.IoC;
using Catel.MVVM;
using Catel.Services;
using Orc.LogViewer;

/// <summary>
/// Used by the ModuleInit. All code inside the Initialize method is ran as soon as the assembly is loaded.
/// </summary>
public static class ModuleInitializer
{
    /// <summary>
    /// Initializes the module.
    /// </summary>
    public static void Initialize()
    {
        var serviceLocator = ServiceLocator.Default;

        var languageService = serviceLocator.ResolveRequiredType<ILanguageService>();
        languageService.RegisterLanguageSource(new LanguageResourceSource("Orc.LogViewer", "Orc.LogViewer.Properties", "Resources"));

        var commandManager = serviceLocator.ResolveRequiredType<ICommandManager>();
        InitializeCommands(commandManager);
    }

    private static void InitializeCommands(ICommandManager commandManager)
    {
        commandManager.CreateCommandWithGesture(typeof(LogViewerCommands.Logging), "ToggleError");
        commandManager.CreateCommandWithGesture(typeof(LogViewerCommands.Logging), "ToggleWarning");
        commandManager.CreateCommandWithGesture(typeof(LogViewerCommands.Logging), "ToggleDebug");
        commandManager.CreateCommandWithGesture(typeof(LogViewerCommands.Logging), "ToggleInfo");

        commandManager.CreateCommandWithGesture(typeof(LogViewerCommands.Logging), "ToggleTimestamp");
        commandManager.CreateCommandWithGesture(typeof(LogViewerCommands.Logging), "Clear");
        commandManager.CreateCommandWithGesture(typeof(LogViewerCommands.Logging), "CopyToClipboard");
        commandManager.CreateCommandWithGesture(typeof(LogViewerCommands.Logging), "OpenInEditor");
    }
}
