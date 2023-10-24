using System;
using StackExchange.Redis;

class Program
{
    static void Main()
    {
        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379, password=senha");
        IDatabase db = redis.GetDatabase();

        string fila_nome = "mensagens";

        while (true)
        {
            RedisValue mensagem = db.ListRightPop(fila_nome);

            if (!mensagem.IsNullOrEmpty)
            {
                string mensagem_texto = mensagem.ToString();
                Console.WriteLine($"Mensagem recebida: {mensagem_texto}");
            }
        }
    }
}
