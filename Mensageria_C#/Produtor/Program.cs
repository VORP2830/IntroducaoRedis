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
            Console.Write("Digite a mensagem (ou pressione Enter para sair): ");
            string mensagem = Console.ReadLine();

            if (string.IsNullOrEmpty(mensagem))
                break;

            db.ListLeftPush(fila_nome, mensagem);
        }

        Console.WriteLine("Fechando o produtor.");
    }
}
