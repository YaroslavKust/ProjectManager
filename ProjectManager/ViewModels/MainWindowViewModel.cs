using ProjectManager.BL.DTO;
using System.Collections.Generic;
using System.Globalization;

namespace ProjectManager.UI.ViewModels
{
    public class MainWindowViewModel: BaseViewModel
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