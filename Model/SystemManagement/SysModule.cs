using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Model.ValidationAttributes.Utility;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.SysManagement
{
    [Table("SysModule")]
    public class SysModule
    {
        [Key]
        public int SysModuleId { get; set; }
        [Column("ModuleName")]
        [Phone(ErrorMessage="dfdfdfdfdfdf")]
        public string ModuleName { get; set; }
        [Required()]
        [CompareValues("ControllerName", CompareValues.EqualTo, ErrorMessage = "<=About>")]
        public string ActionName { get; set; }
        public bool IsValid { get; set; }
        [Required()]
        public string ControllerName { get; set; }
        [Required(ErrorMessage = "Area不能为空")]
        public string AreaName { get; set; }
        public int SortId { get; set; }
        public string Remark { get; set; }
    }
}
