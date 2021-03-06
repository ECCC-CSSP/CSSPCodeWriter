﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using CSSPModels;
using CSSPEnums;
using CSSPModelsGenerateCodeHelper;
using System.Data.SqlClient;
using System.Data;
using CSSPGenerateCodeBase;
using System.IO;

namespace CSSPWebAPIGenerateCodeHelper
{
    public partial class WebAPICodeWriter
    {
        private void GenerateControllersGetClassWithID(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated for Class Controller GetWithID Command");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void { TypeName }_Controller_Get{ TypeName }WithID_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (LanguageEnum LanguageRequest in AllowableLanguages)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                    { TypeName }Controller { TypeNameLower }Controller = new { TypeName }Controller(DatabaseTypeEnum.SqlServerTestDB);");
            sb.AppendLine($@"                    Assert.IsNotNull({ TypeNameLower }Controller);");
            sb.AppendLine($@"                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, { TypeNameLower }Controller.DatabaseType);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower }First = new { TypeName }();");
            sb.AppendLine(@"                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query(), db, ContactID);");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }First = (from c in db.{ TypeName }es select c).FirstOrDefault();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }First = (from c in db.{ TypeName }s select c).FirstOrDefault();");
            }
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // ok with { TypeName } info");
            sb.AppendLine($@"                    IHttpActionResult jsonRet = { TypeNameLower }Controller.Get{ TypeName }WithID({ TypeNameLower }First.{ TypeName }ID);");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<{ TypeName }> Ret = jsonRet as OkNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower }Ret = Ret.Content;");
            sb.AppendLine($@"                    Assert.AreEqual({ TypeNameLower }First.{ TypeName }ID, { TypeNameLower }Ret.{ TypeName }ID);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.IsNull(badRequest);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    // Not Found");
            sb.AppendLine($@"                    IHttpActionResult jsonRet2 = { TypeNameLower }Controller.Get{ TypeName }WithID(0);");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet2);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<{ TypeName }> { TypeNameLower }Ret2 = jsonRet2 as OkNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    Assert.IsNull({ TypeNameLower }Ret2);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;");
            sb.AppendLine(@"                    Assert.IsNotNull(notFoundRequest);");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Tests Generated for Class Controller GetWithID Command");
            sb.AppendLine(@"");
        }
    }
}
