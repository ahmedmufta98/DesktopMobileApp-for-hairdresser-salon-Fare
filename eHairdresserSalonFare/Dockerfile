FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["eHairdresserSalonFare.Api/eHairdresserSalonFare.Api.csproj", "eHairdresserSalonFare.Api/"]
COPY ["eHairdresserSalonFare.Model/eHairdresserSalonFare.Model.csproj", "eHairdresserSalonFare.Model/"]
RUN dotnet restore "eHairdresserSalonFare.Api/eHairdresserSalonFare.Api.csproj"
COPY . .
WORKDIR "/src/eHairdresserSalonFare.Api"
RUN dotnet build "eHairdresserSalonFare.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "eHairdresserSalonFare.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ADD /UsedImages img/

ENTRYPOINT ["dotnet", "eHairdresserSalonFare.Api.dll"]