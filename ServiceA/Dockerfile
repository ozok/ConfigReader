#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
ENV ConnectionString "Data Source=host.docker.internal,1433;Initial Catalog=Configurations;Persist Security Info=False;User ID=config;Password=1234;MultipleActiveResultSets=True"
ENV ApplicationName "SERVICE-A"
ENV RefreshTimerIntervalInMs 10000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ServiceA/ServiceA.csproj", "ServiceA/"]
COPY ["ConfigurationReader/ConfigurationReader.csproj", "ConfigurationReader/"]
COPY ["Models/Models.csproj", "Models/"]
RUN dotnet restore "ServiceA/ServiceA.csproj"
COPY . .
WORKDIR "/src/ServiceA"
RUN dotnet build "ServiceA.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServiceA.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceA.dll"]