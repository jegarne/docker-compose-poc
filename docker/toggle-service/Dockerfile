# escape=`
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS builder

WORKDIR /toggle-service
COPY src/ToggleService/ToggleService.csproj src/ToggleService/ToggleService.csproj

COPY src src
RUN dotnet publish .\src\ToggleService\ToggleService.csproj

# app image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /toggle-service
COPY --from=builder /toggle-service/src/ToggleService/bin/Debug/netcoreapp3.1/publish/ .
CMD ["dotnet", "ToggleService.dll"]