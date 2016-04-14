using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PCCHAT
{
    /// <summary>
    /// Talk.xaml 的交互逻辑
    /// </summary>
    public partial class Talk : Window
    {
        private static List<Talk> instanceList=new List<Talk>();
        private static Talk instance;
        public static Talk CreateForm(User user)
        {

            if (instance == null)
            {
                instance = new Talk(user);
            }
            return instance;
        }
        private Talk(User user)
        {
            InitializeComponent();
            this.Title = user.USERNAME;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            instance = null;
        }
    }
}
