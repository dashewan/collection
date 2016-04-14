using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WFConsole
{

    public sealed class insertDataToSQLServerActivity : NativeActivity
    {
        public InArgument<string> UserID { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            insertUserTable(UserID.Get(context));

        }



        void insertUserTable(string UserID)
        {

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();

            con.ConnectionString = "Data Source=WANGTAO;Initial Catalog=WFTest;Integrated Security=True;";

            con.Open();

            System.Data.SqlClient.SqlCommand cmd = con.CreateCommand();

            cmd.CommandText = string.Format("insert into UserTable (UserID) values ('{0}')", UserID);

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
