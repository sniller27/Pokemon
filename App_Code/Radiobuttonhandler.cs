using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Radiobuttonhandler
/// </summary>
public class Radiobuttonhandler
{
    //this class is responsible for handling radiobuttons... but problems with typecasting

    public Radiobuttonhandler()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string GetCheckedRadio(RadioButton radiomalepara, RadioButton radiofemalepara, HiddenField hiddenmalepara, HiddenField hiddenfemalepara)
    {
        if (radiomalepara.Checked == true)
        {
            return hiddenmalepara.Value;
        }
        else if (radiofemalepara.Checked == true)
        {
            return hiddenfemalepara.Value;
        }
        else
        {
            return hiddenmalepara.Value;
        }
    }

    public static void SetCheckedRadio(RadioButton radiomalepara, RadioButton radiofemalepara, HiddenField hiddenmalepara, HiddenField hiddenfemalepara, string radiopara)
    {
        if (hiddenmalepara.Value == radiopara)
        {
            radiomalepara.Checked = true;
        }
        else if (hiddenfemalepara.Value == radiopara)
        {
            radiofemalepara.Checked = true;
        }
        else
        {
            radiomalepara.Checked = true;
        }
    }
}