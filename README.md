# JWT-in-.net6

#Features
JWT authentication and authorization.

#Requirements
.NET 6 SDK
Visual Studio 2022 (optional)
Installation
Provide step-by-step instructions on how to set up the project locally. Include any environment variables, configurations, or database setup that might be needed.

#Configuration
used token expiration time, secret key, issuer, and audience.

#Usage:
The token can be obtained using the 'GET' method for demonstration purposes. However, for actual implementation, it is recommended to utilize your database credentials to verify user details sent by the frontend. Once authenticated, API calls to other services will require the inclusion of a 'Bearer Token' in the request headers.


#API Endpoints
/api/AccessToken  -Open for Getting token
/api/WeatherForecast/GetWeatherForecast   -Require Token

#Authentication
Send request to get token /api/AccessToken  -Open for Getting token
For Getting eather detail pass token  /api/WeatherForecast/GetWeatherForecast   -Require Token

#License
Free to use 

#Contributing
Dharmveer

#Authors
Dharmveer
