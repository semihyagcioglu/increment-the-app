using increment_the_app.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace increment_the_app
{
    /// <summary>
    /// Summary description for WsTasks
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WsTasks : System.Web.Services.WebService
    {

        [WebMethod]
        public string SearchTask(string searchTask)
        {
            return Tasks.SearchTask(searchTask);
        }

    }
}
