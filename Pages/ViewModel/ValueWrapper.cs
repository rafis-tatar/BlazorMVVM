public class ValueWrapper<T> : IValueWrapper 
{
    public T Value { get; set; }
    object IValueWrapper.Value 
    { 
        get { return Value; }
        set { this.Value = (T)value; }
    }
    public bool HasValue { get; set; }

    public ValueWrapper() 
    {
        this.HasValue = false;
    }

    public ValueWrapper(T value) 
    {
        this.Value = value;
        this.HasValue = value != null;
    }
}
