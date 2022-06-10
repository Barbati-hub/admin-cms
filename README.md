

dotnet tool install --global dotnet-aspnet-codegenerator --version 6.0.5
dotnet add package Microsoft.EntityFrameworkCore --version 6.0.5
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.5
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.5
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.5
dotnet add package Newtonsoft.Json --version 13.0.1
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 6.0.5



*** Depois de tudo pronto usar os comandos ***
dotnet ef migrations add EstruturaInicial
dotnet ef database update
dotnet aspnet-codegenerator controller -name AdministradoresController -m Administrador -dc ContextoCms --relativeFolderPath Controllers --useDefaultLayout