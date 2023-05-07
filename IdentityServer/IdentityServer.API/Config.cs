﻿using IdentityServer4.Models;
using IdentityServer4;

namespace IdentityServer.API;

public class Config
{
    public static IEnumerable<ApiResource> ApiResources => 
        new ApiResource[]
        {
            new ApiResource("resource_product"){Scopes={"product_fullpermission"}},
            
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.Email(),
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource(){ Name="roles", DisplayName="Roles", Description="Users rolls", UserClaims=new []{ "role"} }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("product_fullpermission","Permisson for Product API"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientName="React",
                ClientId="ReactClient",
                ClientSecrets= {new Secret("secret".Sha256())},
                AllowedGrantTypes= GrantTypes.ClientCredentials,
                AllowedScopes={ "product_fullpermission", "photo_stock_fullpermission",
                    "gateway_fullpermission",IdentityServerConstants.LocalApi.ScopeName }
            },
            new Client
            {
                ClientName="React",
                ClientId="ReactClientForUser",
                AllowOfflineAccess=true,
                ClientSecrets= {new Secret("secret".Sha256())},
                AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                AllowedScopes={"order_fullpermission","basket_fullpermission",
                    "order_fullpermission","gateway_fullpermission",
                    "payment_fullpermission","product_fullpermission",
                    "discount_fullpermission",
                    IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile, IdentityServerConstants.StandardScopes.OfflineAccess,
                    IdentityServerConstants.LocalApi.ScopeName,"roles" },
                AccessTokenLifetime=1*60*60,
                RefreshTokenExpiration=TokenExpiration.Absolute,
                AbsoluteRefreshTokenLifetime= (int) (DateTime.Now.AddDays(60)- DateTime.Now).TotalSeconds,
                RefreshTokenUsage= TokenUsage.ReUse
            },
            new Client
            {
                ClientName="Token Exchange Client",
                ClientId="TokenExhangeClient",
                ClientSecrets= {new Secret("secret".Sha256())},
                AllowedGrantTypes= new []{ "urn:ietf:params:oauth:grant-type:token-exchange" },
                AllowedScopes={ "discount_fullpermission", "payment_fullpermission", IdentityServerConstants.StandardScopes.OpenId }
            },
        };
}
