#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Exchange.Api/Exchange.Api.csproj", "src/Exchange.Api/"]
COPY ["src/Exchange.Infrastructure/Exchange.Infrastructure.csproj", "src/Exchange.Infrastructure/"]
COPY ["src/Exchange.Application/Exchange.Application.csproj", "src/Exchange.Application/"]
COPY ["src/Exchange.Domain/Exchange.Domain.csproj", "src/Exchange.Domain/"]
RUN dotnet restore "src/Exchange.Api/Exchange.Api.csproj"
COPY . .
WORKDIR "/src/src/Exchange.Api"
RUN dotnet build "Exchange.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Exchange.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Exchange.Api.dll"]