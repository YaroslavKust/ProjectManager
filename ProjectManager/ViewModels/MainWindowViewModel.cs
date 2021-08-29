using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using ProjectManager.BL.DTO;
using ProjectManager.UI.Common;

namespace ProjectManager.UI.ViewModels
{
    public class MainWindowViewModel
    {
        private CultureInfo _selectedLang;
        public IEnumerable<CultureInfo> Languages => LanguageManager.Languages;

        public CultureInfo SelectedLang
        {
            get => _selectedLang;
            set
            {
                _selectedLang = value;
                LanguageManager.Language = value;
            }
        }
    }
}