# ProjectAD

1. Import DB pakai bacpac file<br>
2. Then, pergi Web.config, search connectionStrings, kat add tu.. adjust data source jadi data source korang.. adjust kat server name je..
<br>
----------------------------------------------------------------------------------------------------------------------------------------------
<br>
Contoh: -- buang dash kat add dari <-add kepada < add 
<br>
<code>
<-add name="ADprojectEntities" connectionString="metadata=res://*/Models.ADproject.csdl|res://*/Models.ADproject.ssdl|res://*/Models.ADproject.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DESKTOP-S7QPC13\SQLEXPRESS;initial catalog=ADproject;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
</code>
<br>----------------------------------------------------------------------------------------------------------------------------------------------<br>
<br>----------------------------------------------------------------------------------------------------------------------------------------------<br>
tukar jadi: -- buang dash kat add <br>
<code>
<-add name="ADprojectEntities" connectionString="metadata=res://*/Models.ADproject.csdl|res://*/Models.ADproject.ssdl|res://*/Models.ADproject.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source={<b>```@@nama server korang@@```</b>};initial catalog=ADproject;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
</code>
<br>------------------------------------------------------------------------------------------------------------------------------------------------<br>
atau delete file  .edmx ngan file model2 atau .cs yang lain.. then, buat file .edmx baru dengan cara Models > Add > ADO.net Entity Data Model
<br>
rasanya nanti connectionStrings dia akan auto update.. 
<br><br><br>
3. Build the solution<br>
4. Run the solution (with/ without debugging)<br>
5. Kalau ada problem boleh create Issues kat Repo ni..<br>
<br>---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------<br>
