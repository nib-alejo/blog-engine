import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';

import { PLATFORM_ID, APP_ID, Inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';

// Blog engine modules
import { RoutingModule } from './app.routes';

// Components
import { AppComponent } from './app.component';
import { LandingComponent } from './landing/landing.component';
import { LoginComponent } from './login/login.component';
import { WriterComponent } from './writer/writer.component';
import { EditorComponent } from './editor/editor.component';
import { BlogComponent } from './blog/blog.component';
import { PublishedBlogComponent } from './blog/published-blog.component';

// Services
import { DataService } from './common/services/data.service';
import { HttpService } from './common/services/http.service';


@NgModule({
  imports: [
    BrowserModule.withServerTransition({ appId: 'tour-of-heroes' }),
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RoutingModule
    /*
    // The HttpClientInMemoryWebApiModule module intercepts HTTP requests
    // and returns simulated server responses.
    // Remove it when a real server is ready to receive requests.
    HttpClientInMemoryWebApiModule.forRoot(
      InMemoryDataService, { dataEncapsulation: false }
    ),
*/
  ],
  declarations: [
    AppComponent,
    LandingComponent,
    LoginComponent,
    WriterComponent,
    EditorComponent,
    BlogComponent,
    PublishedBlogComponent
  ],
  providers: [
    DataService,
    HttpService
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule {
  constructor(
    @Inject(PLATFORM_ID) private platformId: object,
    @Inject(APP_ID) private appId: string) {
    const platform = isPlatformBrowser(platformId) ?
      'in the browser' : 'on the server';
    console.log(`Running ${platform} with appId=${appId}`);
  }
}
