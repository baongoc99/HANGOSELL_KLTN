using HANGOSELL_KLTN.Common;
using Microsoft.Extensions.Localization;
using System.Reflection;

namespace HANGOSELL_KLTN.Configuration
{
    public class SharedViewLocalizer
    {
        private readonly IStringLocalizer _localizer;

        public SharedViewLocalizer(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("SharedResource", assemblyName.Name);
        }


        public LocalizedString GetLocalizedString(string key)
        {
            return _localizer[key];
        }
    }
}
