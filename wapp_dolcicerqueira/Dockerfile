#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["wapp_dolcicerqueira/wapp_dolcicerqueira.csproj", "wapp_dolcicerqueira/"]
COPY ["Domain/wapp_dolcicerqueira.Domain.csproj", "Domain/"]
COPY ["wapp_dolcicerqueira.Services/wapp_dolcicerqueira.Services.csproj", "wapp_dolcicerqueira.Services/"]
COPY ["wapp_dolcicerqueira.Repositories/wapp_dolcicerqueira.Repositories.csproj", "wapp_dolcicerqueira.Repositories/"]
RUN dotnet restore "./wapp_dolcicerqueira/wapp_dolcicerqueira.csproj"
COPY . .
WORKDIR "/src/wapp_dolcicerqueira"
RUN dotnet build "./wapp_dolcicerqueira.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./wapp_dolcicerqueira.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "wapp_dolcicerqueira.dll"]