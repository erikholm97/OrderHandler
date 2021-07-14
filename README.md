# OrderHandler
<h3>An ASP.NET with Entity Core Framework backend for handeling and creating orders.</h3>

Dependencies: EntityFrameworkCore, EntityFrameworkCore.Design, EntityFrameworkCore.SqlServer, Microsoft.VisualStudio.Web.CodeGeneration.Design.

<b>To start locate OrderHandler Folder in FileExplorer and open powershell.</b> 

<b>dotnet tool install --global dotnet-ef</b></br>

<b>dotnet add package Microsoft.EntityFrameworkCore.Design</b></br>

<b>Run: dotnet ef database update --startup-project OrderHandler</b></br>

<b>dotnet run --project OrderHandler.UI</b>

<hr/>
<h4>Additional commands for handling database:</h4>
<h5>Add migration</h5>
<p>dotnet ef --startup-project OrderHandler.UI/OrderHandler.UI.csproj migrations add InitialModel -p OrderHandler.UI.Data/OrderHandler.UI.Data.csproj</p>
<h5>Update database from root</h5>
<p>dotnet ef --startup-project OrderHandler.UI/OrderHandler.UI.csproj database update</p>
<h5>Drop database</h5>
<p>dotnet ef --startup-project OrderHandler.UI/OrderHandler.UI.csproj database drop</p>
<hr/>

![Picture of frontpage](https://user-images.githubusercontent.com/54987631/125422131-d10aa365-6b00-4552-89ce-398ea698a818.PNG)
