using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.LazyLoad.ValueHolder
{
    // May be preferable to just use Lazy<T> that's built in to the .Net Framework
    public class ValueHolder<T>
    {

        public ValueHolder(IValueLoader<T> loader)
        {
            Loader = loader;
        }

        IValueLoader<T> Loader { get; }

        T _value = default!;
        public T Value
        { 
            get
            {
                if (_value == null)
                    _value = Loader.Load();

                return _value;
            }
        }
    }
}
