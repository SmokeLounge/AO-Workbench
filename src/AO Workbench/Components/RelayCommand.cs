// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelayCommand.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the RelayCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Components
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Windows.Input;

    public class RelayCommand : ICommand
    {
        #region Fields

        private readonly Predicate<object> canExecute;

        private readonly Action<object> execute;

        #endregion

        #region Constructors and Destructors

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            Contract.Requires(execute != null);

            this.execute = execute;
            this.canExecute = canExecute;
        }

        #endregion

        #region Public Events

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        #endregion

        #region Public Methods and Operators

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        #endregion
    }
}