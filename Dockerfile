FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Restory and copy proj.
COPY /src/*.csproj ./
RUN dotnet restore
COPY . ./

# Copy everythhing else and build.
RUN dotnet publish -c Release -o out

# Build runtime image.
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
ENV ASPNETCORE_ENVIRONMENT="Development"
ENV ENVIRONMENT="Development"

WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 5000
ENTRYPOINT ["dotnet", "kwetter-authentication.dll"]
