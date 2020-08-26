# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/nightly/sdk:latest AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY chart/*.csproj .
RUN dotnet restore

# copy everything else and build app
COPY chart/. .
WORKDIR /source
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/nightly/aspnet:latest
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "planar.server.dll"]