namespace GrowSeeds.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;
    using Xamarin.Forms;
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
        #endregion

        #region Contructor
        public StrainDetailViewModel()
        {
            this.IsVisible = false;
            Stages = new List<StageInfo>();
            Stages.Add(new StageInfo
            { 
                Stage = "Germination",
                Medium = "Soil"
            });
            Stages.Add(new StageInfo
            { 
                Stage = "Seedling",
                Medium = "Compost"
            });
            Stages.Add(new StageInfo
            {
                Stage = "Vegetative",
                Medium = "Coco"
            }) ;
            Stages.Add(new StageInfo
            { 
                Stage = "Flowering",
                Medium = "Hydro"
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
                    this.Name = strain.Name;
                    this.Rating = strain.Rating;
                    this.Type = strain.Type;
                    this.Effects = strain.Effects;
                    this.Flavor = strain.Flavor;
                    this.Thc = strain.Thc;
                    this.Cbd = strain.Cbd;
                }
            }
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return this.name; }
            set { SetProperty(ref this.name, value); }
        }
        public long Rating
        {
            get { return this.rating; }
            set { SetProperty(ref this.rating, value); }
        }
        public TypeEnum Type
        {
            get { return this.type; }
            set { SetProperty(ref this.type, value); }
        }
        public string Effects
        {
            get { return this.effects; }
            set { SetProperty(ref this.effects, value); }
        }
        public string Flavor
        {
            get { return this.flavor; }
            set { SetProperty(ref this.flavor, value); }
        }
        public long Thc
        {
            get { return this.thc; }
            set { SetProperty(ref this.thc, value); }
        }
        public long Cbd
        {
            get { return this.cbd; }
            set { SetProperty(ref this.cbd, value); }
        }
        public bool IsVisible
        {
            get { return this.isVisible; }
            set { SetProperty(ref this.isVisible, value); }
        }
        public IList<StageInfo> Stages
        {
            get;
            set;
        }
        public string PlantName
        {
            get { return this.plantName; }
            set { SetProperty(ref this.plantName, value); }
        }

        public object StageSelected
        {
            get { return this.stageSelected; }
            set { SetProperty(ref this.stageSelected, value); }
        }
        public object MediumSelected
        {
            get { return this.mediumSelected; }
            set { SetProperty(ref this.mediumSelected, value); }
        }
        public object DateSelected
        {
            get { return this.dateSelected; }
            set { SetProperty(ref this.dateSelected, value); }
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
            
            Shell.Current.GoToAsync("//InfoTab");
            this.PlantName = string.Empty;
            this.StageSelected = null;
            this.MediumSelected = null;
            this.DateSelected = System.DateTime.Now;
            this.IsVisible = false;
        }
        #endregion
    }
}
