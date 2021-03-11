# demo-ca-app
Demo system using clean solution architecture angular 10+, .net core 5+, auth0
- Create a Web application using .Net 5/Angular 10+ using .net clean architecture - 

https://github.com/jasontaylordev/CleanArchitecture

https://www.youtube.com/watch?v=5OtUm1BLmG0

- Use Auth0 for Authn and Authz - https://auth0.com/

- Create 1 Rest CRUD API for IMDB Style Movie Database with UI

- Create 1 Graphql CRUD API for Movie Rating with UI
  + BE libs: GraphQL, GraphQL.Server.Transports.AspNetCore, GraphQL.Server.Transports.AspNetCore.SystemTextJson
  + FE libs: apollo-angular, apollo/client, graphql (ng add apollo-angula)
  
- Use Material Design by Google - https://material.io/

- Unit Test (NUnit)

## Some settings:
- Auth0
  + Authorize API at BE: WebUI\appsettings.json
  ```
    "Auth0": {
        "Domain": "registered auth0's domain",
        "Audience": "registered auth0's api identity"
    }
   ```
  + Authn & Authz at FE: WebUI\ClientApp\auth_config.json
  ```
    {
      "domain": "registered auth0's domain",
      "clientId": "clientId - get from auth0",
      "audience": "registered auth0's api identity",
      "serverUrl": "url of web server (ex: https://localhost:44312)"
    }
   ```
