FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CSharpNullBasics/CSharpNullBasics.csproj", "CSharpNullBasics/"]
RUN dotnet restore "CSharpNullBasics/CSharpNullBasics.csproj"
COPY . .
WORKDIR "/src/CSharpNullBasics"
RUN dotnet build "CSharpNullBasics.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSharpNullBasics.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSharpNullBasics.dll"]
