namespace GrowSeeds
{
    using System;
    using Xamarin.Essentials;
    using Xamarin.Forms;
    public class HyperlinkSpan : Span
    {
        public static readonly BindableProperty UrlProperty = BindableProperty.Create(nameof(Url), typeof(string), typeof(HyperlinkSpan), null);

        public string Url
        {
            get { return (string)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }
        public HyperlinkSpan()
        {
            TextDecorations = TextDecorations.Underline;
            GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => Launcher.OpenAsync(new Uri(Url)))
            });
        }
    }
}