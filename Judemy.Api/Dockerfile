#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Judemy.Api/Judemy.Api.csproj", "Judemy.Api/"]
COPY ["Judemy.Application/Judemy.Application.csproj", "Judemy.Application/"]
COPY ["Judemy.Domain/Judemy.Domain.csproj", "Judemy.Domain/"]
COPY ["Judemy.Persistent/Judemy.Persistent.csproj", "Judemy.Persistent/"]
RUN dotnet restore "Judemy.Api/Judemy.Api.csproj"
COPY . .
WORKDIR "/src/Judemy.Api"
RUN dotnet build "Judemy.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Judemy.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Judemy.Api.dll"]