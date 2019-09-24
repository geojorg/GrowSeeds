namespace GrowSeeds.ViewModels
{
    using Models;
    using Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class SearchViewModel : BaseViewModel
    {
        #region Attributes
        public const string strainSourceData = "http://www.geojorgx.com/api/v2/straindata.json";
        public const string strainSourceAPIKey = "";
        private string name2;
        #endregion

        #region Services
        RestService _restService;
        #endregion

        #region Properties
        public static List<WeedStrain> NameofStrains
        {
            get;
            set;
        }
        public string Name2
        {
            get { return this.name2; }
            set { SetProperty(ref this.name2, value); }
        }
        public string Name
        {
            get;
            set;
        }
        #endregion

        #region Constructor 
        public SearchViewModel()
        {
            _restService = new RestService();
            RestService.ConectivityStatus();
            LoadPageEvent();

        }
        #endregion

        #region Method
        private async void LoadPageEvent()
        {   
            var response = await _restService.GetStrainsDataAsync(strainSourceData);
            NameofStrains = new List<WeedStrain>(response.WeedStrains.ToList());
            this.Name2 = "TESTING";
        }
        #endregion
    }
}
