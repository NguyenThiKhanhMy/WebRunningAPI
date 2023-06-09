#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebRunning.API/WebRunning.API.csproj", "WebRunning.API/"]
RUN dotnet restore "WebRunning.API/WebRunning.API.csproj"
COPY . .
WORKDIR "/src/WebRunning.API"
RUN dotnet build "WebRunning.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebRunning.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebRunning.API.dll"]