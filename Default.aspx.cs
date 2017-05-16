using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

public partial class _Default : System.Web.UI.Page
{
    public static string conn = "server=b1cd7557-6515-4315-b173-a41000718d78.mysql.sequelizer.com;User Id=qhjmurvgkjyckfli;Password=igJW4areBPSwLjbX3JVDAbLwAKKBhG5z3mME5hFL8sai7ALovjkWz73gCnurwW53;Persist Security Info=True;database=dbb1cd755765154315b173a41000718d78";
    MySqlConnection c1 = new MySqlConnection(conn);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
        //    DataTable dt = this.GetData("select Mobile as HeartRate,Latitude as Temperature from sample");
          //  rptMarkers.DataSource = dt;
          //  rptMarkers.DataBind();
            bindgrid("select Mobile as HeartRate,Latitude as Temperature,Longitude as BloodPressure,DateTime from sample");            
        }
    }
    public void bindgrid(string rr)
    {
        try
        {
            DataSet dt = new DataSet();
            c1.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(rr, c1);
            da.Fill(dt);
            GridView1.DataSource = dt.Tables[0];
            GridView1.DataBind(); da.Dispose();
        }
        catch (Exception er)
        {
        }
        finally
        {
            c1.Close();
        }
    }
    //private DataTable GetData(string query)
    //{
    //    string conString = conn;
    //    MySqlCommand cmd = new MySqlCommand(query);
    //    using (MySqlConnection con = new MySqlConnection(conString))
    //    {
    //        using (MySqlDataAdapter sda = new MySqlDataAdapter())
    //        {
    //            cmd.Connection = con;
    //            sda.SelectCommand = cmd;
    //            using (DataTable dt = new DataTable())
    //            {
    //                sda.Fill(dt);
    //                return dt;
    //            }
    //        }
    //    }
    //}
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bindgrid("select Mobile as HeartRate,Latitude as Temperature,Longitude as BloodPressure,DateTime from sample");
    }
}
