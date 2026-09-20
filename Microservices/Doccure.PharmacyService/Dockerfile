FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["Doccure.PharmacyService.csproj", "./"]
RUN dotnet restore "Doccure.PharmacyService.csproj"

COPY . .
RUN dotnet publish "Doccure.PharmacyService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Doccure.PharmacyService.dll"]