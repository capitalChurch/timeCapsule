FROM mcr.microsoft.com/dotnet/core/sdk:2.1-alpine as build-stage
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o build -r linux-musl-x64

FROM alpine:3.12
RUN apk update && apk add --no-cache libstdc++ libintl icu openssl1.0-compat
WORKDIR /app
COPY --from=build-stage /app/build .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["/app/TimeCapsule"]
