# I. Authn-Authz with Auth0
	1. Patttern:
		SPA + API pattern
	2. Steps
		2.1 Auth0 configuration
			- Register Auth0 member if not a member
				=> Get domain name
			- Create application (SPA type)
				=> Get client ID
			- Create API
				=> Get Audience
			- Set permissions
				User/Role/Group
				Authorization Extension
	
		2.2 SPA Implemenation
			- Login/logout/routing guard
				+ ng add @auth0/auth0-angular
				+ AuthService.loginWithRedirect()
				+ AuthService.logout()
				+ canActivate:AuthGuard
			- Call API
				+ AuthModule, AuthHttpInterceptor from @auth0/auth0-angular
				+ Config AuthModule (AuthModule.forRoot(...)) <= Provide registered auth0 domain/clientid/audience(api identity), http interceptor
				+ Register Auth0's AuthHttpInterceptor as HTTP_INTERCEPTORS in providers
				
		2.3 API Implementation (asp.net core 5)
			- Configure service for using Auth0's authorization (Startup/ConfigureServices)
				services.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				}).AddJwtBearer(options =>
				{
					options.Authority = "auth0 domain";
					options.Audience = "Auth0 registered api id";
				});
			
			- Configure service for using customized Authenticaiton handler (Startup/ConfigureServices)
				services.AddAuthorization(options =>
				{
					options.AddPolicy("change:movies", policy => policy.Requirements.Add(new HasScopeRequirement("change:movies", domain)));
					options.AddPolicy("update:movie", policy => policy.Requirements.Add(new HasScopeRequirement("update:movie", domain)));
				});
				services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
			
			- Register app (Startup/Configure)
				+ Ensure using of authentication/authorization 
					app.UseAuthentication();
					app.UseAuthorization();
			
			- Add Authorize attribute for Controller actions
				[Authorize("change:movies")]
				public async Task<ActionResult<MoviesVm>> Get() {...}
				
# II. Graphql Implementation
	1. SPA
		- Add libs
			ng add apollo-angular
		- Using: refer guide link
	
	2. API
		- Add libs
			+ GraphQL, GraphQL.Server.Transports.AspNetCore, GraphQL.Server.Transports.AspNetCore.SystemTextJson
			+ GraphQL.Server.Ui.Playground: support send query to server
		- Implementation
			+ Define schema (included types, query, mutations)
			+ Register schema to service
				Startup/ConfigureServices
					services.AddScoped<AppSchema>();
					services.AddGraphQL()
						.AddSystemTextJson()
						.AddGraphTypes(typeof(AppSchema), ServiceLifetime.Scoped);
				StartUp/Configure
					app.UseGraphQL<AppSchema>();


Refer links:
	Auth0:
		```
		https://auth0.com/
		https://auth0.com/docs/architecture-scenarios/spa-api
		https://github.com/auth0-samples/auth0-angular-samples
		https://github.com/auth0-samples/auth0-aspnetcore-webapi-samples
		```
	Graphql
		```
		https://graphql.org/
		https://github.com/graphql-dotnet/graphql-dotnet
		https://github.com/graphql-dotnet/examples
		https://code-maze.com/graphql-asp-net-core-tutorial/ <= Follow this turtorial
		https://apollo-angular.com/docs/
		```
# Technical discussion
1.Why using EF
	- Easier to use (support easy to understand query, DB schema creation, DB query, DB manipulation)
	- Easier to switch to other DB (SQL Server, or MySQL, Postgresql
	- Security?
2.SQL Index
	- Like index of the book
	- Speed up data query, but slow down data input
	- Index types: B-tree or hash (depend on storage engine)
	- How to index
		+ should: columns in where/join
		+ should not: frequently update columns/large number of null value columns
3.DI
4.CQRS
