FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FirstWebApplication/FirstWebApplication.csproj", "FirstWebApplication/"]
RUN dotnet restore "FirstWebApplication/FirstWebApplication.csproj"
COPY . .
WORKDIR "/src/FirstWebApplication"
RUN dotnet build "FirstWebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FirstWebApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FirstWebApplication.dll"]
