export class BaseDto<T> {
  eventType: string;

  constructor(init?: Partial<T>) {
    this.eventType = this.constructor.name;
    Object.assign(this, init)
  }
}


export class ClientWantsToGetAllDeltagereDto extends BaseDto<ClientWantsToGetAllDeltagereDto> {
  deltager?: string[];
}


export class SletDeltagerDto extends BaseDto<SletDeltagerDto> {
  deltager?: string;
}

