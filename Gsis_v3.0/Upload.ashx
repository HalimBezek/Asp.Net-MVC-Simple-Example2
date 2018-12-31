﻿<%@ WebHandler Language="C#" Class="Upload" %>
using System;
using System.Web;
using Gsis.Controllers;
public class Upload : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        HttpPostedFile uploads = context.Request.Files["upload"];
        
        string CKEditorFuncNum = context.Request["CKEditorFuncNum"];
        string file = System.IO.Path.GetFileName(uploads.FileName);
        uploads.SaveAs(HttpContext.Current.Server.MapPath("~") + "Content\\img\\" + file);// path of folder where images are upload
        
        
        string url =  "/Content/img/" + file; // path of folder where images are upload
        
        context.Response.Write("<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\");</script>");
        context.Response.End();
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}