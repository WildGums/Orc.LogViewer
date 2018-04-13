// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PublicApiFacts.cs" company="WildGums">
//   Copyright (c) 2008 - 2017 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer.Tests
{
    using ApiApprover;
    using NUnit.Framework;

    [TestFixture]
    public class PublicApiFacts
    {
        [Test]
        public void Orc_LogViewer_HasNoBreakingChanges()
        {
            var assembly = typeof(StringToLogEventLevelConverter).Assembly;

            PublicApiApprover.ApprovePublicApi(assembly);
        }
    }
}