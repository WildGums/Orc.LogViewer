// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleInitializer.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using Catel;
using Catel.IoC;
using Catel.Logging;
using Catel.MVVM;
using Orc.LogViewer;

/// <summary>
/// Used by the ModuleInit. All code inside the Initialize method is ran as soon as the assembly is loaded.
/// </summary>
public static class ModuleInitializer
{
    /// <summary>
    /// Initializes the module.
    /// </summary>
    private static readonly ILog Log = LogManager.GetCurrentClassLogger();

    public static void Initialize()
    {
        var serviceLocator = ServiceLocator.Default;

        var viewModelLocator = serviceLocator.ResolveType<IViewModelLocator>();

        var commandManager = serviceLocator.ResolveType<ICommandManager>();
        InitializeCommands(commandManager);
    }

    private static void InitializeCommands(ICommandManager commandManager)
    {
        commandManager.CreateCommandWithGesture(typeof(LogViewerCommands.Logging), "ToggleError");
        commandManager.CreateCommandWithGesture(typeof(LogViewerCommands.Logging), "Clear");
        commandManager.CreateCommandWithGesture(typeof(LogViewerCommands.Logging), "CopyToClipboard");
        commandManager.CreateCommandWithGesture(typeof(LogViewerCommands.Logging), "OpenInEditor");
    }
}