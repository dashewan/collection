using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class RegistationFacade
    {
        RegisterCourse course  ;
        RegisterStudent student  ;
        public RegistationFacade()
        {
            course = new RegisterCourse();
            student = new RegisterStudent();
        }
        public bool RegisterCourse()
        {
            if (!course.CheckAvailable("aaa"))
            {
                return false;
            }
            return student.Notify("dfsdf");
        }
    }
}
