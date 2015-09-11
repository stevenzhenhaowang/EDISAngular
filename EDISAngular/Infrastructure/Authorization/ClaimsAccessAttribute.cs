﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;


namespace EDISAngular.Infrastructure.Authorization
{
    public class ClaimsAccessFilterAttribute : AuthorizeAttribute
    {
        public string Issuer { get; set; }//name of the authorization provider
        public string ClaimType { get; set; }
        public string Value { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.User.Identity.IsAuthenticated
                && httpContext.User.Identity is ClaimsIdentity
                && ((ClaimsIdentity)httpContext.User.Identity).HasClaim(x => x.Issuer == Issuer && x.Type == ClaimType
            && x.Value == Value) && base.AuthorizeCore(httpContext);
        }

    }
}