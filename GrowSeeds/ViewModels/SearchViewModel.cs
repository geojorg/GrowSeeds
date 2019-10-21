using GrowSeeds.Models;
using GrowSeeds.Services;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace GrowSeeds.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        #region Attributes
        public const string strainSourceData = "http://www.geojorgx.com/api/v2/straindata.json";
        public const string strainSourceAPIKey = "";
        private bool isLoading;
        private SearchBoxVisibility isVisible;
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
        public SearchBoxVisibility IsVisible
        {
            get { return this.isVisible; }
            set { SetProperty(ref this.isVisible, value); }
        }
        #endregion

        #region Constructor 
        public SearchViewModel()
        {
            this.IsLoading = true;
            this.IsVisible = SearchBoxVisibility.Hidden;
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
            this.IsVisible = SearchBoxVisibility.Collapsible;
        }
        #endregion
    }
}
