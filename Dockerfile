# Etapa 1 - build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . .
RUN dotnet restore CaseApi_NetCon_Geo.Api/CaseApi_NetCon_Geo.Api.csproj
RUN dotnet publish CaseApi_NetCon_Geo.Api -c Release -o out

# Etapa 2 - runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/out .

EXPOSE 8080

ENTRYPOINT ["dotnet", "CaseApi_NetCon_Geo.Api.dll"]