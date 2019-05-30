import { Component, OnInit, ViewChild, ElementRef, AfterViewChecked, AfterViewInit, Input } from '@angular/core';
import * as Highcharts from 'highcharts';
import  Bellcurve from 'highcharts/modules/histogram-bellcurve';
Bellcurve(Highcharts);
import { Chart } from 'angular-highcharts';

@Component({
    selector: 'app-bell-curve-chart',
    templateUrl: './bell-curve-chart.component.html',
    styleUrls: ['./bell-curve-chart.component.scss']
})

export class BellCurveChartComponent implements OnInit {

    @Input() data ;
    chart : Chart;
  

     ngOnInit(): void {
        this.chart = new Chart({
        title: {
            text: 'Highcharts Histogram'
        },
        xAxis: [{
            title: { text: 'Data' },
            alignTicks: false
        }, {
            title: { text: 'Histogram' },
            alignTicks: false,
            opposite: true
        }],
    
        yAxis: [{
            title: { text: 'Data' }
        }, {
            title: { text: 'Histogram' },
            opposite: true
        }],
    
        series: [{
            name: 'Histogram',
            type: 'bellcurve',
            xAxis: 1,
            yAxis: 1,
            baseSeries: 's1',
            zIndex: -1
        }, {
            name: 'Data',
            type: 'scatter',
            data: this.data,
            visible: false,
            id: 's1',
            marker: {
                radius: 1.5
            }
        }]
        });}

 
}