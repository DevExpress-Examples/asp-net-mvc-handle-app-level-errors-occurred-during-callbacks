Imports System
Imports System.Web
Imports System.Web.Mvc

Namespace DXWebApplication1.Controllers
    Public Class HomeController
        Inherits Controller

        Public Function Index() As ActionResult
            Return View()
        End Function

        Public Function [Error]() As ActionResult
            If HttpContext.Application("Log") IsNot Nothing Then
                ViewData("Log") = HttpContext.Application("Log").ToString()
            End If
            Return View()
        End Function
        <HttpPost>
        Public Function [Error](ByVal model As Object) As ActionResult
            HttpContext.Application("Log") = ""
            Return View()
        End Function
        Public Function CallbackPanelPartial(ByVal ThrowExceptionOnCallback? As Boolean) As ActionResult
            'throw new Exception("This Exception is thrown in the controller action");
            If ThrowExceptionOnCallback.HasValue Then
                ViewData("ThrowExceptionOnCallback") = ThrowExceptionOnCallback.Value
            End If
            Return PartialView()
        End Function
    End Class
End Namespace