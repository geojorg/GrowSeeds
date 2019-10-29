using GalaSoft.MvvmLight.Command;
using GrowSeeds.Controls;
using GrowSeeds.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace GrowSeeds.ViewModels
{
    [QueryProperty("SeedStrains", "id")]
    public class StrainDetailViewModel : BaseViewModel
    {
        #region Attributes
        private string plantStrain;
        private long rating;
        private TypeEnum plantType;
        private string effects;
        private string flavor;
        private long thc;
        private long cbd;
        private bool isVisible;
        private string plantName;
        private Stage stageSelected;
        private string plantStage;
        private Medium mediumSelected;
        private string plantMedium;
        private string emptyfields;
        private DateTime plantDate;

        #endregion

        #region Contructor
        public StrainDetailViewModel()
        {
            
            IsVisible = false;
            PlantDate = System.DateTime.Now;
            EmptyFields = "Transparent";
            ListStages = StagePicker.GetStages();
            ListMediums = MediumPicker.GetMediums();
        }
      
        public string SeedStrains
        {
            set
            {
                int id = Int32.Parse(value);
                WeedStrain strain = SearchViewModel.NameofStrains[id];
                if (strain != null)
                {
                    PlantStrain = strain.Name;
                    Rating = strain.Rating;
                    PlantType = strain.Type;
                    Effects = strain.Effects;
                    Flavor = strain.Flavor;
                    Thc = strain.Thc;
                    Cbd = strain.Cbd;
                }
            }
        }
        #endregion

        #region Properties
        public DateTime PlantDate
        {
            get { return plantDate; }
            set { SetProperty(ref plantDate, value); }
        }

        public List<Stage> ListStages
        {
            get;
            set;
        }

        public Stage StageSelected
        {
            get { return stageSelected; }
            set { SetProperty(ref stageSelected, value);
                  PlantStage = stageSelected.Item; }
        }

        public string PlantStage
        {
            get { return plantStage; }
            set { SetProperty(ref plantStage, value); }
        }

        public List<Medium> ListMediums
        {
            get;
            set;
        }
        public Medium MediumSelected
        {
            get { return mediumSelected; }
            set
            {
                SetProperty(ref mediumSelected, value);
                PlantMedium = mediumSelected.Item;
            }
        }

        public string PlantMedium
        {
            get { return plantMedium; }
            set { SetProperty(ref plantMedium, value); }
        }
        public string PlantStrain
        {
            get { return plantStrain; }
            set { SetProperty(ref plantStrain, value); }
        }
        public long Rating
        {
            get { return rating; }
            set { SetProperty(ref rating, value); }
        }
        public TypeEnum PlantType
        {
            get { return plantType; }
            set { SetProperty(ref plantType, value); }
        }
        public string Effects
        {
            get { return effects; }
            set { SetProperty(ref effects, value); }
        }
        public string Flavor
        {
            get { return flavor; }
            set { SetProperty(ref flavor, value); }
        }
        public long Thc
        {
            get { return thc; }
            set { SetProperty(ref thc, value); }
        }
        public long Cbd
        {
            get { return cbd; }
            set { SetProperty(ref cbd, value); }
        }
        public bool IsVisible
        {
            get { return isVisible; }
            set { SetProperty(ref isVisible, value); }
        }
        public string PlantName
        {
            get { return plantName; }
            set { SetProperty(ref plantName, value); }
        }
        public string EmptyFields
        {
            get { return emptyfields; }
            set { SetProperty(ref emptyfields, value); }
        }
        #endregion

        #region Command
        public ICommand BackCommand
        {
            get
            {
                return new RelayCommand(Back);
            }
        }
        private void Back()
        {
            Shell.Current.GoToAsync("//AppPage");
        }

        public ICommand CreateCommand
        {
            get
            {
                return new RelayCommand(Create);
            }
        }
        private void Create()
        {
            IsVisible = true;
        }

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(Save);
            }
        }

        private async void Save()
        {
            if (string.IsNullOrEmpty(PlantName) || string.IsNullOrEmpty(PlantStage) || string.IsNullOrEmpty(PlantMedium))
            {
                EmptyFields = "Red";
            }
            else
            {
                await App.Database.SavePlantAsync(new Plant
                {
                    PlantName = PlantName,
                    PlantStage = PlantStage,
                    PlantMedium = PlantMedium,
                    PlantDate = PlantDate.ToString("d"),
                    PlantStrain = PlantStrain,
                    PlantType = PlantType.ToString()
                });

                await Shell.Current.GoToAsync("//PlantsTab");
                PlantName = string.Empty;
                PlantStage = emptyfields;
                PlantDate = System.DateTime.Now;
                IsVisible = false;
                EmptyFields = "Transparent";
            }
        }
        #endregion
    }
}
