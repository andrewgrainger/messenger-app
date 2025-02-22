FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Messenger/Messenger.API/Messenger.API.csproj", "Services/Messenger/Messenger.API/"]
COPY ["Services/Messenger/Messenger.Application/Messenger.Application.csproj", "Services/Messenger/Messenger.Application/"]
COPY ["Services/Messenger/Messenger.Domain/Messenger.Domain.csproj", "Services/Messenger/Messenger.Domain/"]
COPY ["Services/Messenger/Messenger.Infrastructure/Messenger.Infrastructure.csproj", "Services/Messenger/Messenger.Infrastructure/"]
RUN dotnet restore "./Services/Messenger/Messenger.API/Messenger.API.csproj"
COPY . .
WORKDIR "/src/Services/Messenger/Messenger.API"
RUN dotnet build "./Messenger.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Messenger.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Messenger.API.dll"]