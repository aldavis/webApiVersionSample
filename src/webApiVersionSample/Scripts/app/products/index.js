import {inject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';

let baseUrl = "api/products";

@inject(HttpClient)
export class Products {

    constructor(http) {
        this.http = http;
        this.products = [];
        this.productsV2 = [];
    }

    activate() {

        this.http.fetch(`${baseUrl}`)
            .then(response => response.json())
            .then(data => {
                this.products = (data).Products;
            });

        this.http.fetch(`${baseUrl}`, {
            headers: {'api-version': 2}
            })
            .then(response => response.json())
            .then(data => {
                this.products2 = (data).Products;
            });
    }

}
