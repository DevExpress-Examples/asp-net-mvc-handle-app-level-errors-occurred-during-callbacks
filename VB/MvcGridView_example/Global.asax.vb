Imports System
Imports System.Text
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing
Imports DevExpress.Web.ASPxClasses

Namespace MvcGridView_example

    ' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    ' visit http://go.microsoft.com/?LinkId=9394801
    Public Class MvcApplication
        Inherits HttpApplication

        Public Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
            filters.Add(New HandleErrorAttribute())
        End Sub

        Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
            routes.MapRoute("Default", "{controller}/{action}/{id}", New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional}) ' Route name
        ' URL with parameters
        ' Parameter defaults
        End Sub

        Protected Sub Application_Start()
            Call AreaRegistration.RegisterAllAreas()
            RegisterGlobalFilters(GlobalFilters.Filters)
            RegisterRoutes(RouteTable.Routes)
            AddHandler ASPxWebControl.CallbackError, New EventHandler(AddressOf Application_Error)
        End Sub

        Private Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
            Dim server As HttpServerUtility = HttpContext.Current.Server
            Dim exception As Exception = server.GetLastError()
            AddToLog(exception.Message, exception.StackTrace)
        End Sub

        Private Sub AddToLog(ByVal message As String, ByVal stackTrace As String)
            Dim sb As StringBuilder = New StringBuilder()
            sb.AppendLine(Date.Now.ToLocalTime().ToString())
            sb.AppendLine(message)
            sb.AppendLine()
            sb.AppendLine("Source File: " & HttpContext.Current.Request.RawUrl)
            sb.AppendLine()
            sb.AppendLine("Stack Trace: ")
            sb.AppendLine(stackTrace)
            For i As Integer = 0 To 150 - 1
                sb.Append("-")
            Next

            sb.AppendLine()
            Application("Log") += sb.ToString()
            sb.AppendLine()
        End Sub
    End Class
End Namespace
