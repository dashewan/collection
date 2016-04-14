using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.SysManagement
{
    public class SysRoleModule
    {
        [Key]
        public int SysRoleModuleId { get; set; }

        [ForeignKey("SysModule")]
        public int SysModuleId { get; set; }

        [ForeignKey("SysRole")]
        public string SysRoleId { get; set; }

        public virtual SysModule SysModule { get; set; }
        public virtual SysRole SysRole { get; set; }
    }
}
