toutorial video https://youtu.be/E7Voso411Vs


















































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

