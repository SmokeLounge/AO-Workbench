// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessLoadedEvent.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ProcessLoadedEvent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Components.Events
{
    using System;

    public class ProcessLoadedEvent
    {
        #region Fields

        private readonly Guid processId;

        #endregion

        #region Constructors and Destructors

        public ProcessLoadedEvent(Guid processId)
        {
            this.processId = processId;
        }

        #endregion

        #region Public Properties

        public Guid ProcessId
        {
            get
            {
                return this.processId;
            }
        }

        #endregion
    }
}