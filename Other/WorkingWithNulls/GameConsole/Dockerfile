FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GameConsole/GameConsole.csproj", "GameConsole/"]
RUN dotnet restore "GameConsole/GameConsole.csproj"
COPY . .
WORKDIR "/src/GameConsole"
RUN dotnet build "GameConsole.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameConsole.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameConsole.dll"]
