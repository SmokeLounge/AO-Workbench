// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDocumentItem.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IDocumentItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Models.Workbench
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Windows.Input;

    [ContractClass(typeof(IDocumentItemContract))]
    public interface IDocumentItem : IItem
    {
        #region Public Properties

        string Description { get; set; }

        #endregion
    }

    [ContractClassFor(typeof(IDocumentItem))]
    internal abstract class IDocumentItemContract : IDocumentItem
    {
        #region Public Properties

        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Explicit Interface Properties

        ICommand IItem.ActivateCommand
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        bool IItem.CanClose
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        bool IItem.CanFloat
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        ICommand IItem.CloseAllButThisCommand
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        ICommand IItem.CloseCommand
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        string IItem.ContentId
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        string IDocumentItem.Description
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        ICommand IItem.DockAsDocumentCommand
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        ICommand IItem.FloatCommand
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        Uri IItem.IconSource
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        bool IItem.IsActive
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        bool IItem.IsSelected
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        ICommand IItem.MoveToNextTabGroupCommand
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        ICommand IItem.MoveToPreviousTabGroupCommand
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        ICommand IItem.NewHorizontalTabGroupCommand
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        ICommand IItem.NewVerticalTabGroupCommand
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        string IItem.Title
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        string IItem.ToolTip
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}