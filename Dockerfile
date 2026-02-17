FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["XCloudApp/XCloudApp.csproj", "XCloudApp/"]
COPY ["XCloudApp.DAL/XCloudApp.DAL.csproj", "XCloudApp.DAL/"]
COPY ["XCloudApp.Domain/XCloudApp.Domain.csproj", "XCloudApp.Domain/"]
RUN dotnet restore "./XCloudApp/XCloudApp.csproj"
COPY . .
WORKDIR "/src/XCloudApp"
RUN dotnet build "./XCloudApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./XCloudApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "XCloudApp.dll"]
