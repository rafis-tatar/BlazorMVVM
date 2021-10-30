public class MyModel: ViewModelBase
{
    public string Name 
    {
        get => Get<string>();
        set => Set(value);
    }
    public int Id
    {
        get => Get<int>();
        set => Set(value);
    }
    
    public string Date
    {
        get => Get<string>();
        set => Set(value);
    }
}