// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IReadOnlyObservableCollection.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IReadOnlyObservableCollection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOWorkbench.Components.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    [ContractClass(typeof(IReadOnlyObservableCollectionContract<>))]
    public interface IReadOnlyObservableCollection<T> : IReadOnlyList<T>, IObservableCollection<T>
    {
    }

    [ContractClassFor(typeof(IReadOnlyObservableCollection<>))]
    internal abstract class IReadOnlyObservableCollectionContract<T> : IReadOnlyObservableCollection<T>
    {
        #region Explicit Interface Events

        event NotifyCollectionChangedEventHandler INotifyCollectionChanged.CollectionChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Explicit Interface Properties

        int IReadOnlyCollection<T>.Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        int ICollection<T>.Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        bool INotifyPropertyChangedEx.IsNotifying
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

        bool ICollection<T>.IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Explicit Interface Indexers

        T IList<T>.this[int index]
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

        T IReadOnlyList<T>.this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Explicit Interface Methods

        void ICollection<T>.Add(T item)
        {
            throw new NotImplementedException();
        }

        void IObservableCollection<T>.AddRange(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Contains(T item)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        int IList<T>.IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        void IList<T>.Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        void INotifyPropertyChangedEx.NotifyOfPropertyChange(string propertyName)
        {
            throw new NotImplementedException();
        }

        void INotifyPropertyChangedEx.Refresh()
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotImplementedException();
        }

        void IList<T>.RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        void IObservableCollection<T>.RemoveRange(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}