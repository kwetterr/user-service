[![CodeQL](https://github.com/kwetterr/user-service/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/kwetterr/user-service/actions/workflows/codeql-analysis.yml)
![bagde](https://github.com/kwetterr/user-service/actions/workflows/build.yml/badge.svg)
![bagde](https://github.com/kwetterr/user-service/actions/workflows/docker-publish.yml/badge.svg)

# :sparkles: user-service :sparkles:
REST-API for managing Kwetter users.

<b>Techstack:</b>
- .NET CORE 3.1
- MSSQL-database

## Getting Started

```zsh
docker-compose up --build
```

## Debugging
```zsh
dotnet run --launch-profile kwetter_authentication
```

### Analyze with a local SonarQube server
The .NET CORE Docker build contains a SonarScanner (see `./Dockerfile.sonar`). This is why SonarQube needs to be started.

Checkout [this SonarQube snippet](https://gist.github.com/ShadyDL/814b6a6514fd3a89dcbe2b227afd5b4c) I made with a full explanation.

```zsh
#zsh
docker run -d --name sonarqube --memory=5g -e SONAR_ES_BOOTSTRAP_CHECKS_DISABLE=true -p 9000:9000 sonarqube:latest
```

```zsh
#zsh
 docker build -f Dockerfile.sonar kwetter-auth \
  --build-arg SONAR_PROJECT_KEY="auth" \
  --build-arg SONAR_HOST_URL="http://localhost:9000" \
  --build-arg SONAR_TOKEN="${TOKEN}"  --network=host .
```

## Public Interface
| Endpoint          | Method   | Endpoint             | Permission       |
|-------------------| ---------| -------------------- | ------------------ |
| `Authorize`       | `POST`   | `/authorize`         | `User`             |
| `Get All`         | `GET`    | `/users`             | `User`             |
| `Create`          | `POST`   | `/users/create`      | `None`             |
| `Get`             | `GET`    | `/users/{id}`        | `User`             |
| `Update`          | `PUT`    | `/users/{id}`        | `User`             |
| `Delete`          | `DELETE` | `/users/delete/{id}` | `Moderator, Admin` |
| `Update Role`     | `PUT`    | `/roles/update/{id}` | `Admin`            |


### Issues
If the directory `/Migrations` doesn't exist or doesn't container `.cs`, `.Designer.cs`, and a `Snapshot.cs` run the following to create these files. 

```zsh
#zsh
dotnet ef migrations add Initial --project src/kwetter-authentication.csproj
```

### Sources
- [.NET Core Docker](https://docs.docker.com/engine/examples/dotnetcore/)
- [Docker Compose MSSQL - Server](https://docs.docker.com/compose/aspnet-mssql-compose/)
- [Entity Framework](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-5.0)
- [JWT](https://jasonwatmore.com/post/2019/10/11/aspnet-core-3-jwt-authentication-tutorial-with-example-api#app-settings-development-json)
- [SonarScanner](https://pumpingco.de/blog/how-to-run-a-sonarcloud-scan-during-docker-builds-for-dotnet-core/)
- [Entity Enums](https://medium.com/agilix/entity-framework-core-enums-ee0f8f4063f2)
- [Case against Repository Pattern](https://www.thereformedprogrammer.net/is-the-repository-pattern-useful-with-entity-framework-core/)