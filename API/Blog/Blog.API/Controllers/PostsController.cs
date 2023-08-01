using Blog.API.Data;
using Blog.API.Models.DTO;
using Blog.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly BlogDbContext dbContext;

        public PostsController(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Geting all post
        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts= await dbContext.Posts.ToListAsync();
            return Ok(posts);
        }
        //Get post
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetPostById")]

        public async Task<IActionResult> GetPostById(Guid id)
        {
            var post = await dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if(post != null)
            {
                return Ok(post);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddPost(AddPostRequest addPostRequest)
        {
            //convert DTO to entity
            var post = new Post()
            {
                Title = addPostRequest.Title,
                Content = addPostRequest.Content,
                Author = addPostRequest.Author,
                FeatureImageUrl = addPostRequest.FeatureImageUrl,
                PublishDate = addPostRequest.PublishDate,
                UpdatedDate = addPostRequest.UpdatedDate,
                Summery = addPostRequest.Summery,
                UrlHandle = addPostRequest.UrlHandle,
                Visible = addPostRequest.Visible,
            };
            post.Id=Guid.NewGuid();
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdatePost([FromRoute]Guid id,UpdatePostRequest updatePostRequest)
        {
            ////convert DTO to entity
            //var post = new Post()
            //{
            //    Title = updatePostRequest.Title,
            //    Content = updatePostRequest.Content,
            //    Author = updatePostRequest.Author,
            //    FeatureImageUrl = updatePostRequest.FeatureImageUrl,
            //    PublishDate = updatePostRequest.PublishDate,
            //    UpdatedDate = updatePostRequest.UpdatedDate,
            //    Summery = updatePostRequest.Summery,
            //    UrlHandle = updatePostRequest.UrlHandle,
            //    Visible = updatePostRequest.Visible,
            //};
            ////Check if exist
            var existingPost = await dbContext.Posts.FindAsync(id);
            if(existingPost != null)
            {
                existingPost.Title = updatePostRequest.Title;
                existingPost.Content = updatePostRequest.Content;
                existingPost.Author = updatePostRequest.Author;
                existingPost.FeatureImageUrl = updatePostRequest.FeatureImageUrl;
                existingPost.PublishDate = updatePostRequest.PublishDate;
                existingPost.UpdatedDate = updatePostRequest.UpdatedDate;
                existingPost.Summery = updatePostRequest.Summery;
                existingPost.UrlHandle = updatePostRequest.UrlHandle;
                existingPost.Visible = updatePostRequest.Visible;

                 await dbContext.SaveChangesAsync();
                return Ok(existingPost);
            };
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var existingPost =await dbContext.Posts.FindAsync(id);
            if(existingPost != null)
            {
                dbContext.Remove(existingPost);
                await dbContext.SaveChangesAsync();
                return Ok(existingPost);
            }
            return NotFound();
        }
    }
}
