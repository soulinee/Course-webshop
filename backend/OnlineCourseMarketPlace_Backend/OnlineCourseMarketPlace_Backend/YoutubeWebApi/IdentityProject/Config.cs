using Duende.IdentityServer.Models;

namespace IdentityProject;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };
// een API scope is een toestemming die zegt wat een client mag doen met een API
    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("scope1"),
            new ApiScope("scope2"),
            // dit nog aanpassen 
            //bv. new ApiScope("shipit.pricequotes.api.write"), 
            new ApiScope("coursegateway","CourseGateway API")
        };
    
    public static IEnumerable<ApiResource> ApiResources =>
[
    new ApiResource("coursegateway-api", "CourseGateway API")
    {
        Scopes = { "coursegateway" }
    }
];



    public static IEnumerable<Client> Clients =>
     new Client[]
    {
        // React SPA frontend (Code flow + PKCE)
        new Client
        {
            // de unieke naam van mijn React App wordt gebruikt bij login 
            ClientId = "coursemarket-frontend",
            ClientName = "CourseMarket React Frontend",

            AllowedGrantTypes = GrantTypes.Code,
            RequirePkce = true,
            RequireClientSecret = false, // SPA = geen secret react bewaart geen geheim
            
            // deze code is juist en volgt de cursus

            //Login callback url
            RedirectUris =
            {
                "http://localhost:5173/callback"
            },
            //Logout callback url
            PostLogoutRedirectUris =
            {
                "http://localhost:5173/"
            },
            //CORS. Opgelet: geen trailing / (origin vs url)

            AllowedCorsOrigins =
            {
                "http://localhost:5173"
            },

            AllowedScopes =
            {
                "openid",
                "profile",
                "coursegateway" //  toegang tot CourseGateway API
            },

            AllowAccessTokensViaBrowser = true
        }
         
        };
}
