FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

FROM mcr.microsoft.com/dotnet/aspnet:6.0

FROM mcr.microsoft.com/dotnet/sdk



WORKDIR /app

COPY . .

EXPOSE 5003 

EXPOSE 58523

RUN apt update 
RUN apt install net-tools


CMD [ "dotnet","run" ]