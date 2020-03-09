import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent }   from './app.component';
import { BoldDirective} from './bold.directive';
 
@NgModule({
    imports:      [ BrowserModule],
    declarations: [ AppComponent, BoldDirective],
    bootstrap:    [ AppComponent ]
})
export class AppModule { }