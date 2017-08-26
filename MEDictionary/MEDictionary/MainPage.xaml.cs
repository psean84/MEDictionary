using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MEDictionary
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<DictionaryClass> DictionaryResults;
        private String _srWord;
        private String _srwEnglishPronunciation;
        private String _srwMarathiPronunciation;

        public MainPage()
        {
            InitializeComponent();

            loadApplicationImages();

            populateDummyData();
            cvResults.ItemsSource = DictionaryResults;

            setClickEventForWordPronunciation();
            setClickEventForBookmark();
            setClickEventForTabs();

        }

        private void setClickEventForWordPronunciation()
        {
            TapGestureRecognizer stackClick = new TapGestureRecognizer();

            stackClick.Tapped += (s, e) =>
            {
                if (lblPronunciation.Text.Equals(_srwEnglishPronunciation))
                    lblPronunciation.Text = _srwMarathiPronunciation;
                else
                    lblPronunciation.Text = _srwEnglishPronunciation;
            };

            stWordPronunciation.GestureRecognizers.Add(stackClick);
        }

        private void setClickEventForBookmark()
        {
            TapGestureRecognizer stackClick = new TapGestureRecognizer();
            stackClick.Tapped += async (s, e) => 
            {
                if (imgBookmark.TranslationY == -40)
                {
                    setBookmark();
                    await imgBookmark.TranslateTo(imgBookmark.X, 0);
                    imgBookmark.TranslationY = 0;
                }
                else
                {
                    removeBookmark();
                    await imgBookmark.TranslateTo(imgBookmark.X, -40);
                    imgBookmark.TranslationY = -40;
                }
            };
            abBookmark.GestureRecognizers.Add(stackClick);
        }

        private void setBookmark()
        {

        }

        private void removeBookmark()
        {

        }

        private void loadApplicationImages()
        {
            imgBookmark.Source = ImageSource.FromResource("MEDictionary.Images.appicons.bookmark.png");
            imgEnglish.Source = ImageSource.FromResource("MEDictionary.Images.appicons.underline.png");
            imgMarathi.Source = ImageSource.FromResource("MEDictionary.Images.appicons.underline.png");
        }

        private void setClickEventForTabs()
        {
            TapGestureRecognizer tabClick = new TapGestureRecognizer();

            tabClick.Tapped += (s, e) =>
            {
                if (frEnglish.Equals(s))
                    cvResults.Position = 0;
                else
                    cvResults.Position = 1;
            };

            frEnglish.GestureRecognizers.Add(tabClick);

            frMarathi.GestureRecognizers.Add(tabClick);
        }

        private void populateDummyData()
        {
            _srWord = "Abrupt";
            _srwEnglishPronunciation = "əˈbrʌpt";
            _srwMarathiPronunciation = "अब्रप्ट";
            DictionaryClass dc = new DictionaryClass();
            dc.setDefinations(new List<String>() { "sudden and unexpected.", "brief to the point of rudeness; curt.", "steep; precipitous." });
            dc.setLanguage(DictionaryClass.Language.English);
            dc.setSentences(new List<String>() { "I was surprised by the abrupt change of subject.", "you were rather abrupt with that young man" });
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    dc.setImage("abrupt.jpg");
                    break;
                default:
                    dc.setImage("Images\\abrupt.jpg");
                    break;
            }
            DictionaryClass dcm = new DictionaryClass();
            dcm.setSentences(new List<string>() { "सुहास अनपेक्षित निघून गेला", "अचानक पाऊस पडू लागला", "अकस्मात शब्द का उपयोग प्रेमचंद ने अपनी कहानी", "दिल्लीत कोणताही निर्णय तडकाफडकी होत नाही हे सर्वज्ञात आहे" });
            dcm.setLanguage(DictionaryClass.Language.Marathi);
            dcm.setDefinations(new List<string>() { "अनपेक्षित", "अचानक", "अकस्मात", "तडकाफडकी" });

            DictionaryResults = new ObservableCollection<DictionaryClass>() { dc, dcm };
            lblPronunciation.Text = _srwEnglishPronunciation;
            lblWord.Text = _srWord;
        }

        private void cvResults_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((DictionaryClass)e.SelectedItem).LanguageUsed == DictionaryClass.Language.English)
            {
                frEnglish.BackgroundColor = Color.LightGray;
                imgEnglish.IsVisible = true;
                frMarathi.BackgroundColor = Color.Transparent;
                imgMarathi.IsVisible = false;
            }
            else
            {
                frEnglish.BackgroundColor = Color.Transparent;
                imgEnglish.IsVisible = false;
                frMarathi.BackgroundColor = Color.LightGray;
                imgMarathi.IsVisible = true;
            }

        }

        private void Frame_SizeChanged(object sender, EventArgs e)
        {
            Frame fr = (Frame)sender;

            fr.WidthRequest = this.Width / 2;
        }
    }
}
