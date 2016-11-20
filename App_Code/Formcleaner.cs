using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Formcleaner
/// </summary>
public class Formcleaner
{
    public static void ClearForm(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.GetType() == typeof(TextBox))
            {
                ((TextBox)(c)).Text = string.Empty;
            }
            if (c.GetType() == typeof(RadioButtonList))
            {
                ((RadioButtonList)(c)).ClearSelection();
            }
        }
    }
}