#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/01 - Presentation/Password.Api/Password.Api.csproj", "src/01 - Presentation/Password.Api/"]
RUN dotnet restore "src/01 - Presentation/Password.Api/Password.Api.csproj"
COPY . .
WORKDIR "/src/src/01 - Presentation/Password.Api"
RUN dotnet build "Password.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Password.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Password.Api.dll"]