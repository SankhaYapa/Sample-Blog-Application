import { Component,OnInit  } from '@angular/core';
import { PostService } from '../services/post.service';
import { Post } from '../models/post.model';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {
  constructor(private postService:PostService){}
  posts:Post[]=[];


  ngOnInit(): void {
      this.postService.getAllPosts()
      .subscribe(
        response=>{
          this.posts=response;
        }
      )
  }
}
