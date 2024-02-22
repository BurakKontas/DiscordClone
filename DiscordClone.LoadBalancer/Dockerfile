#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["TestAPI.Application/TestAPI.Application.csproj", "TestAPI.Application/"]
COPY ["TestAPI.Infrastructure/TestAPI.Infrastructure.csproj", "TestAPI.Infrastructure/"]
# COPY ["TestAPI.Domain/TestAPI.Domain.csproj", "TestAPI.Domain/"]

RUN dotnet restore "TestAPI.Application/TestAPI.Application.csproj"
RUN dotnet restore "TestAPI.Infrastructure/TestAPI.Infrastructure.csproj"
# RUN dotnet restore "TestAPI.Domain/TestAPI.Domain.csproj"

COPY . .
WORKDIR "/src/TestAPI.Application"
RUN dotnet build "TestAPI.Application.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "TestAPI.Application.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestAPI.Application.dll"]
