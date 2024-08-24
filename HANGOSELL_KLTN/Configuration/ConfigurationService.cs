//using System.Globalization;

//namespace HANGOSELL_KLTN.Configuration
//{
//    public static class ConfigurationService
//    {
//        public static void RegisterGlobalizationAndLocalization(this IServiceCollection services)
//        {
//            var defaultCultures = new[]
//            {
//                new CultureInfo("en-US"),
//                new CultureInfo("vi-VN"),
//            };


//            services.Configure<RequestLocalizationOptions>(options =>
//            {
//                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
//                options.SupportedCultures = defaultCultures;
//                options.SupportedUICultures = defaultCultures;
//            });

//            services.AddMvc()
//            .AddDataAnnotationsLocalization(options =>
//            {
//                options.DataAnnotationLocalizerProvider = (type, factory) =>
//                    factory.Create(typeof(Resource));
//            });
//        }
//    }
//}