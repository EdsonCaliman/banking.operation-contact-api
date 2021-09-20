#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
ENV TZ="America/Sao_Paulo"
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Banking.Operation.Contact.Api/Banking.Operation.Contact.Api.csproj", "Banking.Operation.Contact.Api/"]
COPY ["Banking.Operation.Contact.CrossCutting.Ioc/Banking.Operation.Contact.CrossCutting.Ioc.csproj", "Banking.Operation.Contact.CrossCutting.Ioc/"]
COPY ["Banking.Operation.Contact.Infra.Data/Banking.Operation.Contact.Infra.Data.csproj", "Banking.Operation.Contact.Infra.Data/"]
COPY ["Banking.Operation.Contact.Domain/Banking.Operation.Contact.Domain.csproj", "Banking.Operation.Contact.Domain/"]
RUN dotnet restore "Banking.Operation.Contact.Api/Banking.Operation.Contact.Api.csproj"
COPY . .
WORKDIR "/src/Banking.Operation.Contact.Api"
RUN dotnet build "Banking.Operation.Contact.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Banking.Operation.Contact.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Banking.Operation.Contact.Api.dll"]