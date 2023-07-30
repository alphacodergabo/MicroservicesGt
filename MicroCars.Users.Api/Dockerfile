#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MicroCars.Users.Api/MicroCars.Users.Api.csproj", "MicroCars.Users.Api/"]
COPY ["MicroCars.Infra.IoC/MicroCars.Infra.IoC.csproj", "MicroCars.Infra.IoC/"]
COPY ["MicroCars.Cars.Application/MicroCars.Cars.Application.csproj", "MicroCars.Cars.Application/"]
COPY ["MicroCars.Cars.Data/MicroCars.Cars.Data.csproj", "MicroCars.Cars.Data/"]
COPY ["MicroCars.Cars.Domain/MicroCars.Cars.Domain.csproj", "MicroCars.Cars.Domain/"]
COPY ["MicroCars.Domain.Core/MicroCars.Domain.Core.csproj", "MicroCars.Domain.Core/"]
COPY ["MicroCars.Infra.Bus/MicroCars.Infra.Bus.csproj", "MicroCars.Infra.Bus/"]
COPY ["MicroCars.User.Application/MicroCars.User.Application.csproj", "MicroCars.User.Application/"]
COPY ["MicroCar.User.Data/MicroCar.User.Data.csproj", "MicroCar.User.Data/"]
COPY ["MicroCars.Users.Domain/MicroCars.Users.Domain.csproj", "MicroCars.Users.Domain/"]
RUN dotnet restore "MicroCars.Users.Api/MicroCars.Users.Api.csproj"
COPY . .
WORKDIR "/src/MicroCars.Users.Api"
RUN dotnet build "MicroCars.Users.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroCars.Users.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroCars.Users.Api.dll"]