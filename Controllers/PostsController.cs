using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learning_Api.Models;
using LearningApi.Data;
using LearningApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly LearningAppContext _context;

        public PostsController(LearningAppContext context)
        {
            _context = context;
        }

        // GET: api/questions
        [HttpGet]
        // [Route("questions")]
        public async Task<ActionResult<IEnumerable<Post>>> GetQuestions([FromQuery] PostParameter postParameter)
        {
            return await _context.PostsDB
                .OrderBy(a => a.Id)
                .Where(a => a.PostTypeId == 1)
                .Skip((postParameter.PageNumber - 1) * postParameter.PageSize)
                .Take(postParameter.PageSize)
                .ToListAsync();
        }

        // GET: api/Answers
        [HttpGet("answers")]
        // [Route("answers")]
        public async Task<ActionResult<IEnumerable<Post>>> GetAnswers([FromQuery] PostParameter postParameter)
        {
            return await _context.PostsDB
                .OrderBy(a => a.Id)
                .Where(a => a.PostTypeId == 2)
                .Skip((postParameter.PageNumber - 1) * postParameter.PageSize)
                .Take(postParameter.PageSize)
                .ToListAsync();
        }

        [HttpGet("fullposts")]
        // [Route("fullposts")]
        public async Task<ActionResult<IEnumerable<MultiplePosts>>> GetFullPosts([FromQuery] PostParameter postParameter)
        {
            var result = await _context.PostsDB
                .OrderBy(a => a.Id)
                .Where(a => a.PostTypeId == 1 && a.AcceptedAnswerId != null) // question
                .Skip((postParameter.PageNumber - 1) * postParameter.PageSize)
                .Take(postParameter.PageSize)
                .Join(_context.PostsDB, // answer
                    question => question.AcceptedAnswerId,
                    answer => answer.Id,
                    (question, answer) => new MultiplePosts
                    {
                        Question = question,
                        Answer = answer
                    }).ToListAsync();
            return result;

        }

        [HttpGet("fullposts/{questionId}")]
        public async Task<ActionResult<QuestionAnswers>> GetFullPosts(int questionId)
        {
            var questionsAnswers = await (from question in _context.PostsDB
                                          where question.Id == questionId && question.PostTypeId == 1
                                          join post in _context.PostsDB
                                          on question.Id equals post.ParentId
                                          into QuestionAnswers
                                          from answer in QuestionAnswers
                                          where answer.ParentId == questionId
                                          select new { question, answer }).ToListAsync();
            var result = (from post in questionsAnswers
                          group post by post.question into g
                          select new QuestionAnswers
                          { Question = g.Key, Answers = g.ToList().Select(x => x.answer) })
                          .FirstOrDefault();

            return result;

        }

        [HttpGet("tag")]
        public async Task<ActionResult<Post>> GetTag([FromBody] string tagName)
        {
            var result = await _context.TagsDB
                .Where(tag => tag.TagName == tagName)
                .Join(_context.PostsDB,
                tag => tag.WikiPostId,
                post => post.Id,
                (tag, post) => post).SingleOrDefaultAsync();
            return result;
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostsDb(int? id)
        {
            var postsDb = await _context.PostsDB.FindAsync(id);

            if (postsDb == null)
            {
                return NotFound();
            }

            return postsDb;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostsDb(int? id, Post postsDb)
        {
            if (id != postsDb.Id)
            {
                return BadRequest();
            }

            _context.Entry(postsDb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostsDbExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Post>> PostPostsDb(Post postsDb)
        {
            _context.PostsDB.Add(postsDb);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostsDb", new { id = postsDb.Id }, postsDb);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePostsDb(int? id)
        {
            var postsDb = await _context.PostsDB.FindAsync(id);
            if (postsDb == null)
            {
                return NotFound();
            }

            _context.PostsDB.Remove(postsDb);
            await _context.SaveChangesAsync();

            return postsDb;
        }

        private bool PostsDbExists(int? id)
        {
            return _context.PostsDB.Any(e => e.Id == id);
        }
    }
}