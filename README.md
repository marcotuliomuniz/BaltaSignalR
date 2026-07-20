# ServerBaltaSignalR

Projeto de estudo em C#/.NET para explorar **streaming em tempo real** com **SignalR**, usando `IAsyncEnumerable` para enviar dados continuamente do servidor para o cliente através de uma conexão persistente (WebSockets).

## 📦 Estrutura do projeto

O projeto é dividido em duas aplicações independentes:

- **Servidor** (`ServerBaltaSignalR`): expõe um Hub SignalR que transmite dados a cada segundo.
- **Cliente** (`ClientBaltaSignalR`): uma aplicação console que se conecta ao Hub e consome o stream em tempo real.

## 🚀 Como executar

### 1. Servidor

```bash
cd ServerBaltaSignalR
dotnet run
```

O servidor sobe (por padrão) em algo como `http://localhost:5136`.

### 2. Cliente

Em outro terminal:

```bash
cd ClientBaltaSignalR
dotnet run
```

O cliente se conecta ao Hub e imprime no console os dados recebidos, um a cada segundo.

## 📝 Saída esperada

```
Data: 20/07/2026 17:04:04
Dia da semana: Monday
```

## 📚 Conceitos estudados

- **SignalR**: biblioteca do ASP.NET Core para comunicação em tempo real (WebSockets com fallback automático).
- **`IAsyncEnumerable<T>`**: permite criar métodos que geram valores de forma assíncrona e contínua, semelhante a um `async function*` (generator) do JavaScript.
- **`[EnumeratorCancellation]`**: garante que o `CancellationToken` do consumidor do stream seja propagado corretamente para dentro do iterador assíncrono, permitindo interromper o loop quando o cliente se desconecta.
- **`record`**: tipo imutável do C# usado para modelar DTOs (Data Transfer Objects) de forma concisa — o equivalente "tipado" de um objeto simples do JavaScript.
- **Serialização/desserialização JSON automática**: servidor e cliente são processos independentes; a comunicação acontece via JSON, e cada lado precisa declarar seu próprio tipo com a mesma estrutura (mesmos nomes de propriedade) para que o SignalR consiga mapear os dados corretamente.

## ⚠️ Observações

- O `builder.Services.AddSignalR()` **deve ser chamado antes de `builder.Build()`** — depois de compilado (`Build()`), a coleção de serviços (`IServiceCollection`) se torna somente leitura.
- Ajuste a `url` no cliente conforme a porta exibida ao rodar o servidor (`dotnet run`).

## 🛠️ Tecnologias

- .NET 10
- ASP.NET Core SignalR
