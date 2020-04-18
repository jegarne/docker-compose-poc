# escape=`
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS builder

WORKDIR /user-service
COPY src/UserService/UserService.csproj src/UserService/UserService.csproj

COPY src src
RUN dotnet publish .\src\UserService\UserService.csproj

# app image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

ENV ASPNETCORE_URLS=https://+:443

WORKDIR /user-service
COPY --from=builder /user-service/src/UserService/bin/Debug/netcoreapp3.1/publish/ .
CMD ["dotnet", "UserService.dll"]