using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace sqlTest.Server.Models
{
    public class Comment
    {
        /// <summary>
        /// 评论ID，主键
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }

        /// <summary>
        /// ISBN号，外键
        /// </summary>
        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }

        /// <summary>
        /// 具体书ID，外键
        /// </summary>
        [Required]
        public int bookID { get; set; }

        /// <summary>
        /// 点赞数
        /// </summary>
        public int LikeNum { get; set; }

        /// <summary>
        /// 评论者ID，外键（关联到 UserTable 的 username）
        /// </summary>
        [Required]
        [StringLength(30)]
        public int CommentatorID { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        [Required]
        [Column(TypeName = "text")]
        public string CommentContent { get; set; }

        // 导航属性

        /// <summary>
        /// 关联的 ISBN 码表
        /// </summary>
        [ForeignKey("ISBN")]
        public ISBNCode ISBNCode { get; set; }

        /// <summary>
        /// 关联的具体书表
        /// </summary>
        [ForeignKey("BookID")]
        public BookID Book { get; set; }

        /// <summary>
        /// 关联的用户表（评论者）
        /// </summary>
        [ForeignKey("CommentatorID")]
        public User Commentator { get; set; }
    }
}
