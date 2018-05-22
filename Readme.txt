toutorial video https://youtu.be/E7Voso411Vs


How to change the theme.
1. Goto bootswatch.com
2. Themes->select theme
3. From theme name dropdown on top panel download bootstrap.css
4. Rename it with themename appended
5. Place it under content folder
6. Open bundle.config
7. replace bootstrap.css with new css file


Action results
1. View()
2. Content()
3. PartialView()
4.Redirect()
5.RedirectToAction()
6.Json()
7.File()
8.HttpNotFound()
9. EmptyResult()


/*
             * Here request is routed to this method based on the pattern. View is selected based on the controller and method name.
             * It searches for a folder with controller name and picks the cshtml having the method name.
             * We dont use View bag as it is dynamic and no compile time safety. We dont use ViewData as it depends on magic string and can complicate maintenance as we have to modify both controller and view if the string has to be changed.
             * We only use the model approach.
             * for empty value routing you have to specify route parameters as {month?} also the value should be nullable to accept null. for value types we specify nullable.
             */





Entity Framework.
1.Add reference to Entity framework.
2. Create Entity classes
3. Create DB context class CustomerDbContext
4. Make an actual call and the database will be created by entity framework.
5. Reference to another model in one model is considered as navigation link and key will be generated accordingly. Navigation propery are not loaded at the time of query execution it is lazy loaded.
6. If the code changes, then we have t update the table as mentioned here https://msdn.microsoft.com/en-us/data/jj591621

Sql Server.
1. Make sure sql server is installed and the service is running on the machine.


Authorization and authentication
1. Impersonation is the one which we require t run the server code with the same permission as the logged in user identity. If not then it will run with the same permission as the appdomain
2. When you are running from visual studio, you may not be able to change the authentication settings because these settings can only be changed if the server permits so. In this case, VS setting for the webserver can be found at the root folder of the project .vs\config\applicationhost.config
modify the setting such that the overrideModeDefault="Allow" so that it can be overridden from web.config. Only to the one that you need.

<sectionGroup name="authentication">
                    <section name="anonymousAuthentication" overrideModeDefault="Allow" />
                    <section name="basicAuthentication" overrideModeDefault="Allow" />
                    <section name="clientCertificateMappingAuthentication" overrideModeDefault="Deny" />
                    <section name="digestAuthentication" overrideModeDefault="Deny" />
                    <section name="iisClientCertificateMappingAuthentication" overrideModeDefault="Deny" />
                    <section name="windowsAuthentication" overrideModeDefault="Allow" />
</sectionGroup>



Autherization

1. edit the setting as shown below. ? used for anonymous
<system.web>
    
	<authorization>
      
	  <allow users="vestas\jajac" />

	  <!--<allow roles="guests"/>-->
      
	  <deny users="*"/>  <!--All other users including anonymous are denied.-->    
    
	</authorization>
</system.web>
    

2. Set Authorize attribute on controller or method. Then the setting in config file is not necessory.
[Authorize(Users=@"vestas\other,vestas\jajac")]



Crud operations
Create a new controller using MVC 5 controller with views using entity framework. Select async operation and select the db context


Razor View
1.
