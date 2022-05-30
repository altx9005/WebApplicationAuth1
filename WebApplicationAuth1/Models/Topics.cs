using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationAuth1.Models
{
    public class Topic
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Заполните название Темы")]
        [Display(Name = "Название")]
        public string NameTopic { get; set; }
        public string UserName { get; set; }

    }

    public class Post
    {
        public int Id { get; set; }
        public int TopicId { get; set; }

        [Required]
        [Display(Name = "Заполните содержание поста")]
        public string Text { get; set; }
        public string Author { get; set; }
        public Topic Topic { get; set; }
    }
}