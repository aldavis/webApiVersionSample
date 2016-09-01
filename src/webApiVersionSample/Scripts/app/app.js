export class App {
    
    configureRouter(config, router) {
        this.router = router;

        config.map([
            {route:["","home"],moduleId:"scripts/app/home/index",title:"Home",nav:true},
            {route:"products",moduleId:"scripts/app/products/index",title:"Products",nav:true}          
        ]);
    }
}