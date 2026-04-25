# Etapa 1 - build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore CaseApi_NetCon_Geo.Api/CaseApi_NetCon_Geo.Api.csproj
RUN dotnet publish CaseApi_NetCon_Geo.Api/CaseApi_NetCon_Geo.Api.csproj -c Release -o /app/publish

# Etapa 2 - runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "CaseApi_NetCon_Geo.Api.dll"]