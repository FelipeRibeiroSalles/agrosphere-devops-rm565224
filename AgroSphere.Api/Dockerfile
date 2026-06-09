# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY . .

RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Criar usuário não-root
RUN useradd -m appuser

WORKDIR /app

COPY --from=build /app/publish .

# Trocar para usuário não-root
USER appuser

EXPOSE 8080

ENTRYPOINT ["dotnet", "AgroSphere.Api.dll"]