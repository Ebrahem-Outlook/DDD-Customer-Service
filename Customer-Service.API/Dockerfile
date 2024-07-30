# Use the .NET ASP.NET Core runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Customer-Service.API/Customer-Service.API.csproj", "Customer-Service.API/"]
COPY ["Customer-Service.Infrastructure/Customer-Service.Infrastructure.csproj", "Customer-Service.Infrastructure/"]
COPY ["Customer-Service.Application/Customer-Service.Application.csproj", "Customer-Service.Application/"]
COPY ["Customer-Service.Domain/Customer-Service.Domain.csproj", "Customer-Service.Domain/"]
RUN dotnet restore "./Customer-Service.API/Customer-Service.API.csproj"
COPY . .
WORKDIR "/src/Customer-Service.API"
RUN dotnet build "./Customer-Service.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Customer-Service.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Create the final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customer-Service.API.dll"]
