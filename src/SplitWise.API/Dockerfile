FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/SplitWise.API/SplitWise.API.csproj", "src/SplitWise.API/"]
COPY ["src/SplitWise.Application/SplitWise.Application.csproj", "src/SplitWise.Application/"]
COPY ["src/SplitWise.Domain/SplitWise.Domain.csproj", "src/SplitWise.Domain/"]
COPY ["src/SplitWise.Infrastructure/SplitWise.Infrastructure.csproj", "src/SplitWise.Infrastructure/"]
RUN dotnet restore "src/SplitWise.API/SplitWise.API.csproj"
COPY . .
WORKDIR "/src/src/SplitWise.API"
RUN dotnet build "./SplitWise.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SplitWise.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SplitWise.API.dll"]
