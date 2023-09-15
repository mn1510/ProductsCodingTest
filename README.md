### Products Coding TEST API 
Overview
This is a coding test project for developing a Products API in .NET 6. The API provides two secured endpoints: /api/products and /api/products/{colour}. You can extend the list of product names and colors in DataModels/ProductEnums.cs.

The program generates a singleton Products Repository with 5 randomly selected products for demonstration purposes.

## Generating JWT Token
To access the secured endpoints, you'll need a JWT (JSON Web Token). Follow these steps to generate and use a JWT token for testing:

Visit jwt.io

Go to jwt.io in your web browser.

## Generate the Token

Using jwt.io, generate a JWT token. Replace the 256-bit secret with the test value: secret1234567890000000.

Please note that this secret is only for testing purposes. In a real-world scenario, users would log in securely to obtain a JWT token.

## Authorize Feature in Swagger

Access the Swagger page of the API (usually available at http://localhost:<port>/swagger when running the application locally).

In the Swagger UI, find the "Authorize" button and enter the JWT token you generated in the previous step. Once authorized, you can use the secured endpoints for testing.

Ensure you handle tokens securely in a production environment and follow proper authentication procedures.

That's it! You can now use the generated JWT token to access the secured API endpoints for testing.
