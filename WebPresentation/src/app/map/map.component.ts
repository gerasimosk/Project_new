import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { loadModules } from 'esri-loader';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {

  @ViewChild('mapViewNode') private viewNode: ElementRef; // needed to inject the MapView into the DOM
  mapView: __esri.MapView;

  constructor() {}

  ngOnInit() {
    return loadModules([
      'esri/Map',
      'esri/views/SceneView',
      'esri/Graphic'
    ])
      .then(([Map, MapView, Graphic]) => {
        const map: __esri.Map = new Map({
          basemap: 'hybrid',
          ground: "world-elevation"
        });

        this.mapView = new MapView({
          container: this.viewNode.nativeElement,
          center: [14.514, 35.898],
          zoom: 15,
          map: map
        });
      })
      .catch(err => {
        console.log(err);
      });
  }

}
