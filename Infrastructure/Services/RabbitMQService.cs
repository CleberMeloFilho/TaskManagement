using RabbitMQ.Client;

namespace TaskManagement.Infrastructure.Services
{
    public class RabbitMQService : TaskManagement.Domain.Interfaces.IMessageService
    {
        public async System.Threading.Tasks.Task Publish(string message)
        {
            // Configuração da conexão com o RabbitMQ
            var factory = new RabbitMQ.Client.ConnectionFactory
            {
                HostName = "localhost", // Endereço do servidor RabbitMQ
                Port = 5672, // Porta padrão do RabbitMQ
                UserName = "guest", // Usuário padrão
                Password = "guest" // Senha padrão
            };

            // Cria a conexão de forma assíncrona
            RabbitMQ.Client.IConnection connection = await factory.CreateConnectionAsync();
            try
            {
                // Cria o canal
                RabbitMQ.Client.IChannel channel = (RabbitMQ.Client.IChannel)connection.CreateChannelAsync();
                try
                {
                    // Declara a fila "task_updates"
                    _ = channel.QueueDeclareAsync(
                        queue: "task_updates", // Nome da fila
                        durable: false, // A fila não é persistente
                        exclusive: false, // A fila não é exclusiva
                        autoDelete: false, // A fila não é excluída automaticamente
                        arguments: null // Argumentos adicionais (opcional)
                    );

                    // Converte a mensagem para bytes
                    var body = System.Text.Encoding.UTF8.GetBytes(message);
                    var props = new BasicProperties();
                    // Publica a mensagem na fila
                    await channel.BasicPublishAsync(
                        exchange: "", // Exchange padrão (direct)
                        routingKey: "task_updates", // Nome da fila
                        mandatory: true,
                        basicProperties: props, // Cria um objeto IBasicProperties
                        body: body
                    );
                }
                finally
                {
                    if (channel != null && channel.IsOpen)
                    {
                        await channel.CloseAsync();
                        channel.Dispose();
                    }
                }
            }
            finally
            {
                if (connection != null && connection.IsOpen)
                {
                    await connection.CloseAsync();
                    connection.Dispose();
                }
            }
        }
    }
}