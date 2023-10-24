using System.Text.Json;
using StackExchange.Redis;
class Program
{
    static void Main()
    {
        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379, password=senha");
        IDatabase db = redis.GetDatabase();

        string chave = "pessoa";
        var valor = new { nome = "Victor", idade = 21 };
        TimeSpan tempo_de_expiracao = TimeSpan.FromSeconds(3600);

        string valor_serializado = JsonSerializer.Serialize(valor);

        db.StringSet(chave, valor_serializado, tempo_de_expiracao);

        string valor_recuperado = db.StringGet(chave);
        var valor_obj = JsonSerializer.Deserialize<object>(valor_recuperado);
        Console.WriteLine($"Valor recuperado: {valor_obj}");
        
    }
}
