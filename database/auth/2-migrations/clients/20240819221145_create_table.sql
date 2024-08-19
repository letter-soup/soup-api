-- up
if dingo.exists_table('Clients', 'dbo') = 0
begin
    create table dbo.Clients (
        Id int not null identity,
        Enabled bit not null,
        ClientId nvarchar(200) not null,
        ProtocolType nvarchar(200) not null,
        RequireClientSecret bit not null,
        ClientName nvarchar(200) null,
        Description nvarchar(1000) null,
        ClientUri nvarchar(2000) null,
        LogoUri nvarchar(2000) null,
        RequireConsent bit not null,
        AllowRememberConsent bit not null,
        AlwaysIncludeUserClaimsInIdToken bit not null,
        RequirePkce bit not null,
        AllowPlainTextPkce bit not null,
        RequireRequestObject bit not null,
        AllowAccessTokensViaBrowser bit not null,
        RequireDPoP bit not null,
        DPoPValidationMode int not null,
        DPoPClockSkew time not null,
        FrontChannelLogoutUri nvarchar(2000) null,
        FrontChannelLogoutSessionRequired bit not null,
        BackChannelLogoutUri nvarchar(2000) null,
        BackChannelLogoutSessionRequired bit not null,
        AllowOfflineAccess bit not null,
        IdentityTokenLifetime int not null,
        AllowedIdentityTokenSigningAlgorithms nvarchar(100) null,
        AccessTokenLifetime int not null,
        AuthorizationCodeLifetime int not null,
        ConsentLifetime int null,
        AbsoluteRefreshTokenLifetime int not null,
        SlidingRefreshTokenLifetime int not null,
        RefreshTokenUsage int not null,
        UpdateAccessTokenClaimsOnRefresh bit not null,
        RefreshTokenExpiration int not null,
        AccessTokenType int not null,
        EnableLocalLogin bit not null,
        IncludeJwtId bit not null,
        AlwaysSendClientClaims bit not null,
        ClientClaimsPrefix nvarchar(200) null,
        PairWiseSubjectSalt nvarchar(200) null,
        InitiateLoginUri nvarchar(2000) null,
        UserSsoLifetime int null,
        UserCodeType nvarchar(100) null,
        DeviceCodeLifetime int not null,
        CibaLifetime int null,
        PollingInterval int null,
        CoordinateLifetimeWithUserSession bit null,
        Created datetime2 not null,
        Updated datetime2 null,
        LastAccessed datetime2 null,
        NonEditable bit not null,
        PushedAuthorizationLifetime int null,
        RequirePushedAuthorization bit not null,
        constraint PK_Clients primary key (Id)
    )
end

-- down
if dingo.exists_table('Clients', 'dbo') = 1
begin
    drop table dbo.Clients;
end
