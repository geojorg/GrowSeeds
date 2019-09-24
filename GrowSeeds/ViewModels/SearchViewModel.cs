namespace GrowSeeds.ViewModels
{
    using Models;
    using Services;
    using System.Collections.Generic;
    using System.Linq;

    public class SearchViewModel : BaseViewModel
    {
        #region Attributes
        public const string strainSourceData = "http://www.geojorgx.com/api/v2/straindata.json";
        public const string strainSourceAPIKey = "";
        private bool isLoading;
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
        public bool IsLoading
        {
            get { return this.isLoading; }
            set { SetProperty(ref this.isLoading, value); }
        }
        #endregion

        #region Constructor 
        public SearchViewModel()
        {
            this.IsLoading = true;
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
            this.IsLoading = false;
        }
        #endregion
    }
}
