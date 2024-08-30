# jwt-auth-backend

This is a JWT Authentication Backend project designed to manage user authentication using JSON Web Tokens (JWT). The project is built using ASP.NET Core, and includes a Docker Compose setup for easy development and deployment.

## Table of Contents

- [Features](#features)
- [API Endpoints](#api-endpoints)
- [Prerequisites](#prerequisites)
- [Installation](#installation)

## Features

- User registration and login
- JWT-based authentication and authorization
- Protected routes with role-based access control
- Password hashing and validation
- Refresh token support
- Error handling and validation

## API Endpoints

### Authentication

- **POST /api/authentication/register** - Register a new user
- **POST /api/authentication/login** - Login and get a JWT token
- **POST /api/authentication/refresh** - Refresh JWT token

### Protected Routes

Use the `Authorization: Bearer <token>` header to access protected routes.

## Prerequisites

Before you begin, ensure you have the following installed:

- [Docker](https://www.docker.com/) and [Docker Compose](https://docs.docker.com/compose/) v3.x or higher
- [Git](https://git-scm.com/)

## Installation

1. Clone the repository:
   ```
   git clone https://github.com/yourusername/jwt-auth-backend.git
   ```

2. Run the following command to build and start the containers:

    ```bash
    cd jwt-auth-backend
    docker-compose up --build
    ```

    This will start the following services:
    - **authentication.api**: The ASP.NET Core application.
    - **authentication.database**: A PostgreSQL database.
    
3. Access the application:
- The API will be available at http://localhost:8080
- The database will be running on localhost:5432

4. To stop the containers, run:

    ```bash
    docker-compose down
    ```
