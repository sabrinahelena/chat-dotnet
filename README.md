
# 💬 Chat System API

Uma API RESTful desenvolvida em ASP.NET Core para gerenciamento de **usuários**, **mensagens diretas**, **grupos de chat** e **sessões de conversa**, com persistência via PostgreSQL e containerizada com Docker.

---

## 🚀 Funcionalidades

- 👤 Cadastro e verificação de login de usuários  
- 👥 Criação, listagem, entrada, saída e remoção de usuários em salas de chat  
- 💬 Envio de mensagens diretas entre usuários  
- 🗨️ Envio e recuperação de mensagens em salas de chat  
- 📜 Histórico de mensagens por sala  


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
| Método | Rota             | Descrição                       |
|--------|------------------|---------------------------------|
| POST   | `/users`         | Criar novo usuário              |
| POST   | `/users/login`   | Autenticar usuário              |
| GET    | `/users/{userId}`| Obter informações de um usuário |        |

### 💬 Mensagens Diretas
| Método | Rota                            | Descrição                              |
|--------|---------------------------------|----------------------------------------|
| POST   | `/messages/direct/{receiverId}` | Enviar mensagem direta a outro usuário |

### 💬 Mensagens em Grupo
| Método | Rota                            | Descrição                                       |
|--------|---------------------------------|-------------------------------------------------|
| POST   | `/rooms/{roomId}/messages`      | Enviar mensagem em uma sala de chat             |
| GET    | `/rooms/{roomId}/messages`      | Recuperar histórico de mensagens de uma sala    |

### 🧑‍🤝‍🧑 Salas de Chat
| Método | Rota                            | Descrição                              |
|--------|----------------------------------|---------------------------------------|
| POST   | `/rooms`                         | Criar uma nova sala de chat           |
| DELETE | `/rooms/{roomId}`                | Remover uma sala de chat              |
| POST   | `/rooms/{roomId}/enter`          | Entrar em uma sala                    |
| POST   | `/rooms/{roomId}/leave`          | Sair de uma sala                      |
| GET    | `/rooms/{id}/participants`       | Listar participantes de um grupo      |
| GET    | `/rooms`                         | Listar todas as salas ativas          |

---

## 📬 Contato

Feito com ❤️ para fins acadêmicos.  
Dúvidas ou sugestões são bem-vindas!
