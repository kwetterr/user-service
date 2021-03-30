FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Restory and copy proj.
COPY *.csproj ./
RUN dotnet restore
COPY . ./

# Copy everythhing else and build.
RUN dotnet publish -c Release -o out

# Build runtime image.
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 5000
ENTRYPOINT ["dotnet", "kwetter-authentication.dll"]

# RUN chmod +x ./entrypoint.sh

# CMD bash ./entrypoint.sh