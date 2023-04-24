# .Net core RabbitMQ Example

## Description

This is a sample project that implements a RESTful API for managing products. The API allows the creation, retrieval, update, and deletion of products. It also integrates RabbitMQ for publishing product creation events.

## Installation

1. Clone the repository:

```bash
git clone 
```

2. Install the required packages by running the following command:
```bash
dotnet restore
```

3. Start the RabbitMQ server using Docker by running the following command:
```bash
docker-compose up -d
```

4. Run the application by running the following command:
```bash
dotnet run
```

## Requirements

- [.NET Core 6.0](https://dotnet.microsoft.com/download/dotnet-core/6.0)
- [Docker](https://www.docker.com/products/docker-desktop)

## Usage

The API supports the following endpoints:

- **POST** `/api/products` - creates a new product
- **PUT** `/api/products/{id}` - updates an existing product
- **0DELETE** `/api/products/{id}` - deletes a product
- **GET** `/api/products/{id}` - retrieves a product by its ID
- **GET** `/api/products` - retrieves all products

## Example

To create a new product, send a **POST** request to `/api/products` with the following JSON data in the request body:

```json
{
    "name": "Product Name",
    "description": "Product Description",
    "price": 9.99
}
```

The API will respond with the following JSON data:

```json
{
    "id": "4e833bf3-9477-4ee8-8b45-d2f28b632d07",
    "name": "Product Name",
    "description": "Product Description",
    "price": 9.99
}
```
The API will also publish a message to RabbitMQ with the following JSON data:

```json
{
    "id": "4e833bf3-9477-4ee8-8b45-d2f28b632d07",
    "name": "Product Name",
    "description": "Product Description",
    "price": 9.99
}
```
You can use the RabbitMQ management console to view the published messages. Open a web browser and go to `http://localhost:15672/`. Log in using the default credentials (guest/guest).
