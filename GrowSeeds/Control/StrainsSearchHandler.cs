namespace GrowSeeds.Control
{
    using Xamarin.Forms;
    using ViewModels;
    using System.Linq;
    using System.Threading.Tasks;

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
                ItemsSource = SearchViewModel.NameofStrains.Where(n => n.Name.ToLower().StartsWith(newValue));
            }
        }
        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            await Task.Delay(1000);
            //await Shell.Current.GoToAsync($"monkeydetails?name={((Animal)item).Name}");
        }
    }
}

