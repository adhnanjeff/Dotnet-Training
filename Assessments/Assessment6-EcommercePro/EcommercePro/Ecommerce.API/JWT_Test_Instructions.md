# JWT Authentication Test Instructions

## Setup Verification

1. **Build the project** to ensure all packages are restored:
   ```bash
   dotnet build
   ```

2. **Run the API**:
   ```bash
   dotnet run --project Ecommerce.API
   ```

## Testing JWT Authentication

### 1. Register a User
```http
POST https://localhost:7001/api/auth/register
Content-Type: application/json

{
  "username": "testuser",
  "password": "password123",
  "role": "Buyer"
}
```

### 2. Login to Get JWT Token
```http
POST https://localhost:7001/api/auth/login
Content-Type: application/json

{
  "username": "testuser",
  "password": "password123"
}
```

**Expected Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expiresAt": "2024-01-01T12:00:00Z",
  "username": "testuser",
  "role": "Buyer",
  "message": "Login successful"
}
```

### 3. Test Protected Endpoints

#### Test with Valid Token:
```http
GET https://localhost:7001/api/user
Authorization: Bearer YOUR_JWT_TOKEN_HERE
```

#### Test without Token (should return 401):
```http
GET https://localhost:7001/api/user
```

### 4. Test Role-Based Access

#### Admin Only Endpoint:
```http
GET https://localhost:7001/api/user
Authorization: Bearer ADMIN_JWT_TOKEN
```

#### Buyer Only Endpoint:
```http
POST https://localhost:7001/api/order
Authorization: Bearer BUYER_JWT_TOKEN
Content-Type: application/json

{
  "userId": 1,
  "orderDate": "2024-01-01T12:00:00Z"
}
```

## Swagger UI Testing

1. Navigate to: `https://localhost:7001/swagger`
2. Click "Authorize" button
3. Enter your JWT token (without "Bearer " prefix)
4. Test protected endpoints

## Common Issues & Solutions

1. **401 Unauthorized**: Check if token is valid and not expired
2. **403 Forbidden**: Check if user has required role
3. **500 Internal Server Error**: Check JWT configuration in appsettings.json

## JWT Configuration

The JWT settings are configured in `appsettings.json`:
```json
{
  "Jwt": {
    "Key": "ThisIsAReallyStrongSecretKey12345!",
    "Issuer": "EcommerceAPI",
    "Audience": "EcommerceClient",
    "ExpireMinutes": 5
  }
}
```

**Note**: In production, use a much stronger secret key and store it securely!
