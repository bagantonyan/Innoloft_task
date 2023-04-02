#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EventManager.API/EventManager.API.csproj", "EventManager.API/"]
COPY ["EventManager.BLL/EventManager.BLL.csproj", "EventManager.BLL/"]
COPY ["EventManager.DAL/EventManager.DAL.csproj", "EventManager.DAL/"]
COPY ["EventManager.Shared/EventManager.Shared.csproj", "EventManager.Shared/"]
RUN dotnet restore "EventManager.API/EventManager.API.csproj"
COPY . .
WORKDIR "/src/EventManager.API"
RUN dotnet build "EventManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventManager.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventManager.API.dll"]