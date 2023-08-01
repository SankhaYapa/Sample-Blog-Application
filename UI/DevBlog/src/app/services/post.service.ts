import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Post } from '../models/post.model';
import { UpdatePostRequest } from '../models/update-model';
import { AddPostRequest } from '../models/add-post.model';
@Injectable({
  providedIn: 'root'
})
export class PostService {
  baseUrl='https://localhost:7136/api/Posts'
  constructor(private http:HttpClient) { }

  getAllPosts():Observable<Post[]>{
    return this.http.get<Post[]>(this.baseUrl);
  }
  getPostById(id:string):Observable<Post>{
    return this.http.get<Post>(this.baseUrl+"/"+id)
  }
  updatePost(id:string|undefined,updatePostRequest:UpdatePostRequest):Observable<Post>{
  return this.http.put<Post>(this.baseUrl+"/"+id,updatePostRequest)
  }
  addPost(addPostRequest:AddPostRequest):Observable<Post>{
   return this.http.post<Post>(this.baseUrl,addPostRequest)
  }
  deletePost(id:string|undefined):Observable<Post>{
    return this.http.delete<Post>(this.baseUrl+"/"+id)
  }
}
