using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace sqlTest.Server.Models
{
    public class ExchangeDetails
    {
        /// <summary>
        /// 订单号，主键
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExchangeID { get; set; }

        /// <summary>
        /// 用户A，外键
        /// </summary>
        [Required]
        public int ID_A { get; set; }

        /// <summary>
        /// 用户B，外键
        /// </summary>
        [Required]
        public int ID_B { get; set; }

        /// <summary>
        /// 漂流书籍，外键
        /// </summary>
        [Required]
        public int BookID { get; set; }

        /// <summary>
        /// 快递单号
        /// </summary>
        [Required]
        [StringLength(30)]
        public string TrackingID { get; set; }

        /// <summary>
        /// 是否同意
        /// </summary>
        [Required]
        public bool IsApproved { get; set; }

        // 导航属性

        /// <summary>
        /// 关联的用户表（用户A）
        /// </summary>
        [ForeignKey("ID_A")]
        public User UserA { get; set; }

        /// <summary>
        /// 关联的用户表（用户B）
        /// </summary>
        [ForeignKey("ID_B")]
        public User UserB { get; set; }

        /// <summary>
        /// 关联的具体书表
        /// </summary>
        [ForeignKey("BookID")]
        public BookID Book { get; set; }
    }
}
