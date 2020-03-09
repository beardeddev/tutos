import { Component} from '@angular/core';
       
@Component({
    selector: 'my-app',
    template: `<child-comp [(userName)]="name"></child-comp>
                <div>Выбранное имя: {{name}}</div>`
})
export class AppComponent { 
 
    name: string = "Tom";
}