# Installation
1. Clone project
2. Update ConnString in appsetting

# Data Migration
In package manager console:
Update-Database -Context IdentityDBContext
Update-Database -Context DBContext

# LemonTech Test

1. Launch API and access swagger baseUrl (http://localhost:60386/swagger/index.html).
2. Sign up for new account  (route: /sign-up).
3. Sign in using newly create account (route: /sign-in) then copy token to access category and product end points.
4. When using end points for category and product add copied token in the Authorization Bearer Token (Bearer {token});
