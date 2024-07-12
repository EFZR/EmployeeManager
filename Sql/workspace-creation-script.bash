dotnet new sln
mkdir Application
mkdir Domain
mkdir Infrastructure
mkdir Transversal
mkdir Service

dotnet new classlib -n Application.DTO -o ./Application/Application.DTO
dotnet new classlib -n Application.Main -o ./Application/Application.Main
dotnet new classlib -n Application.Interface -o ./Application/Application.Interface
dotnet new classlib -n Domain.Core -o ./Domain/Domain.Core
dotnet new classlib -n Domain.Entity -o ./Domain/Domain.Entity
dotnet new classlib -n Domain.Interface -o ./Domain/Domain.Interface
dotnet new classlib -n Infrastructure.Data -o ./Infrastructure/Infrastructure.Data
dotnet new classlib -n Infrastructure.Repository -o ./Infrastructure/Infrastructure.Repository
dotnet new classlib -n Infrastructure.Interface -o ./Infrastructure/Infrastructure.Interface
dotnet new classlib -n Transversal.Common -o ./Transversal/Transversal.Common
dotnet new classlib -n Transversal.Logging -o ./Transversal/Transversal.Logging
dotnet new classlib -n Transversal.Mapping -o ./Transversal/Transversal.Mapping
dotnet new webapi -o ./Service/Service.EmployeeManagementAPI

dotnet sln add ./Application/Application.DTO
dotnet sln add ./Application/Application.Main
dotnet sln add ./Application/Application.Interface
dotnet sln add ./Domain/Domain.Core
dotnet sln add ./Domain/Domain.Entity
dotnet sln add ./Domain/Domain.Interface
dotnet sln add ./Infrastructure/Infrastructure.Data
dotnet sln add ./Infrastructure/Infrastructure.Repository
dotnet sln add ./Infrastructure/Infrastructure.Interface
dotnet sln add ./Transversal/Transversal.Common
dotnet sln add ./Transversal/Transversal.Logging
dotnet sln add ./Transversal/Transversal.Mapping
dotnet sln add ./Service/Service.EmployeeManagementAPI

dotnet add ./Application/Application.Main/ package Automapper --version 12.0.1
dotnet add ./Infrastructure/Infrastructure.Data/ package Microsoft.AspNetCore.Hosting
dotnet add ./Infrastructure/Infrastructure.Data/ package Microsoft.Data.Sqlite
dotnet add ./Infrastructure/Infrastructure.Data/ package Microsoft.Extensions.Configuration
dotnet add ./Infrastructure/Infrastructure.Data/ package System.Data.SqlClient
dotnet add ./Infrastructure/Infrastructure.Repository/ package Dapper
dotnet add ./Service/Service.EmployeeManagementAPI/ package Automapper --version 12.0.1
dotnet add ./Service/Service.EmployeeManagementAPI/ package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1
dotnet add ./Service/Service.EmployeeManagementAPI/ package Microsoft.AspNetCore.Authentication.JwtBearer --version 7.0.7
dotnet add ./Service/Service.EmployeeManagementAPI/ package Microsoft.AspNetCore.OpenApi --version 7.0.10
dotnet add ./Service/Service.EmployeeManagementAPI/ package Swashbuckle.AspNetCore
dotnet add ./Transversal/Transversal.Common/ package Microsoft.Data.Sqlite
dotnet add ./Transversal/Transversal.Common/ package System.Data.SqlClient
dotnet add ./Transversal/Transversal.Logging/ package Automapper --version 12.0.1
dotnet add ./Transversal/Transversal.Logging/ package Microsoft.Extensions.Logging
dotnet add ./Transversal/Transversal.Mapping/ package Automapper --version 12.0.1

