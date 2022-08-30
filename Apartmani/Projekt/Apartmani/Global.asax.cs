using Apartmani.Model;
using Lib.Cryptography;
using Lib.Dal;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;


namespace Apartmani
{
    public class Global : System.Web.HttpApplication
    {
        private readonly IRepository Repo;
        public Global()
        {
            Repo = IRepositoryFactory.GetRepository();
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["database"] = Repo;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}