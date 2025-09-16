FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Cronache-di-DnD/Cronache-di-DnD.csproj", "Cronache-di-DnD/"]
RUN dotnet restore "Cronache-di-DnD/Cronache-di-DnD.csproj"
COPY . .
WORKDIR "/src/Cronache-di-DnD"
RUN dotnet build "Cronache-di-DnD.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Cronache-di-DnD.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cronache-di-DnD.dll"]
