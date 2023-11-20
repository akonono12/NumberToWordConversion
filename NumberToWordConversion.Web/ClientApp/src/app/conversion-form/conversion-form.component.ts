import { Component, OnInit } from '@angular/core';
import { ResultService } from '../result/result.service';

@Component({
  selector: 'app-conversion-form',
  templateUrl: './conversion-form.component.html',
  styleUrls: ['./conversion-form.component.css']
})
export class ConversionFormComponent implements OnInit {

  public number:string = "";
  constructor(private resultService:ResultService) { }

  ngOnInit() {

  }

  onClickConvert(){
    this.resultService.onClickConversionFormEvent(this.number);
  }

}
