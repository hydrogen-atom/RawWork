using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace sqlTest.Server.Models
{
    public class User 

    {
        /// <summary>
        /// 用户ID，主键
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [Required]
        [StringLength(30)]
        public string Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(30)]
        public string Nickname { get; set; }

        // 导航属性

        /// <summary>
        /// 关联的评论
        /// </summary>
        public ICollection<Comment> Comments { get; set; }

        /// <summary>
        /// 关联的地址
        /// </summary>
        public ICollection<Address> Addresses { get; set; }

        /// <summary>
        /// 关联的订单（作为用户A）
        /// </summary>
        [InverseProperty("UserA")]
        public ICollection<ExchangeDetails> ExchangeDetailsAsA { get; set; }

        /// <summary>
        /// 关联的订单（作为用户B）
        /// </summary>
        [InverseProperty("UserB")]
        public ICollection<ExchangeDetails> ExchangeDetailsAsB { get; set; }

        /// <summary>
        /// 关联的书籍（持有者）
        /// </summary>
        public ICollection<BookID> Books { get; set; }
    }
}
