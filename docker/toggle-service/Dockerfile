# escape=`
FROM microsoft/dotnet:3.1-sdk-nanoserver-1809 AS builder

WORKDIR /toggle-service
COPY ToggleService.sln .
COPY src/ToggleService/ToggleService.csproj src/ToggleService/ToggleService.csproj
RUN dotnet restore src/ToggleService/ToggleService.csproj

COPY src src
RUN dotnet publish .\src\ToggleService\ToggleService.csproj

# app image
FROM microsoft/dotnet:3.1-aspnetcore-runtime-nanoserver-1809

WORKDIR /toggle-service
COPY --from=builder /toggle-service/src/ToggleService/bin/Debug/netcoreapp3.1/publish/ .
CMD ["dotnet", "ToggleService.dll"]