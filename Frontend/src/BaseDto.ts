export class BaseDto<T> {
  eventType: string;

  constructor(init?: Partial<T>) {
    this.eventType = this.constructor.name;
    Object.assign(this, init)
  }
}


export class ServerEchosClientDto extends BaseDto<ServerEchosClientDto> {
  echoValue?: string;
}



export class ClientWantsToGetDeltagereDto extends BaseDto<ClientWantsToGetDeltagereDto> {
  deltager?: string[];
}

export class ClientWantsToGetAllDeltagereDto extends BaseDto<ClientWantsToGetAllDeltagereDto> {
  deltager?: string[];
}