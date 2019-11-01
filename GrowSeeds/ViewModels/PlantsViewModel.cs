using GrowSeeds.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GrowSeeds.ViewModels
{
    public class PlantsViewModel : BaseViewModel
    {

        public PlantsViewModel()
        {
            string Days = (DateTime.Today - PlantDate).Days.ToString();
            Application.Current.MainPage.DisplayAlert("TEST", Days, "ok");
        }

        public DateTime PlantDate 
        { 
            get;  
        }
    }
}
    
