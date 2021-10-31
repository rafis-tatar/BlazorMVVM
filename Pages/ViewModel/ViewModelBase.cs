using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.RazorPages;

public abstract class ViewModelBase : INotifyPropertyChanged,IDisposable
{
    Dictionary<string,IValueWrapper> propertys = new();
    public T Get<T>([CallerMemberName] string propertyName = null)
    {
        return propertys.TryGetValue(propertyName, out IValueWrapper _value)?((ValueWrapper<T>)_value).Value:default(T);
    }

    protected void Set<T>( T value, [CallerMemberName] string propertyName = null)
    {
        Set(value, false,  propertyName);
    }

    protected void Set<T>( T value, bool hiden, [CallerMemberName] string propertyName = null)
    {                
        if(propertys.TryGetValue(propertyName, out IValueWrapper _value))
        {
            var wrapper = (ValueWrapper<T>)_value;
            if (EqualityComparer<T>.Default.Equals(wrapper.Value, value)) return ;
            wrapper.Value = value;
        }
        else
        {
            propertys[propertyName] = new ValueWrapper<T>(value);
        }        

        if (hiden) return;
        OnPropertyChanged(propertyName);        
    }
    

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Dispose()
    {
        var delegates = PropertyChanged?.GetInvocationList();
        if(delegates!=null)
        {
            foreach (var item in delegates)
            {
                PropertyChanged-=(PropertyChangedEventHandler)item;
            }
        }        
    }
}