using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIForBloodApp.App_Start;
using WebAPIForBloodApp.Models;

namespace WebAPIForBloodApp.Controllers
{
    [BasicAuthentication]
    public class AuthorizedApiController : ApiController
    {
        public User AuthorizedUser => ((ApiIdentity)HttpContext.Current.User.Identity).User;
    }
}