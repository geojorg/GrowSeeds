namespace GrowSeeds.ViewModels
{
    using Models;
    using System;
    using Xamarin.Forms;
    [QueryProperty("SeedStrains", "id")]
    public class StrainDetailViewModel : BaseViewModel
    {
        #region Attributes
        //private string id;
        private string name;
        private long rating;
        private TypeEnum type;
        private string effects;
        private string flavor;
        private long thc;
        private long cbd;
        #endregion

        #region Contructor
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

        #endregion
    }
}
