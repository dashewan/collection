using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public abstract class Vegetable
    {
        public void CookVegetabel()
        {
            Console.WriteLine("抄蔬菜的一般做法");
            this.pourOil();
            this.HeatOil();
            this.pourVegetable();
            this.stir_fry();
        }
        public void pourOil()
        {
            Console.WriteLine("倒油");
        }


        // 把油烧热
        public void HeatOil()
        {
            Console.WriteLine("把油烧热");
        }


        // 油热了之后倒蔬菜下去，具体哪种蔬菜由子类决定
        public abstract void pourVegetable();


        // 开发翻炒蔬菜
        public void stir_fry()
        {
            Console.WriteLine("翻炒");
        }
    }
}
