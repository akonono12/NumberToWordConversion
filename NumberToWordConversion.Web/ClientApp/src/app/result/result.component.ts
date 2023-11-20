import { Component, OnInit } from '@angular/core';
import { ResultService } from './result.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.css']
})
export class ResultComponent implements OnInit {
 public result:string = "";
 onClickConversionFormEventSubscription: Subscription = new Subscription;
  constructor(private resultService:ResultService)
  {
    this.onClickConversionFormEventSubscription = this.resultService.getOnClickConversionFormEvent()
    .subscribe(data =>{
      this.convertToWord(data);
    })
  }

  ngOnInit() {
  }




  public convertToWord(number:string){
    this.resultService.getConvertedWord(number).subscribe(data =>{
     if(data.success){
      this.result = data.data || "";
     }else{
      this.result = ""
      alert(data.errors.join("\n"));
     }
    })
  }

}
