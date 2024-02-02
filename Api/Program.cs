using System.Reflection;
using System.Text.Json;
using Fleck;
using lib;
using Service1.Service;


var builder = WebApplication.CreateBuilder(args);


//Tilføjer data til data array
builder.Services.AddSingleton<DataService>();
DataService dataservice = new DataService();
dataservice.tilføjDeltagere();




var clientEventHandlers = builder.FindAndInjectClientEventHandlers(Assembly.GetExecutingAssembly());

var app = builder.Build();

var server = new WebSocketServer("ws://0.0.0.0:8181");

var wsConenctions = new List<IWebSocketConnection>();

server.Start(ws =>
{
    ws.OnOpen = () =>
    {


        //Her sendes tiltagere til frontenden ved start
        var echo = new TilføjDeltagere()
        {
            deltager = dataservice.sendList()
        };
        var messageToClient = JsonSerializer.Serialize(echo);
        ws.Send(messageToClient);

        wsConenctions.Add(ws);
        
        
        
        
        

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




public class TilføjDeltagere : BaseDto
{
    public List<string> deltager { get; set; }
}