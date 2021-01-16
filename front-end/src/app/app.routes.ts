import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LandingComponent } from './landing/landing.component';
import { LoginComponent } from './login/login.component';
import { WriterComponent } from './writer/writer.component';
import { EditorComponent } from './editor/editor.component';
import { BlogComponent } from './blog/blog.component';
import { PublishedBlogComponent } from './blog/published-blog.component';

const router: Routes = [
  { path: '', redirectTo: 'landing', pathMatch: 'full' },
  {
    path: 'landing', component: LandingComponent, children: [
      { path: '', component: PublishedBlogComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'writer', component: WriterComponent },
      { path: 'editor', component: EditorComponent },
      { path: 'blog', component: BlogComponent }
    ]
  }
]

@NgModule({
  imports: [
    RouterModule.forRoot(router)
  ],
  exports: [
    RouterModule
  ]
})
export class RoutingModule { }