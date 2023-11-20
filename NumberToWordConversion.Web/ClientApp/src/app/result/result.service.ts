import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable, Subject } from 'rxjs';
import { CommandResult } from './models/command-result.model';

@Injectable({
  providedIn: 'root'
})
export class ResultService {

  private conversionUrl:string = environment.baseUrl;
  private subject = new Subject<string>();

  constructor(private httpClient: HttpClient) { }

  onClickConversionFormEvent(value:string) {
    this.subject.next(value);
  }

  getOnClickConversionFormEvent(): Observable<string>{
    return this.subject.asObservable();
  }

  public getConvertedWord(number:string){
    return this.httpClient.get<CommandResult<string>>(`${this.conversionUrl}/${number}`)
  }

}
