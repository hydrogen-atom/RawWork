using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace sqlTest.Server.Models
{
    public class ISBNCode
    {
        /// <summary>
        /// ISBN码，主键
        /// </summary>
        [Key]
        [StringLength(13)]
        public string ISBN { get; set; }

        /// <summary>
        /// 书名
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        /// <summary>
        /// 出版社
        /// </summary>
        [Required]
        [StringLength(100)]
        public string PublishHouse { get; set; }

        // 导航属性

        /// <summary>
        /// 关联的评论
        /// </summary>
        public ICollection<Comment> Comments { get; set; }

        /// <summary>
        /// 关联的具体书籍
        /// </summary>
        public ICollection<BookID> Books { get; set; }
    }
}
