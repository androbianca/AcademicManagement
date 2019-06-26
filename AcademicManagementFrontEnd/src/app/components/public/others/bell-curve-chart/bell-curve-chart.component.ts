import { Component, OnInit, ViewChild, ElementRef, AfterViewChecked, AfterViewInit, Input, HostBinding } from '@angular/core';
import * as Highcharts from 'highcharts';
import Bellcurve from 'highcharts/modules/histogram-bellcurve';
import { Chart } from 'angular-highcharts';
import { FinalGradeService } from 'src/app/services/final-grade.service';

Bellcurve(Highcharts);

@Component({
    selector: 'app-bell-curve-chart',
    templateUrl: './bell-curve-chart.component.html',
    styleUrls: ['./bell-curve-chart.component.scss']
})

export class BellCurveChartComponent implements OnInit {
    
    @Input() courseId: string;
    @Input() data : number[];
    chart: Chart;

    ngOnInit(): void {

        this.createChart(this.data);
    }

    createChart(data) {
        this.chart = new Chart({
            title: {
                text: 'BellCurve'
            },
            xAxis: [{
                alignTicks: false
            }, {
                alignTicks: false,
                opposite: true
            }],

            yAxis: [{
            }, {
                opposite: true
            }],

            series: [{
                name: 'BellCurve',
                type: 'bellcurve',
                xAxis: 1,
                yAxis: 1,
                baseSeries: 's1',
                zIndex: -1
            }, {
                name: 'Data',
                type: 'scatter',
                data: data,
                visible: false,
                id: 's1',
                marker: {
                    radius: 1.5
                }
            }]
        });
    }


}