import { Component, OnInit, Input } from "@angular/core";
import { CdkConnectedOverlay, Overlay, ScrollStrategy, CdkOverlayOrigin } from '@angular/cdk/overlay';
import { SignalRService } from 'src/app/services/signalR-service.service';

@Component({
  selector: "app-top-bar",
  templateUrl: "./top-bar.component.html",
  styleUrls: ["./top-bar.component.scss"]
})
export class TopBarComponent implements OnInit {

  panelOpen = false;

  constructor(protected overlay: Overlay,private signalRService: SignalRService) { }

  ngOnInit() { }

  toggle() {
    this.panelOpen ? this.close() : this.open();
  }

  close() {
    this.panelOpen = false;
  }

  open() {
    this.panelOpen = true;
  }

}
