#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://*:80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["voucherManagementService.csproj", ""]
RUN dotnet restore "voucherManagementService.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "voucherManagementService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "voucherManagementService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "voucherManagementService.dll"]