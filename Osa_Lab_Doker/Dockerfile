#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY ["Osa_Lab_Doker/Osa_Lab_Doker.csproj", "Osa_Lab_Doker/"]
RUN dotnet restore "Osa_Lab_Doker/Osa_Lab_Doker.csproj"
COPY . .
WORKDIR "/src/Osa_Lab_Doker"
RUN dotnet build "Osa_Lab_Doker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Osa_Lab_Doker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
LABEL maintainer="Andrey Ostroverhov"
RUN addgroup -S AndreyGroup && adduser -S AndreyUser -G AndreyGroup
USER AndreyUser
ENV ENVIRONMENT="stage"
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Osa_Lab_Doker.dll"]