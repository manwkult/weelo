FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/out .
CMD dotnet Weelo.API.dll