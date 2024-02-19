#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CanDatabaseManagementSystem.WebApi/CanDatabaseManagementSystem.WebApi.csproj", "CanDatabaseManagementSystem.WebApi/"]
COPY ["CanDatabaseManagementSystem.DAL/CanDatabaseManagementSystem.DAL.csproj", "CanDatabaseManagementSystem.DAL/"]
COPY ["DomainModels/DomainModels.csproj", "DomainModels/"]
COPY ["CanDatabaseManagementSystem.IOC/CanDatabaseManagementSystem.IOC.csproj", "CanDatabaseManagementSystem.IOC/"]
RUN dotnet restore "./CanDatabaseManagementSystem.WebApi/./CanDatabaseManagementSystem.WebApi.csproj"
COPY . .
WORKDIR "/src/CanDatabaseManagementSystem.WebApi"
RUN dotnet build "./CanDatabaseManagementSystem.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CanDatabaseManagementSystem.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CanDatabaseManagementSystem.WebApi.dll"]