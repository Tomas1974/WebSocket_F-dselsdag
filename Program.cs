

using System.Reflection;
using System.Text.Json;
using Fleck;
using lib;
using ws;


ArrayListData.tilføjDeltagere();

var builder = WebApplication.CreateBuilder(args);

var clientEventHandlers = builder.FindAndInjectClientEventHandlers(Assembly.GetExecutingAssembly());

var app = builder.Build();

var server = new WebSocketServer("ws://0.0.0.0:8181");

var wsConenctions = new List<IWebSocketConnection>();

server.Start(ws =>
{
    ws.OnOpen = () =>
    {
        var echo = new TilføjDeltagere()
        {
            deltager = ArrayListData.deltagerListe
        };
        var messageToClient = JsonSerializer.Serialize(echo);
        ws.Send(messageToClient);

        wsConenctions.Add(ws);
    };
    ws.OnMessage = message =>
    {
        // evaluate whether or not message.eventType == 
            // trigger event handler
        try
        {
            app.InvokeClientEventHandler(clientEventHandlers, ws, message);

        }
        catch (Exception e)
        {
            // your exception handling here
        }
    };
});

Console.ReadLine();