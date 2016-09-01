import {inject} from "aurelia-framework";
import {HttpClient} from "aurelia-fetch-client";

@inject(HttpClient)
export class Home {

    constructor(httpClient) {
        this.httpClient = httpClient;
        this.data = {};
    }

}