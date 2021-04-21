FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Restory and copy proj.
COPY /src/*.csproj ./
RUN dotnet restore
COPY . ./

# Copy everythhing else and buildv.
RUN dotnet publish -c Release -o out

# Build runtime image.
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

ENV ASPNETCORE_ENVIRONMENT="Production"
ENV ENVIRONMENT="Production"

WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 3000
ENTRYPOINT ["dotnet", "kwetter-authentication.dll"]
