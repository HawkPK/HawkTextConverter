import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'converter',
    templateUrl: './converter.component.html'
})
export class ConverterComponent {
    public currentCount = 0;
    private message : string = "";
    public csvTextFormat: string = "";
    public csvText : string = "";
    private xmlTextFormat : string = "";
    baseUrl: string;
    http: Http;
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }
    convertToCsv(text: string) {
        if (text) {
          console.log(this.message)
          var url = this.baseUrl + 'api/SampleData/ConvertToXml?text=' + "" + text + "";
          console.log(url);
          this.http.get(url).subscribe(result => {
            var content = result.json() as Content;
            this.xmlTextFormat = content.textFormatted;
            console.log(this.xmlTextFormat);
          }, error => console.error(error));
          var url = this.baseUrl + 'api/SampleData/ConvertToCsv?text=' + "" + text + "";
          console.log(url);
          this.http.get(url).subscribe(result => {
              var content = result.json() as Content;
              this.csvTextFormat = content.textFormatted;
              console.log(this.csvTextFormat);
          }, error => console.error(error));
        }
    }
    convertToXml(text: string){
        if (text) {
            // this.message = textContent;
            // this.xmlTextFormat = textContent;
            // console.log(this.xmlTextFormat)
        }  
    }

    public incrementConverter() {
        this.currentCount++;
    }
}

interface Content{
    textFormatted : string
}

interface Statement{
    TextFormatted : string
}
