
# 💬 Chat System API

Uma API RESTful desenvolvida em ASP.NET Core para gerenciamento de **usuários**, **mensagens diretas**, **grupos de chat** e **sessões de conversa**, com persistência via PostgreSQL e containerizada com Docker.

---

## 🚀 Funcionalidades

- 👤 Cadastro e autenticação de usuários
- 📩 Envio de mensagens diretas entre usuários
- 👥 Criação de grupos de chat com múltiplos participantes
- 🗨️ Envio de mensagens em grupo
- 🧑‍🤝‍🧑 Entrada e saída de usuários em grupos
- 📜 Histórico de mensagens por grupo ou usuário

---

## 🛠️ Tecnologias Utilizadas

- ⚙️ ASP.NET Core 8
- 🐘 PostgreSQL
- 🐳 Docker + Docker Compose
- 🧱 Entity Framework Core
- 🔁 MediatR (CQRS)
- 📄 Swagger para documentação automática

---

## ⚙️ Como rodar o projeto com Docker

> Requisitos: [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) e [Docker Desktop](https://www.docker.com/products/docker-desktop) instalados.

### ▶️ Para subir a aplicação:

```bash
docker compose up -d --build
```

A API estará disponível em:  
📍 `http://localhost:5126/swagger`

---

## 📮 Endpoints principais

### 👤 Usuários
| Método | Rota            | Descrição                      |
|--------|------------------|-------------------------------|
| POST   | `/users`         | Criar novo usuário            |
| POST   | `/users/login`   | Autenticar usuário            |

### 💬 Mensagens Diretas
| Método | Rota                            | Descrição                           |
|--------|----------------------------------|--------------------------------------|
| POST   | `/messages/direct/{userId}`     | Enviar mensagem direta              |
| GET    | `/messages/direct/{userId}`     | Listar mensagens trocadas com usuário |

### 🧑‍🤝‍🧑 Grupos de Chat
| Método | Rota                            | Descrição                             |
|--------|----------------------------------|----------------------------------------|
| POST   | `/rooms`                         | Criar grupo de chat                   |
| POST   | `/rooms/{id}/enter`              | Entrar em grupo                       |
| POST   | `/rooms/{id}/leave`              | Sair de grupo                         |
| POST   | `/rooms/{id}/messages`           | Enviar mensagem no grupo              |
| GET    | `/rooms/{id}/messages`           | Buscar mensagens do grupo             |
| GET    | `/rooms/{id}/participants`       | Listar participantes de um grupo      |
| GET    | `/rooms`                         | Listar grupos disponíveis             |

---

## 📬 Contato

Feito com ❤️ para fins acadêmicos.  
Dúvidas ou sugestões são bem-vindas!
