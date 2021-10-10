#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MOECSREP.POC.Certificates/MOECSREP.POC.Certificates.csproj", "MOECSREP.POC.Certificates/"]
RUN dotnet restore "MOECSREP.POC.Certificates/MOECSREP.POC.Certificates.csproj"
COPY . .
WORKDIR "/src/MOECSREP.POC.Certificates"
RUN dotnet build "MOECSREP.POC.Certificates.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MOECSREP.POC.Certificates.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MOECSREP.POC.Certificates.dll"]