Copy-pasted from /helpers/UserHelper.cs
 /*
     Setup: 
      Add as a service in startup.cs under ConfigureServices() with the following line: 
        'services.Add(new ServiceDescriptor(typeof(IUserHelperService), typeof(UserHelper), ServiceLifetime.Scoped));'
        
    Usage:
        <CShtml> If you want to use it without a controller:
            put '@inject Webteam2.Helpers.IUserHelperService <name>'(Replace <name> with whatever you wanna call it. ignore <>) 
            anywhere you see fit and then call it with <name>.method() or <name>.property.

        <Controllers>
           1. Add a private readonly IUserHelperService property to your class. ex: 'private readonly IUserHelperService _userHelper;'
           2. Add it to the controller constructor and assign it to your private property. 
           ex: 
                private readonly IUserHelperService _userHelper;
                public HomeController(ILogger<HomeController> logger, IUserHelperService userHelper)
                {
                    _logger = logger;
                    _userHelper = userHelper;
                }
         
    Info: 
        You can see some live examples in /home/inddex 
                                          /Controllers/HomeController
                                          /startup.cs
*/
