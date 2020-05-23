using LearningApi.Models;
using System.Collections.Generic;

namespace Learning_Api.Models
{
    public class QuestionAnswers
    {
        public Post Question { get; set; }
        public IEnumerable<Post> Answers { get; set; }
    }
}
