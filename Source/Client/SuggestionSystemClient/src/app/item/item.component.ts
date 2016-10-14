import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss']
})
export class ItemComponent implements OnInit {
  @Input() item;
  panelColor: string;

  constructor() {}

  ngOnInit() {
    var colors: string[] = ["warning", "primary", "default", "success", "danger"];
    this.panelColor = colors[this.item.Status];
  }

}
