using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Fleck;
using lib;

namespace ws;

public class ClientWantsToGetDeltagereDto : BaseDto
{
    
    public string messageContent { get; set; }
}

public class ClientWantsToGetAllDeltagereDto : BaseDto
{
    
}

public class ClientWantsToGetDeltagere : BaseEventHandler<ClientWantsToGetDeltagereDto>
{
    
    public override Task Handle(ClientWantsToGetDeltagereDto dto, IWebSocketConnection socket)
    {
        ArrayListData.deltagerListe.Add(dto.messageContent);
        var echo = new TilføjDeltagere()
        {
            deltager = ArrayListData.deltagerListe
        };
        var messageToClient = JsonSerializer.Serialize(echo);
        socket.Send(messageToClient);
        
        return Task.CompletedTask;
    }
}

public class ClientWantsToGetAllDeltagere : BaseEventHandler<ClientWantsToGetAllDeltagereDto>
{
    
    public override Task Handle(ClientWantsToGetAllDeltagereDto dto, IWebSocketConnection socket)
    {
        var echo = new TilføjDeltagere()
        {
            deltager = ArrayListData.deltagerListe
        };
        var messageToClient = JsonSerializer.Serialize(echo);
        socket.Send(messageToClient);
        
        return Task.CompletedTask;
    }
}

public class TilføjDeltagere : BaseDto
{
    public List<string> deltager { get; set; }
}







