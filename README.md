# ProjectAD

1. Import DB pakai bacpac file
2. Then, pergi Web.config, search connectionStrings, kat add tu.. adjust data source jadi data source korang.. adjust kat server name je..
<br>----------------------------------------------------------------------------------------------------------------------------------------------
Contoh:   <add name="ADprojectEntities" connectionString="metadata=res://*/Models.ADproject.csdl|res://*/Models.ADproject.ssdl|res://*/Models.ADproject.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DESKTOP-S7QPC13\SQLEXPRESS;initial catalog=ADproject;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
<br>----------------------------------------------------------------------------------------------------------------------------------------------
000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000||||||||||||||||||||||||||||||||||||||||||||000000000000000000000000000000000000000000000000
<br>----------------------------------------------------------------------------------------------------------------------------------------------
tukar jadi: <add name="ADprojectEntities" connectionString="metadata=res://*/Models.ADproject.csdl|res://*/Models.ADproject.ssdl|res://*/Models.ADproject.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=<nama server korang>;initial catalog=ADproject;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
<br>------------------------------------------------------------------------------------------------------------------------------------------------
atau delete file  .edmx sekarang then, buat file .edmx baru dengan cara Models > Add > ADO.net Entity Data Model
----------------------------------------------------------------------------------------------------------------------------------------------
rasanya nanti connectionStrings dia akan auto update.. 
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
3. Build the solution
4. Run the solution (with/ without debugging)
5. Kalau ada problem boleh create Issues kat Repo ni..
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------