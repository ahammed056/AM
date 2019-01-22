using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AM_EntityLayer;
using AM_DB_Layer;
using System.Net;

namespace AM
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {         
            loadddl();
           
        }

        private void loadddl()
        {
            AM_DB_Tranactions ad = new AM_DB_Tranactions();
            List<CPU_Details> aha = new List<CPU_Details>();
            aha = ad.hia();
            DropDownList1.DataSource = aha;
            DropDownList1.DataTextField = "CPU_IP_ADDRESS";
            DropDownList1.DataValueField = "Cpu_brand_id";
            DropDownList1.DataBind();
        }


       
        
        void Main()
        {
            // The files used in this example are created in the topic
            // How to: Write to a Text File. You can change the path and
            // file name to substitute text files of your own.

            // Example #1
            // Read the file as one string.

         ////   string text = System.IO.File.ReadAllText(@"C:\Users\ahammed.2921\Documents\GitHub\AM\AM\database.txt");

            // Display the file contents to the console. Variable text is a string.
         // //  System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
        //  //  Label2.Text = text;

          //  Label1.Text = "Contents of WriteText.txt = {0}",text;

            // Example #2
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\ahammed.2921\Documents\GitHub\AM\AM\database.txt");

            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of WriteLines2.txt = ");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
               // Console.WriteLine("\t" + line);
                string[] linesa = lines;
                Label1.Text = linesa[2];
            }

            // Keep the console window open in debug mode.
           // Console.WriteLine("Press any key to exit.");
            //System.Console.ReadKey();
        }

    }
}