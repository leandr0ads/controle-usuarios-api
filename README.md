# ControleUsuariosApi

CRUD simples de usuários com ASP.NET Core 8, Controllers, EF Core 8 e SQLite.

## Executar

```bash
dotnet restore
dotnet run
```

Swagger: `http://localhost:5071/swagger`

## Endpoints

- `GET /api/usuarios`
- `GET /api/usuarios/{id}`
- `POST /api/usuarios`
- `PUT /api/usuarios/{id}`
- `DELETE /api/usuarios/{id}`

## Exemplo de POST

```json
{
  "nome": "Leandro Santos",
  "email": "leandro@email.com"
}
```

## Exemplo de PUT

```json
{
  "nome": "Leandro Santos",
  "email": "leandro.novo@email.com",
  "ativo": true
}
```
