#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Diplom.Gamification.Web/Diplom.Gamification.Web.csproj", "Diplom.Gamification.Web/"]
COPY ["Diplom.Gamification.Application/Diplom.Gamification.Application.csproj", "Diplom.Gamification.Application/"]
COPY ["Diplom.Gamification.Domain/Diplom.Gamification.Domain.csproj", "Diplom.Gamification.Domain/"]
COPY ["Diplom.Gamification.Shared/Diplom.Gamification.Shared.csproj", "Diplom.Gamification.Shared/"]
COPY ["Diplom.Gamification.Infrastructure/Diplom.Gamification.Infrastructure.csproj", "Diplom.Gamification.Infrastructure/"]
COPY ["Diplom.Gamification.Persistence/Diplom.Gamification.Persistence.csproj", "Diplom.Gamification.Persistence/"]
RUN dotnet restore "./Diplom.Gamification.Web/./Diplom.Gamification.Web.csproj"
COPY . .
WORKDIR "/src/Diplom.Gamification.Web"
RUN dotnet build "./Diplom.Gamification.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Diplom.Gamification.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Diplom.Gamification.Web.dll"]