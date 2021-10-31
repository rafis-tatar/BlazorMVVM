using BlazorMVVM.Pages.Models;

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

    public WeatherModel FatchDataModel{
        get => Get<WeatherModel>();
        set => Set(value);
    }
    public MyModel()
    {
        FatchDataModel = new()
            {
                Title = "Test "
            };
    }
}