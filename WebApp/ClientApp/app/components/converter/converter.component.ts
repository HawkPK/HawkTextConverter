import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'converter',
    templateUrl: './converter.component.html'
})
export class ConverterComponent {
    private csvTextFormat: string = "";
    private xmlTextFormat : string = "";
    baseUrl: string;
    http: Http;
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }
    convertToCsv(text: string) {
        if (text) {
            let url = this.getUrl('ConvertToXml', text);
            this.http.get(url).subscribe(result => {
                var content = result.json() as Content;
                this.csvTextFormat = content.textFormatted; 
            }, error => console.error(error));
        }
    }
    convertToXml(text: string){
        if (text) {
            let url = this.getUrl('ConvertToCsv', text);
            this.http.get(url).subscribe(result => {
                var content = result.json() as Content;
                this.xmlTextFormat = content.textFormatted;
            }, error => console.error(error));
        }
    }  
    getUrl(convertType : string, text : string) {
        return this.baseUrl + 'api/ConverterText/' + convertType + '?text=' + "" + text + "";
    }
}

interface Content{
    textFormatted : string
}

interface Statement{
    TextFormatted : string
}
