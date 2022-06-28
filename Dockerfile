
  FROM mcr.microsoft.com/dotnet/sdk:3.1
  ARG BUILD_CONFIGURATION=Debug
  ENV ASPNETCORE_ENVIRONMENT=Development
  ENV DOTNET_USE_POLLING_FILE_WATCHER=true  
  ENV ASPNETCORE_URLS=http://+:80  
  EXPOSE 80
  COPY publish/ app/
  WORKDIR /app
  ENTRYPOINT ["dotnet", "Exchange.Api.dll"]