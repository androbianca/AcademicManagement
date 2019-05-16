import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-display-feedback',
  templateUrl: './display-feedback.component.html',
  styleUrls: ['./display-feedback.component.scss']
})
export class DisplayFeedbackComponent implements OnInit {

  @Input() feedbackStud:any;
  slideIndex = 0;

  constructor() { }

  plusSlides(n) {
    this.showSlides(this.slideIndex += n);
  }

  currentSlide(n) {
    this.slideIndex = n;
    this.showSlides(this.slideIndex);
  }

  showSlides(n) {
    let i;
    let j;
    const el = document.getElementsByClassName('display_off');
    const el2 = document.getElementsByClassName('display_on');

    for (i = 0; i < el.length; i++) {
      el[i].className = 'display_off';
    }
    for (j = 0; j < el2.length; j++) {
      el2[j].className = 'display_off';
    }

    if (n > el.length - 1) {
      this.slideIndex = 0;
    } else if (n < 0) {
      this.slideIndex = el.length - 1;
    }

    el[this.slideIndex].className = 'display_on';
  }

  ngOnInit() { 
    console.log(this.feedbackStud)
  }


}
