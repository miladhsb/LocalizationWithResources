# Localization With Resources

add config in program.cs

 builder.Services
           .AddLocalization(options => options.ResourcesPath = "Resources");

            builder.Services
                .AddControllersWithViews()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                const string defaultCulture = "fa";//or fa
                var supportedCultures = new[]
                {
               new CultureInfo("fa-IR"),//or fa
               new CultureInfo("en")//or en-GB
    };
                options.RequestCultureProviders.Clear();

                options.RequestCultureProviders.Add(new CookieRequestCultureProvider());
                options.RequestCultureProviders.Add(new QueryStringRequestCultureProvider());
                //options.RequestCultureProviders.Add(new AcceptLanguageHeaderRequestCultureProvider());
                //options.RequestCultureProviders.Add(new RouteDataRequestCultureProvider());


                options.DefaultRequestCulture = new RequestCulture(defaultCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            

