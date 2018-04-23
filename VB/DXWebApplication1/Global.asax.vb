Imports System
Imports System.Text
Imports System.Web
Imports System.Web.Http
Imports System.Web.Mvc
Imports System.Web.Routing
Imports DevExpress.Web

Namespace DXWebApplication1
    ' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    ' visit http://go.microsoft.com/?LinkId=9394801

    Public Class MvcApplication
        Inherits System.Web.HttpApplication

        Protected Sub Application_Start()
            AreaRegistration.RegisterAllAreas()

            WebApiConfig.Register(GlobalConfiguration.Configuration)
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
            RouteConfig.RegisterRoutes(RouteTable.Routes)

            ModelBinders.Binders.DefaultBinder = New DevExpress.Web.Mvc.DevExpressEditorsBinder()

            AddHandler ASPxWebControl.CallbackError, AddressOf Application_Error
        End Sub

        Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
            Dim exception As Exception = HttpContext.Current.Server.GetLastError()
            If TypeOf exception Is HttpUnhandledException Then
                exception = exception.InnerException
            End If
            AddToLog(exception.Message, exception.StackTrace)
        End Sub

        Public Shared Sub AddToLog(ByVal message As String, ByVal stackTrace As String)
            Dim sb As New StringBuilder()
            sb.AppendLine(Date.Now.ToLocalTime().ToString())
            sb.AppendLine(message)
            sb.AppendLine()
            sb.AppendLine("Source File: " & HttpContext.Current.Request.RawUrl)
            sb.AppendLine()
            sb.AppendLine("Stack Trace: ")
            sb.AppendLine(stackTrace)
            For i As Integer = 0 To 149
                sb.Append("-")
            Next i
            sb.AppendLine()
            HttpContext.Current.Application("Log") += sb.ToString()
            sb.AppendLine()
        End Sub
    End Class
End Namespace