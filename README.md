# Project Store Manager CS

## O que foi desenvolvido
- Foi desenvolvido um back-end em C# e ASP.NET Core de um software de controle de estoque.

## Habilidades trabalhadas
- Entender do funcionamento do ASP.NET e como ele se integra ao C#.
- Entender do funcionamento do banco de dados SQL Server.
- Criar operações de manipulação de banco de dados em uma API.

## Como instalar
1. Clone o repositório

  - Use o comando:
    - `git clone git@github.com:jbeniciopp/Project-Store-Manager-Cs.git`.
  - Entre na pasta do repositório que você acabou de clonar:
    - `cd Project-Store-Manager-Cs`

2. Instale as dependências

  - Execute o comando: `dotnet restore`.

## Como rodar o projeto
- Use o comando para iniciar o Banco de Dados:
  - `docker compose up -d --build`
- Use o comando para o dotnet fazer as migrations:
  - `dotnet ef migrations add InitialCreate`
- Use o comando para criar as tabelas do Banco de Dados:
  - `dotnet ef database update`
- Use o comando para iniciar a API:
  - `dotnet run`

## Endpoints

### GET /
- Retorno:
  - status: `200`
```json
{
  "message": "online"
}
```

### GET /products
- Retorno:
  - status: `200`
```json
[
  {
    "productId": 1,
    "name": "PC Gamer"
  },
  /*...*/
]
```

### GET /products/:productId
- O productId deve ser o id do Produto desejado.

- Retorno:
  - status: `200`
```json
{
  "productId": 1,
  "name": "PC Gamer"
}
```

### POST /products
- O corpo da requisição deve seguir o padrão abaixo:
```json
{
  "name": "PC Gamer"
}
```

- Retorno:
  - status: `201`
```json
{
  "productId": 1,
  "name": "PC Gamer"
}
```

### PUT /products
- O corpo da requisição deve seguir o padrão abaixo:
```json
{
  "productId": 1,
  "name": "PC Home Office"
}
```

- Retorno:
  - status: `200`
```json
{
  "productId": 1,
  "name": "PC Home Office"
}
```

### DELETE /products/:productId
- O productId deve ser o id do Produto desejado.

- Caso o productId seja invalido o Retorno será o status: `400`

- Retorno:
  - status: `204`

### GET /sales
- Retorno:
  - status: `200`
```json
[
  {
    "saleId": 1,
    "itemsSold": [
      {
        "productId": 1,
        "name": "PC Gamer",
        "quantity": 3
      },
      {
        "productId": 2,
        "name": "PC Home Office",
        "quantity": 5
      }
    ]
  },
  /*...*/
]
```

### GET /sales/:saleId
- O saleId deve ser o id da Venda desejada.

- Retorno:
  - status: `200`
```json
{
  "saleId": 1,
  "itemsSold": [
    {
      "productId": 1,
      "name": "PC Gamer",
      "quantity": 3
    },
    {
      "productId": 2,
      "name": "PC Home Office",
      "quantity": 5
    }
  ]
}
```

### POST /sales
- O corpo da requisição deve seguir o padrão abaixo:
```json
[
  {
    "productId": 1,
    "name": "PC Gamer", // Opicional
    "quantity": 3
  },
  {
    "productId": 2,
    "name": "PC Home Office", // Opicional
    "quantity": 5
  }
]
```

- Retorno:
  - status: `201`
```json
{
  "saleId": 1,
  "itemsSold": [
    {
      "productId": 1,
      "name": "PC Gamer",
      "quantity": 3
    },
    {
      "productId": 2,
      "name": "PC Home Office",
      "quantity": 5
    }
  ]
}
```

### PUT /sales
- O corpo da requisição deve seguir o padrão abaixo:
```json
{
  "saleId": 1,
  "itemsSold": [
    {
      "productId": 3,
      "name": "Notebook Gamer", // Opicional
      "quantity": 10
    }
  ]
}
```

- Retorno:
  - status: `200`
```json
{
  "saleId": 1,
  "itemsSold": [
    {
      "productId": 3,
      "name": "Notebook Gamer",
      "quantity": 10
    }
  ]
}
```

### DELETE /sales/:saleId
- O saleId deve ser o id da Venda desejada.

- Caso o productId seja invalido o Retorno será o status: `400`

- Retorno:
  - status: `204`