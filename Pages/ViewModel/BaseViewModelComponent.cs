using BlazorMVVM.Pages.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace BlazorMVVM.Pages.ViewModel
{
    public abstract class BaseViewModelComponent<TDataContext> : ComponentBase, IDisposable where TDataContext : INotifyPropertyChanged
    {
        [Parameter] public TDataContext DataContext { get; set; }

        protected override void OnInitialized()
        {
            DataContext.PropertyChanged += OnContextPropertyChanged;
            base.OnInitialized();
            if (Debugger.IsAttached) Console.WriteLine($"{this.GetType().Name} OnInitialized");
        }
        public virtual void OnContextPropertyChanged(object sender, PropertyChangedEventArgs arg)
        {
            StateHasChanged();
            if (Debugger.IsAttached) Console.WriteLine($"{this.GetType().Name} OnContextPropertyChanged: Property={arg.PropertyName}");
        }
        public virtual void Dispose() 
        { 
            DataContext.PropertyChanged -= OnContextPropertyChanged;
            if (Debugger.IsAttached) Console.WriteLine($"{this.GetType().Name} Dispose");
        }
    }      


}