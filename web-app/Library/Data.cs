using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace increment_the_app.Library
{
    public class Data
    {
        public static DataTable JSONToDataTable(string JSON)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            DataTable dt = new DataTable();
            List<Dictionary<string, string>> list = jss.Deserialize<List<Dictionary<string, string>>>(JSON);

            foreach (KeyValuePair<string, string> kvp in list[0])
            {
                dt.Columns.Add(kvp.Key);
            }
            foreach (Dictionary<string, string> dic in list)
            {
                DataRow dr = dt.NewRow();

                foreach (KeyValuePair<string, string> kvp in dic)
                {
                    dr[kvp.Key] = kvp.Value;
                }

                dt.Rows.Add(dr);
            }

            return dt;
        }

        public static string DataTableToJSON(DataTable table)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in table.Rows)
            {
                if (sb.Length != 0)
                {
                    sb.Append(",");
                }

                sb.Append("{");
                StringBuilder sb2 = new StringBuilder();

                foreach (DataColumn col in table.Columns)
                {
                    string fieldname = col.ColumnName;
                    string fieldvalue = dr[fieldname].ToString();
                    if (sb2.Length != 0)
                    {
                        sb2.Append(",");
                    }

                    sb2.Append(string.Format("\"{0}\":\"{1}\"", fieldname, fieldvalue));
                }

                sb.Append(sb2.ToString());
                sb.Append("}");

            }

            sb.Insert(0, "[");
            sb.Append("]");

            return sb.ToString();
        }
        public static XmlDocument DataTableToXmlDocument(DataTable dt)
        {

            XmlDocument xml = new XmlDocument();
            XmlElement root = xml.CreateElement("root");

            if (dt != null)
            {

                xml.AppendChild(root);

                String[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();

                DataRow dr;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        dr = dt.Rows[i];

                        XmlElement child = xml.CreateElement("Node");

                        for (int j = 0; j < columnNames.Length; j++)
                        {
                            child.SetAttribute(columnNames[j], dr[columnNames[j]].ToString());
                        }
                        root.AppendChild(child);
                    }
                }
            }
            return xml;

        }
    }
}