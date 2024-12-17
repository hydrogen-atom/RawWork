using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sqlTest.Server.Models
{
    public class BookID
    {
        /// <summary>
        /// 具体书ID，主键
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bookID { get; set; }

        /// <summary>
        /// ISBN码，外键
        /// </summary>
        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }

        /// <summary>
        /// 用户ID（持有者），外键
        /// </summary>
        [Required]
        public int UserID { get; set; }

        /// <summary>
        /// 书籍状态
        /// </summary>
        [Required]
        public int BookState { get; set; }

        // 导航属性

        /// <summary>
        /// 关联的 ISBN 码表
        /// </summary>
        [ForeignKey("ISBN")]
        public ISBNCode ISBNCode { get; set; }

        /// <summary>
        /// 关联的用户表（持有者）
        /// </summary>
        [ForeignKey("UserID")]
        public User User { get; set; }

        /// <summary>
        /// 关联的评论
        /// </summary>
        public ICollection<Comment> Comments { get; set; }
    }
}
