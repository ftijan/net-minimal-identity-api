# Net 8+ Minimal API - Identity API Implementation Example

Based on the article found [here](https://andrewlock.net/exploring-the-dotnet-8-preview-introducing-the-identity-api-endpoints/)

This example uses SQLite database as the backing store for identity data.

# Running the app:
## To update the `dotnet EF` global tool:
```
dotnet tool update --global dotnet-ef --prerelease
```

## To run the migrations:
```shell
dotnet ef migrations add InitialSchema
dotnet ef database update
```

## Running the app:
- `cd` to the project folder and run `dotnet run`

## Example API usage:

To create a user:
```
POST https://localhost:7291/account/register
{
  "email": "<some_email_here>",
  "password": "<some_password_here>"
}
-->
Status: 200 OK
```

To login the same user:
```
POST https://localhost:7291/account/login
{
  "email": "<some_email_here>",
  "password": "<some_password_here>"
}
-->
Status: 200 OK
Content:
{
  "tokenType": "Bearer",
  "accessToken": "<access_token_value_here>",
  "expiresIn": <expiry_value_here>,
  "refreshToken": "<refresh_token_value_here>"
}
```

To access a protected endpoint:
```
GET https://localhost:7291/hw
Authorization: Bearer <access_token_value_here>
-->
Status: 200 OK
Content:
hello world
```

To refresh the access token:
```
POST https://localhost:7291/account/refresh
{
  "refreshToken": "<refresh_token_value_here>"
}
-->
Status: 200 OK
Content:
{
  "tokenType": "Bearer",
  "accessToken": "<access_token_value_here>",
  "expiresIn": <expiry_value_here>,
  "refreshToken": "<refresh_token_value_here>"
}
```
