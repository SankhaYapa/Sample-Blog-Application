import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminPostComponent } from './admin/admin-post/admin-post.component';
import { AdminViewPostComponent } from './admin/admin-view-post/admin-view-post.component';
import { AdminAddPostComponent } from './admin/admin-add-post/admin-add-post.component';
import { PostsComponent } from './posts/posts.component';
import { PostComponent } from './post/post.component';

const routes: Routes = [
  {
    path:'',
    component:PostsComponent
  },
  {
    path:'post/:id',
    component:PostComponent
  },
  {
    path:'admin/posts',
    component:AdminPostComponent
  },
  {
    path:'admin/posts/add',
    component:AdminAddPostComponent
  },
  {
    path:'admin/posts/:id',
    component:AdminViewPostComponent
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
