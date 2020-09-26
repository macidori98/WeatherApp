using System.ComponentModel;

using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
  public class WeatherVM : INotifyPropertyChanged
  {
    public WeatherVM()
    {
      //csak akkor jelennek meg az ertekek amikor design modban vagyunk
      if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
      {
        this.SelectedCity = new City()
        {
          LocalizedName = "New York"
        };

        this.CurrentCondition = new CurrentCondition()
        {
          WeatherText = "Partly cloudy",
          Temperature = new Temperature()
          {
            Metric = new Units()
            {
              Value = 21
            }
          }
        };
      }
    }

    private string query;

    public string Query
    {
      get { return this.query; }
      set
      {
        this.query = value;
        this.OnPropertyChanged("Query");
      }
    }

    private CurrentCondition currentCondition;

    public CurrentCondition CurrentCondition
    {
      get { return this.currentCondition; }
      set
      {
        this.currentCondition = value;
        this.OnPropertyChanged("CurrentCondition");
      }
    }

    private City selectedCity;

    public City SelectedCity
    {
      get { return this.selectedCity; }
      set
      {
        this.selectedCity = value;
        this.OnPropertyChanged("SelectedCity");
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName) // trigerring the event
    {
      this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}