// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReadOnlyBindableCollection.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the ReadOnlyBindableCollection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Components
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    public class ReadOnlyBindableCollection<T> : ReadOnlyObservableCollection<T>, IReadOnlyObservableCollection<T>
    {
        #region Constructors and Destructors

        public ReadOnlyBindableCollection(BindableCollection<T> list)
            : base(list)
        {
            Contract.Requires<ArgumentNullException>(list != null);
        }

        #endregion

        #region Public Properties

        public bool IsNotifying
        {
            get
            {
                return true;
            }

            set
            {
                throw new NotSupportedException();
            }
        }

        #endregion

        #region Public Methods and Operators

        public void AddRange(IEnumerable<T> items)
        {
            throw new NotSupportedException();
        }

        public void NotifyOfPropertyChange(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public void Refresh()
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}