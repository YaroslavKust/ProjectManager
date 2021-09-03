using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;

namespace ProjectManager.UI
{
    public static class LanguageManager
    {
        private const string _path = "Sources/Languages/lang.";

        private static List<CultureInfo> _languages = new List<CultureInfo>();

        public static List<CultureInfo> Languages => _languages;

        public static CultureInfo Language
        {
            get => Thread.CurrentThread.CurrentUICulture;

            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                if (value == Thread.CurrentThread.CurrentUICulture) return;

                Thread.CurrentThread.CurrentUICulture = value;

                var dictionary = new ResourceDictionary();

                switch (value.Name)
                {
                    case "ru-RU":
                        dictionary.Source = new Uri(_path + $"{value.Name}.xaml", UriKind.Relative);
                        break;
                    default:
                        dictionary.Source = new Uri(_path + "xaml", UriKind.Relative);
                        break;
                }

                var oldDictionary = Application.Current.Resources.MergedDictionaries
                    .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.StartsWith(_path));

                if (oldDictionary != null)
                {
                    int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDictionary);
                    Application.Current.Resources.MergedDictionaries.Remove(oldDictionary);
                    Application.Current.Resources.MergedDictionaries.Insert(ind, dictionary);
                }
                else
                {
                    Application.Current.Resources.MergedDictionaries.Add(dictionary);
                }
            }
        }
    }
}