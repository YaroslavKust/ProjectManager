using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.Services
{
    static class LocalizationService
    {
        public static void SetLanguage(string language) =>
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(language);
    }

}
