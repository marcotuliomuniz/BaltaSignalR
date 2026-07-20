
using Microsoft.AspNetCore.SignalR.Client;

const string url = "http://localhost:5136/chat";

await using var connection = new HubConnectionBuilder().WithUrl(url).Build();

await connection.StartAsync();

await foreach (var info in connection.StreamAsync<DateIformation>("Streaming"))
{
    Console.WriteLine($"""
    DATA COMPLETA: {info.TheDate}
    DIA DA SEMANA: {info.TheDayOfWeek}
    ーーーーーーーーーーーーーーーーーー
    """);
}

record DateIformation(DateTime TheDate, string TheDayOfWeek);