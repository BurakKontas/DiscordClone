# Discord Clone Backend

This project aims to create a backend system for a Discord-like application using microservices architecture. The architecture follows a star topology, where a central service acts as a mediator for communication between other services.

## Architecture Overview

### Components

- **CenterService**: The central service responsible for routing requests and orchestrating communication between other services.
- **MessageService**: A service handling message-related functionalities. Utilizes Elasticsearch as the database.
- **AuthService**: A service responsible for user authentication and authorization.

### Communication

Communication between services is facilitated via gRPC, while the CenterService also exposes REST endpoints for external communication. The CenterService acts as a mediator, receiving requests via REST, then forwarding them to the appropriate services using gRPC. It also aggregates responses from different services and returns them to the client.

## Installation

### Prerequisites

- .NET Core SDK
- Docker (optional, for running Elasticsearch)

### Steps

1. Clone this repository.
2. Navigate to each service directory (`CenterService`, `MessageService`, `AuthService`) and run `dotnet build` to build the projects.
3. Optionally, set up and run Elasticsearch for the `MessageService`.
4. Start each service using `dotnet run` or by running the Docker containers (if configured).

## Usage

### REST Endpoints

#### CenterService

- **Messages**: 
  - `POST /message/addmessage`: Add a new message.
  - `GET /message/getmessages`: Get all messages.
  - `GET /message/getmessage`: Get a specific message by ID.
  - `PUT /message/updatemessage`: Update a message.
  - `DELETE /message/deletemessage`: Delete a message.
  - `GET /message/getmessagesbychannel`: Get messages by channel.
  - `GET /message/getmessagesbyuser`: Get messages by user.
  - `GET /message/getmessagesbydate`: Get messages by date.

- **Authentication**:
  - `POST /auth/validatetoken`: Validates a token.
  - `POST /auth/banuser`: Bans a user.
  - `POST /auth/unbanuser`: Unbans a user.
  - `POST /auth/register`: Registers a new user.
  - `POST /auth/login`: Logs in a user.
  - `POST /auth/forgotpassword`: Initiates the process for resetting a password.
  - `POST /auth/refreshtoken`: Refreshes a token.
  - `POST /auth/extracttoken`: Extracts a token.

- **Email**
  - `POST /email/sendaccountverificationemail`: Sends account verification email.
  - `POST /email/sendresetpasswordemail`: Sends password reset email.
  - `POST /email/sendcustomemail`: Sends custom email with body and subject to one or multiple mail address.

### gRPC Communication

Internal communication between services is done via gRPC. Each service defines its own protocol buffers (protobuf) messages and RPC methods for communication.

Check proto files in Protos folder of each microservices service layer for gRPC service details.

## Contributing

Contributions are welcome! If you'd like to contribute to this project, please fork the repository, make your changes, and submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).
