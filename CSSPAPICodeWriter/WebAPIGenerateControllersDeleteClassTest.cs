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
        private void GenerateControllersDeleteClass(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated for Class Controller Delete Command");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void { TypeName }_Controller_Delete_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (LanguageEnum LanguageRequest in AllowableLanguages)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                    { TypeName }Controller { TypeNameLower }Controller = new { TypeName }Controller(DatabaseTypeEnum.SqlServerTestDB);");
            sb.AppendLine($@"                    Assert.IsNotNull({ TypeNameLower }Controller);");
            sb.AppendLine($@"                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, { TypeNameLower }Controller.DatabaseType);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower }Last = new { TypeName }();");
            sb.AppendLine(@"                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))");
            sb.AppendLine(@"                    {");
            sb.AppendLine(@"                        Query query = new Query();");
            sb.AppendLine(@"                        query.Language = LanguageRequest;");
            sb.AppendLine(@"                        query.Asc = """";");
            sb.AppendLine(@"                        query.Desc = """";");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(query, db, ContactID);");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }Last = (from c in db.{ TypeName }es select c).FirstOrDefault();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }Last = (from c in db.{ TypeName }s select c).FirstOrDefault();");
            }
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // ok with { TypeName } info");
            sb.AppendLine($@"                    IHttpActionResult jsonRet = { TypeNameLower }Controller.Get{ TypeName }WithID({ TypeNameLower }Last.{ TypeName }ID);");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<{ TypeName }> Ret = jsonRet as OkNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower }Ret = Ret.Content;");
            sb.AppendLine($@"                    Assert.AreEqual({ TypeNameLower }Last.{ TypeName }ID, { TypeNameLower }Ret.{ TypeName }ID);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.IsNull(badRequest);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // Post to return newly added { TypeName }");
            sb.AppendLine($@"                    { TypeNameLower }Ret.{ TypeName }ID = 0;");
            if (TypeName == "MWQMLookupMPN")
            {
                sb.AppendLine($@"                    { TypeNameLower }Ret.Tubes01 = 1;");
                sb.AppendLine($@"                    { TypeNameLower }Ret.Tubes1 = 1;");
                sb.AppendLine($@"                    { TypeNameLower }Ret.Tubes10 = 1;");
                sb.AppendLine($@"                    { TypeNameLower }Ret.MPN_100ml = 6;");
            }
            if (TypeName == "SamplingPlan")
            {
                sb.AppendLine($@"                    { TypeNameLower }Ret.SamplingPlanName = { TypeNameLower }Ret.SamplingPlanName.Replace("".txt"", ""_a.txt"");");
            }
            if (TypeName == "TVItem")
            {
                sb.AppendLine($@"                    { TypeNameLower }Ret.TVLevel = 1;");
                sb.AppendLine($@"                    { TypeNameLower }Ret.TVType = TVTypeEnum.Contact;");
            }
            sb.AppendLine($@"                    { TypeNameLower }Controller.Request = new System.Net.Http.HttpRequestMessage();");
            sb.AppendLine($@"                    { TypeNameLower }Controller.Request.RequestUri = new System.Uri(""http://localhost:5000/api/{ TypeNameLower }"");");
            sb.AppendLine($@"                    IHttpActionResult jsonRet3 = { TypeNameLower }Controller.Post({ TypeNameLower }Ret, LanguageRequest.ToString());");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet3);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    CreatedNegotiatedContentResult<{ TypeName }> { TypeNameLower }Ret3 = jsonRet3 as CreatedNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    Assert.IsNotNull({ TypeNameLower }Ret3);");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower } = { TypeNameLower }Ret3.Content;");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.IsNull(badRequest3);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // Delete to return success");
            sb.AppendLine($@"                    IHttpActionResult jsonRet2 = { TypeNameLower }Controller.Delete({ TypeNameLower }Ret, LanguageRequest.ToString());");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet2);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<{ TypeName }> { TypeNameLower }Ret2 = jsonRet2 as OkNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    Assert.IsNotNull({ TypeNameLower }Ret2);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.IsNull(badRequest2);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // Delete to return CSSPError because { TypeName }ID of 0 does not exist");
            sb.AppendLine($@"                    { TypeNameLower }Ret.{ TypeName }ID = 0;");
            sb.AppendLine($@"                    IHttpActionResult jsonRet4 = { TypeNameLower }Controller.Delete({ TypeNameLower }Ret, LanguageRequest.ToString());");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet4);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<{ TypeName }> { TypeNameLower }Ret4 = jsonRet4 as OkNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    Assert.IsNull({ TypeNameLower }Ret4);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.IsNotNull(badRequest4);");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Tests Generated for Class Controller Delete Command");
            sb.AppendLine(@"");
        }
    }
}
