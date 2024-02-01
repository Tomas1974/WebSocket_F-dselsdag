import { Component } from '@angular/core';
import {UtilitiesService} from "./utilities.service";
import {FormControl} from "@angular/forms";
import {BaseDto} from "../BaseDto";

@Component({
  selector: 'app-root',
  template: `

    <ion-col>
      <ion-row>
        <img src="../assets/Fødselsdag.gif" alt="Animated GIF" >

<H1 style="margin-left: 20px;">Tilmeldingsliste Festen</H1>
      </ion-row>
    </ion-col>

<br>
<br>
<br>

<ion-grid>
  <ion-row>
    <ion-col size="3">
      <ion-title>Deltagere</ion-title>
      <ion-card >

        <div *ngFor="let text of textAray">

        <ion-card-content>

          <ion-row style="border-bottom: 1px solid black; /* Add a solid black border at the bottom of each row */
}">

            <ion-col >
          {{text}}
            </ion-col>
            <ion-col >
          <p style="color: blue; text-decoration: underline; cursor: pointer;" (click)="slet(text)">Slet</p>
            </ion-col>
            <ion-col >
          <p style="color: blue; text-decoration: underline; cursor: pointer;" (click)="opdater(text)">Opdater</p>
            </ion-col>

          </ion-row>

        </ion-card-content>


        </div>
      </ion-card>
    </ion-col>
    <ion-col size="6">

      <ion-row>


          <ion-button  (click)="nyTekst()">
            <ion-icon name="person-add-outline" slot="start"></ion-icon>
            Ny Deltager</ion-button>

      </ion-row>
      <ion-row>
      <ion-button (click)="sorteralfabetisk()">
        <ion-icon name="{{icon}}" slot="start"></ion-icon>
        Sorter Alfabetisk</ion-button>
      </ion-row>

    </ion-col>
  </ion-row>
</ion-grid>

  `,

})
export class AppComponent {

  textAray: string[]=["Hans","Sanne","Rikke","Frederik","Mette"];
sort: boolean=true;
icon: string="";



  ws: WebSocket = new WebSocket("ws://localhost:8181")




  constructor(private utilitiesService: UtilitiesService) {
    this.ws.onmessage = message => {
      const messageFromServer = JSON.parse(message.data) as BaseDto<any>;
      // @ts-ignore
      this[messageFromServer.eventType].call(this, messageFromServer);

  }
  }


  async slet(text: string) {
    let confirm=await this.utilitiesService.confirmDelete()

    if (confirm)
    this.textAray=this.textAray.filter(product => product != text);

  }

  async opdater(text:string) {

    let opdaterText=await this.utilitiesService.insertLine("Opdater", `Opdater ${text}`,
      text);

    if (opdaterText.length!=null)
    {
      const index = this.textAray.findIndex(p => p === text);

      if (index !== -1) {
        this.textAray[index] = opdaterText;
    }
  }
  }

  async nyTekst() {

    let text=await this.utilitiesService.insertLine("Nyt Navn", "Indsæt nyt navn",
      "navn");

    if (text.length!=null)
    this.textAray.push(text);
  }

  sorteralfabetisk() {

    if (this.sort)
    {
      this.textAray=this.textAray.sort((a, b) => a.localeCompare(b));
      this.sort=false;
      this.icon="caret-down-outline";

    }
    else
    {
      this.textAray=this.textAray.sort((a, b) => b.localeCompare(a));
      this.sort=true;
      this.icon="caret-up-outline";
    }

  }

}
