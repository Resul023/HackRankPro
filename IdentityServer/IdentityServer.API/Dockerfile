
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["IdentityServer/IdentityServer.API/IdentityServer.API.csproj", "IdentityServer/IdentityServer.API/"]
RUN dotnet restore "IdentityServer/IdentityServer.API/IdentityServer.API.csproj"
COPY . .
WORKDIR "/src/IdentityServer/IdentityServer.API"
RUN dotnet build "IdentityServer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServer.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityServer.API.dll"]