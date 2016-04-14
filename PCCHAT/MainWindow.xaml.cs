using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PCCHAT
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        OnLine line = new OnLine();
        List<User> userList = new List<User>();
        Thread thread;
        Thread thread1;
        Thread thread2;
        public MainWindow()
        {
            InitializeComponent();
        }

      
        
        public void ModifyUI()
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            thread = new Thread(new ThreadStart(line.SendOnLine));
            thread.Start();
            thread1 = new Thread(new ThreadStart(line.ReceiveOnLine));
            thread1.Start();
            thread2 = new Thread(new ThreadStart(OnLineUser));
            thread2.Start();
        }
        public void OnLineUser()
        {
            while (true)
            {
                lock (this)
                {
                    List<User> list = line.OnLineUser();
                    List<User> list1 = list.Except(userList).ToList();
                    userList.Clear();
                    userList.AddRange(list);

                    foreach (User u3 in list1)
                    {
                        listView.Dispatcher.Invoke(new Action(() =>
                        {
                            if (u3.STATUS == User.ENUMSTATUS.ON)
                            {
                                listView.Items.Add(u3);
                            }
                            else
                            {
                                listView.Items.Remove(u3);
                                userList.Remove(u3);
                            }


                        }));
                    }
                }
                Thread.Sleep(300);
            }
        }

        private void listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object o=listView.SelectedItem;
            User item = (User)o;
            Talk talk =Talk.CreateForm(item);
            talk.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            thread.Abort();
            thread1.Abort();
            thread2.Abort();
            line.SendOffLine();
        }
    }
}
