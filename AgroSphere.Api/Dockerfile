FROM mcr.microsoft.com/dotnet/aspnet:8.0

RUN useradd -m appuser

WORKDIR /app

COPY ./publish .

USER appuser

EXPOSE 8080

ENTRYPOINT ["dotnet", "AgroSphere.Api.dll"]