dotnet add ./Application/Application.Interface/ reference ./Application/Application.DTO/Application.DTO.csproj
dotnet add ./Application/Application.Interface/ reference ./Transversal/Transversal.Common/Transversal.Common.csproj
dotnet add ./Application/Application.Main/ reference ./Application/Application.DTO/Application.DTO.csproj
dotnet add ./Application/Application.Main/ reference ./Application/Application.Interface/Application.Interface.csproj
dotnet add ./Application/Application.Main/ reference ./Domain/Domain.Interface/Domain.Interface.csproj
dotnet add ./Application/Application.Main/ reference ./Domain/Domain.Entity/Domain.Entity.csproj
dotnet add ./Application/Application.Main/ reference ./Transversal/Transversal.Common/Transversal.Common.csproj
dotnet add ./Domain/Domain.Core/ reference ./Domain/Domain.Entity/Domain.Entity.csproj
dotnet add ./Domain/Domain.Core/ reference ./Domain/Domain.Interface/Domain.Interface.csproj
dotnet add ./Domain/Domain.Core/ reference ./Infrastructure/Infrastructure.Interface/Infrastructure.Interface.csproj
dotnet add ./Domain/Domain.Core/ reference ./Transversal/Transversal.Common/Transversal.Common.csproj
dotnet add ./Domain/Domain.Interface/ reference ./Domain/Domain.Entity/Domain.Entity.csproj
dotnet add ./Domain/Domain.Interface/ reference ./Application/Application.DTO/Application.DTO.csproj
dotnet add ./Infrastructure/Infrastructure.Data/ reference ./Transversal/Transversal.Common/Transversal.Common.csproj
dotnet add ./Infrastructure/Infrastructure.Interface/ reference ./Domain/Domain.Entity/Domain.Entity.csproj
dotnet add ./Infrastructure/Infrastructure.Repository/ reference ./Infrastructure/Infrastructure.Data/Infrastructure.Data.csproj
dotnet add ./Infrastructure/Infrastructure.Repository/ reference ./Infrastructure/Infrastructure.Interface/Infrastructure.Interface.csproj
dotnet add ./Infrastructure/Infrastructure.Repository/ reference ./Transversal/Transversal.Common/Transversal.Common.csproj
dotnet add ./Transversal/Transversal.Logging/ reference ./Transversal/Transversal.Common/Transversal.Common.csproj
dotnet add ./Transversal/Transversal.Mapping/ reference ./Domain/Domain.Entity/Domain.Entity.csproj
dotnet add ./Transversal/Transversal.Mapping/ reference ./Application/Application.DTO/Application.DTO.csproj
dotnet add ./Service/Service.EmployeeManagementAPI/ reference ./Transversal/Transversal.Common/Transversal.Common.csproj
dotnet add ./Service/Service.EmployeeManagementAPI/ reference ./Transversal/Transversal.Logging/Transversal.Logging.csproj
dotnet add ./Service/Service.EmployeeManagementAPI/ reference ./Transversal/Transversal.Mapping/Transversal.Mapping.csproj
dotnet add ./Service/Service.EmployeeManagementAPI/ reference ./Infrastructure/Infrastructure.Data/Infrastructure.Data.csproj
dotnet add ./Service/Service.EmployeeManagementAPI/ reference ./Infrastructure/Infrastructure.Interface/Infrastructure.Interface.csproj
dotnet add ./Service/Service.EmployeeManagementAPI/ reference ./Infrastructure/Infrastructure.Repository/Infrastructure.Repository.csproj
dotnet add ./Service/Service.EmployeeManagementAPI/ reference ./Domain/Domain.Core/Domain.Core.csproj
dotnet add ./Service/Service.EmployeeManagementAPI/ reference ./Domain/Domain.Entity/Domain.Entity.csproj
dotnet add ./Service/Service.EmployeeManagementAPI/ reference ./Domain/Domain.Interface/Domain.Interface.csproj
dotnet add ./Service/Service.EmployeeManagementAPI/ reference ./Application/Application.DTO/Application.DTO.csproj
dotnet add ./Service/Service.EmployeeManagementAPI/ reference ./Application/Application.Interface/Application.Interface.csproj
dotnet add ./Service/Service.EmployeeManagementAPI/ reference ./Application/Application.Main/Application.Main.csproj