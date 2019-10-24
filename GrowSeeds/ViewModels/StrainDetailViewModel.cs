using GalaSoft.MvvmLight.Command;
using GrowSeeds.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using GrowSeeds.Helpers;

namespace GrowSeeds.ViewModels
{
    [QueryProperty("SeedStrains", "id")]
    public class StrainDetailViewModel : BaseViewModel
    {
        #region Attributes
        private string name;
        private long rating;
        private TypeEnum type;
        private string effects;
        private string flavor;
        private long thc;
        private long cbd;
        private bool isVisible;
        private string plantName;
        private object stageSelected;
        private object mediumSelected;
        private object dateSelected;
        private string emptyfields;

        #endregion

        #region Contructor
        public StrainDetailViewModel()
        {
            IsVisible = false;
            EmptyFields = "Transparent";

            Stages = new List<StageInfo>();
            Stages.Add(new StageInfo
            {
                Stage = Languages.Germination,
                Medium = Languages.Soil
            });
            Stages.Add(new StageInfo
            {
                Stage = Languages.Seedling,
                Medium = Languages.Compost
            });
            Stages.Add(new StageInfo
            {
                Stage = Languages.Vegetative,
                Medium = Languages.Coco
            });
            Stages.Add(new StageInfo
            {
                Stage = Languages.Flowering,
                Medium = Languages.Hydro
            });
        }

        public string SeedStrains
        {
            set
            {
                int id = Int32.Parse(value);
                WeedStrain strain = SearchViewModel.NameofStrains[id];
                if (strain != null)
                {
                    Name = strain.Name;
                    Rating = strain.Rating;
                    Type = strain.Type;
                    Effects = strain.Effects;
                    Flavor = strain.Flavor;
                    Thc = strain.Thc;
                    Cbd = strain.Cbd;
                }
            }
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        public long Rating
        {
            get { return rating; }
            set { SetProperty(ref rating, value); }
        }
        public TypeEnum Type
        {
            get { return type; }
            set { SetProperty(ref type, value); }
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
        public IList<StageInfo> Stages
        {
            get;
            set;
        }
        public string PlantName
        {
            get { return plantName; }
            set { SetProperty(ref plantName, value); }
        }

        public object StageSelected
        {
            get { return stageSelected; }
            set { SetProperty(ref stageSelected, value); }
        }
        public object MediumSelected
        {
            get { return mediumSelected; }
            set { SetProperty(ref mediumSelected, value); }
        }
        public object DateSelected
        {
            get { return dateSelected; }
            set { SetProperty(ref dateSelected, value); }
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
            this.IsVisible = true;
        }

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(Save);
            }
        }

        private void Save()
        {
            if (string.IsNullOrEmpty(PlantName) || (StageSelected==null) || (MediumSelected==null) )
            {
                EmptyFields = "Red";
            }
            else
            {
                Shell.Current.GoToAsync("//InfoTab");
                MessagingCenter.Send(PlantName, "AddItem");
                PlantName = string.Empty;
                StageSelected = null;
                MediumSelected = null;
                DateSelected = System.DateTime.Now;
                IsVisible = false;
                EmptyFields = "Transparent";
            }
        }
        #endregion
    }

}
