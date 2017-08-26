using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MEDictionary
{
    public class DictionaryClass
    {
        public enum Language { English, Marathi };
        public String ExampleImageURL { get; private set; }
        public String Sentences { get; private set; }
        public String Definations { get; private set; }
        public String SentencesLabel { get; private set; }
        public Language LanguageUsed { get; private set; }
        
        public DictionaryClass()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    ExampleImageURL = "notfound.png";
                    break;
                default:
                    ExampleImageURL = "Images\\notfound.png";
                    break;
            }
            Definations = "";
            Sentences = "";
        }

        public void setImage(string imageURL)
        {
            ExampleImageURL = imageURL;
        }

        public void setDefinations(List<String> defns)
        {
            foreach(string s in defns)
            {
                Definations += s + "\n";
            }
        }

        public void setSentences(List<String> ss)
        {
            foreach (String s in ss)
                Sentences += s + "\n";
        }

        public void addSentences(String sentence)
        {
            Sentences += sentence + "\n";
        }


        public void addDefination(String def)
        {
            Definations += def + "\n";
        }
        
        public void setLanguage(Language l)
        {
            LanguageUsed = l;
            if (l == Language.English)
                SentencesLabel = "Sentances example: ";
            else
                SentencesLabel = "वाक्य उदाहरण: ";
        }
        
    }
}
