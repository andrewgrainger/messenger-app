FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Gateways/Ocelot.Gateway/Ocelot.Gateway.csproj", "Gateways/Ocelot.Gateway/"]
RUN dotnet restore "Gateways/Ocelot.Gateway/Ocelot.Gateway.csproj"
COPY . .
WORKDIR "/src/Gateways/Ocelot.Gateway"
RUN dotnet build "Ocelot.Gateway.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Ocelot.Gateway.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ocelot.Gateway.dll"]
