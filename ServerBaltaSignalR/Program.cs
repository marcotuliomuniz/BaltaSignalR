using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<MyHub>("/chat");

app.Run();
record DateIformation(DateTime TheDate, string TheDayOfWeek);
class MyHub : Hub
{
    public async IAsyncEnumerable<DateIformation> Streaming([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            var nowDate = DateTime.Now;
            yield return new DateIformation(nowDate, nowDate.DayOfWeek.ToString());
            await Task.Delay(1000, cancellationToken);
        }
    }
}