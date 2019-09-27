namespace GrowSeeds.Models
{
    using System;
    using ViewModels;
    public class UserProfile : BaseViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public Uri Picture { get; set; }
    }
}