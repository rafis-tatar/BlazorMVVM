public class ValueWrapper<T> : IValueWrapper 
{
    public T Value { get; set; }
    object IValueWrapper.Value 
    { 
        get { return Value; }
        set { this.Value = (T)value; }
    }
    public bool HasValue { get=>this.Value!=null; }

    public ValueWrapper() {}

    public ValueWrapper(T value) 
    {
        this.Value = value;        
    }
}
