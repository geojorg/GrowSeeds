namespace GrowSeeds.Control
{
    using Xamarin.Forms;
    using ViewModels;
    using System.Linq;
    using System;
    using System.Threading.Tasks;
    using Models;

    public class StrainsSearchHandler : SearchHandler 
    {
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);
            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = SearchViewModel.NameofStrains.Where(n => n.Name.StartsWith(newValue,StringComparison.InvariantCultureIgnoreCase));
            }
        }
        protected override async void OnItemSelected(object item)
        {
           base.OnItemSelected(item);
           await Task.Delay(1000);
           await (App.Current.MainPage as Xamarin.Forms.Shell).GoToAsync($"//Detail?id={((WeedStrain)item).Id}");
        }
    }
}

