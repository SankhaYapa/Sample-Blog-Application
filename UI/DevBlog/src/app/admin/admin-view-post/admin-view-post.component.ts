import { Component,OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Post } from 'src/app/models/post.model';
import { UpdatePostRequest } from 'src/app/models/update-model';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-admin-view-post',
  templateUrl: './admin-view-post.component.html',
  styleUrls: ['./admin-view-post.component.css']
})
export class AdminViewPostComponent implements OnInit {
  post:Post | undefined
  constructor(private route:ActivatedRoute,private postService:PostService){

  }
  ngOnInit(): void {
      this.route.paramMap.subscribe(
        params=>{
          const id=params.get('id');
          if(id){
            this.postService.getPostById(id)
            .subscribe(
              response=>{
                this.post=response
                console.log(response)
              }
            )
          }
        }
      )
  }
  onSubmit():void{
    const updatePostRequest:UpdatePostRequest={
      author:this.post?.author,
      content:this.post?.content,
      featureImageUrl:this.post?.featureImageUrl,
      publishDate:this.post?.publishDate,
      updatedDate:this.post?.updatedDate,
      visible:this.post?.visible,
      summery:this.post?.summery,
      urlHandle:this.post?.urlHandle,
      title:this.post?.title


    }
    this.postService.updatePost(this.post?.id,updatePostRequest)
    .subscribe(
      response=>{
        alert("Success")
      }
    )
  }
  deletePost():void{
    this.postService.deletePost(this.post?.id)
    .subscribe(
      response=>{
        alert('Deleted Successfully')
      }
    )
  }
}
