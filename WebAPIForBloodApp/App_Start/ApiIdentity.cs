using System;
using System.Security.Principal;
using WebAPIForBloodApp.Models;

namespace WebAPIForBloodApp.App_Start
{
    internal class ApiIdentity : IIdentity
    {
        public User User
        {
            get;
            private set;
        }

        public ApiIdentity(User user)
        {
            this.User = user ?? throw new ArgumentNullException("user");
        }

        public string Name => this.User.Email;

        public string AuthenticationType => "Basic";

        public bool IsAuthenticated => true;
    }
}