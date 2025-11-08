FROM mcr.microsoft.com/dotnet/core/sdk:2.1 as build-stage
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o build

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1
WORKDIR /app
COPY --from=build-stage /app/build .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "TimeCapsule.dll"]
