namespace GrowSeeds.ViewModels
{
    using ViewModels;
    public class InformationViewModel : StrainDetailViewModel
    {
        public string perra;
        public string Perra
        {
            get { return this.perra; }
            set { SetProperty(ref this.perra, value); }
        }

        public InformationViewModel()
        {
            this.Perra = PlantName;
        }
           
    }
}
