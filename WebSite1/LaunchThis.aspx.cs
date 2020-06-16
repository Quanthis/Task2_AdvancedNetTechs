using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Task2_AdvancedNetTechs;

public partial class LaunchThis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected async void Button1_Click(object sender, EventArgs e)
    {
        string text = TextBox1.Text;

        //var forASPOnly = new ASPModifier(text);
        //Session["Important"] = await forASPOnly.ModifyText();
        //text = await forASPOnly.ModifyText();


        //System.Diagnostics.Debug.WriteLine("\nResult" + Session["Important"]);

        //System.Diagnostics.Debug.WriteLine("\nResult" + text);

        Session["sb"] = new StringBuilder(text + " ");
        
        //Session["ImportantValue"] = await HelperMethods.EMReplace(Session["sb"] as StringBuilder);
        Session["ImportantValue"] = await HelperMethods.ParagraphReplace(Session["ImportantValue"] as StringBuilder);
        Session["ImportantValue"] = await HelperMethods.Adres_Replace(Session["ImportantValue"] as StringBuilder);
        Session["ImportantValue"] = await HelperMethods.QReplace(Session["ImportantValue"] as StringBuilder);
        Session["ImportantValue"] = await HelperMethods.StrongReplace(Session["ImportantValue"] as StringBuilder);
        Session["ImportantValue"] = await HelperMethods.EMReplace(Session["ImportantValue"] as StringBuilder);
        Session["ImportantValue"] = await HelperMethods.Replace_(Session["ImportantValue"] as StringBuilder);
        Session["ImportantValue"] = await HelperMethods._Replace(Session["ImportantValue"] as StringBuilder);
        Session["ImportantValue"] = await HelperMethods.Replace3(Session["ImportantValue"] as StringBuilder);
        Session["ImportantValue"] = await HelperMethods.LineReplace(Session["ImportantValue"] as StringBuilder);
        System.Diagnostics.Debug.WriteLine("Result" + Session["ImportantValue"]);
        //text = Session["ImportantValue"].ToString();

        //Label1.Text = Session["Important"].ToString();
        Label1.Text = Session["ImportantValue"].ToString();
    }
}