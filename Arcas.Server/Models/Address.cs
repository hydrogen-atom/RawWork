using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sqlTest.Server.Models
{
    public class Address
    {
        /// <summary>
        /// 地址ID，主键
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressID { get; set; }

        /// <summary>
        /// 是否默认地址
        /// </summary>
        [Required]
        public bool DefaultOrNot { get; set; }

        /// <summary>
        /// 用户ID，外键
        /// </summary>
        [Required]
        public int UserID { get; set; }

        /// <summary>
        /// 详细地址（内容）
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Content { get; set; }

        // 导航属性

        /// <summary>
        /// 关联的用户表
        /// </summary>
        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
