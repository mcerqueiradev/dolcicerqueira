# Imagem base para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["wapp_dolcicerqueira/wapp_dolcicerqueira.csproj", "wapp_dolcicerqueira/"]
RUN dotnet restore "wapp_dolcicerqueira/wapp_dolcicerqueira.csproj"
COPY . .
WORKDIR "/src/wapp_dolcicerqueira"
RUN dotnet build "wapp_dolcicerqueira.csproj" -c Release -o /app/build

# Publicação da aplicação
FROM build AS publish
RUN dotnet publish "wapp_dolcicerqueira.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagem final para rodar a aplicação
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "wapp_dolcicerqueira.dll"]
