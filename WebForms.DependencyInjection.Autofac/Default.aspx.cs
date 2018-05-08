using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.DependencyInjection.Services;

namespace WebForms.DependencyInjection.Autofac
{
    public partial class Default : System.Web.UI.Page
    {
        private readonly IMailService _mailService;

        public Default(IMailService mailService)
        {
            _mailService = mailService;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var to = "test@test.com";
            var body = "<b>Hello World!</b>";
            var result = _mailService.SendMail(to, body);
            this.lblStatus.Text = result;
        }
    }
}