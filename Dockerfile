FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# Dependencies
COPY ./*.csproj ./
RUN dotnet restore

# Build
COPY . ./
RUN dotnet publish -c release -o /app

# Run
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY ./*.csproj ./
COPY --from=build /app ./
CMD ["dotnet", "CS201_WebApi.dll"]
