using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace increment_the_app.Library
{
    public class UI
    {
        // This function binds the given DropDownList with the given data table with respect to the data text field and the value field.
        public static void Bind2Ddl(ListControl ddl, DataTable dt, string textField, string valueField)
        {
            ddl.DataSource = dt;
            ddl.DataTextField = textField;
            ddl.DataValueField = valueField;
            ddl.DataBind();
        }

        // This function binds the given CheckBoxList with the given data table with respect to the data text field and the value field.
        public static void Bind2CheckBoxList(ListControl chk, DataTable dt, string textField, string valueField)
        {
            chk.DataSource = dt;
            chk.DataTextField = textField;
            chk.DataValueField = valueField;
            chk.DataBind();
        }

        // This function binds the given RadioButtonList with the given data table with respect to the data text field and the value field.
        public static void Bind2RadioButtonList(ListControl rbl, DataTable dt, string textField, string valueField)
        {
            rbl.DataSource = dt;
            rbl.DataTextField = textField;
            rbl.DataValueField = valueField;
            rbl.DataBind();
        }

        // This function binds the given GirdView with the given data table.
        public static void Bind2Gridview(BaseDataBoundControl gdv, DataTable dt)
        {
            gdv.DataSource = dt;
            gdv.DataBind();
        }

        // This function binds the given ListView with the given data table.
        public static void Bind2DetailsView(BaseDataBoundControl dv, DataTable dt)
        {
            dv.DataSource = dt;
            dv.DataBind();
        }

        // Gets a checkboxlist or a radiobutton list etc. and returns the values of the selected items.
        public static ArrayList GetSelectedValuesFromAListControl(ListControl list)
        {
            ArrayList arlSelected = new ArrayList();

            for (int i = 0; i < list.Items.Count; i++)
            {
                if (list.Items[i].Selected)
                {
                    arlSelected.Add(list.Items[i].Value);
                }
            }

            return arlSelected;
        }

        public static void ResetFormControlValues(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    ResetFormControlValues(c);
                }
                else
                {
                    switch (c.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.TextBox":
                            ((TextBox)c).Text = string.Empty;
                            break;
                        case "System.Web.UI.WebControls.CheckBox":
                            ((CheckBox)c).Checked = false;
                            break;
                        case "System.Web.UI.WebControls.RadioButton":
                            ((RadioButton)c).Checked = false;
                            break;

                    }
                }
            }
        }

    }
}