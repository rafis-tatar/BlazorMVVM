using BlazorMVVM.Data;

namespace BlazorMVVM.Pages.Models
{
    public class WeatherModel:ViewModelBase
    {
        public WeatherForecast[] Forecasts
        {
            get => Get<WeatherForecast[]>();
            set => Set(value);
        }
        public string Title
        {
            get=> Get<string>();
            set=> Set(value);
        }        
    }
}
