#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
ENV ConnectionString "Data Source=host.docker.internal,1433;Initial Catalog=Configurations;Persist Security Info=False;User ID=config;Password=1234;MultipleActiveResultSets=True"

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebEditor/WebEditor.csproj", "WebEditor/"]
RUN dotnet restore "WebEditor/WebEditor.csproj"
COPY . .
WORKDIR "/src/WebEditor"
RUN dotnet build "WebEditor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebEditor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebEditor.dll"]