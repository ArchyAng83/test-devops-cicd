FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["TestDevOpsApp.WebApi/TestDevOpsApp.WebApi.csproj", "TestDevOpsApp.WebApi/"]
COPY ["TestDevOpsApp.Domain/TestDevOpsApp.Domain.csproj", "TestDevOpsApp.Domain/"]
COPY ["TestDevOpsApp.Infrastructure/TestDevOpsApp.Infrastructure.csproj", "TestDevOpsApp.Infrastructure/"]
COPY ["TestDevOpsApp.Application/TestDevOpsApp.Application.csproj", "TestDevOpsApp.Application/"]
COPY ["TestDevOpsApp.slnx", "./"]

RUN dotnet restore "TestDevOpsApp.WebApi/TestDevOpsApp.WebApi.csproj"

COPY . .
WORKDIR "/src/TestDevOpsApp.WebApi"
RUN dotnet publish "TestDevOpsApp.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TestDevOpsApp.WebApi.dll"]