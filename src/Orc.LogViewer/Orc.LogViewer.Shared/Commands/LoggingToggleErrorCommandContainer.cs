// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToggleErrorCommandContainer.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer
{
    using System.Threading.Tasks;
    using Catel.MVVM;

    public class LoggingToggleErrorCommandContainer : CommandContainerBase
    {
        public LoggingToggleErrorCommandContainer(ICommandManager commandManager)
            : base(LogViewerCommands.Logging.ToggleError, commandManager)
        {
        }
        // You should either override ExecuteAsync or Execute. The reason why Execute is not being called
        // is because it's implemented by the base.ExecuteAsync().

        // Watch this.

        protected override async Task ExecuteAsync(object parameter)
        {
            await base.ExecuteAsync(parameter);
        }

        protected override void Execute(object parameter)
        {
           
        }
    }
}