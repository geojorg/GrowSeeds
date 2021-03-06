﻿using GrowSeeds.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using GrowSeeds.ViewModels;
using Xamarin.Forms;

namespace GrowSeeds.Controls
{
    public class StrainsSearchHandler : SearchHandler
    {
        #region Properties
        public Type SelectedItemNavigationTarget { get; set; }
        #endregion

        #region Commands
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);
            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = SearchViewModel.NameofStrains.Where(n => n.Name.StartsWith(newValue, StringComparison.InvariantCultureIgnoreCase));
            }
        }
        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            await Task.Delay(1000);
            await (App.Current.MainPage as Xamarin.Forms.Shell).GoToAsync($"//Detail?id={((WeedStrain)item).Id}");
        }
        #endregion
    }
}

