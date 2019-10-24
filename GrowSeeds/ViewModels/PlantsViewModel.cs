using GrowSeeds.Models;
using GrowSeeds.Services;
using GrowSeeds.Views;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace GrowSeeds.ViewModels
{
    public class PlantsViewModel : BaseViewModel
    {
        public ObservableCollection<Plant> Plants { get; set; }

        public PlantsViewModel()
        {
            Plants = new ObservableCollection<Plant>();

            MessagingCenter.Subscribe<StrainDetailPage, string>(this, "AddItem", async (obj, item) =>
            {
                await Application.Current.MainPage.DisplayAlert("Message received", "arg=" + item, "OK");
                //var newPlant = item as Plant;
                //Plants.Add(newPlant);
                //await DataStore.AddItemAsync(newPlant);
            });
        }
    }
    }
