Imports DXWebApplication1.Controllers
Imports System.Web
Imports System.Web.Mvc

Namespace DXWebApplication1
    Public Class FilterConfig
        Public Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
            filters.Add(New HandleErrorAttributeEx())
        End Sub

        Public Class HandleErrorAttributeEx
            Inherits HandleErrorAttribute

            Public Sub New()
                MyBase.New()
            End Sub
            Public Overrides Sub OnException(ByVal filterContext As ExceptionContext)
                MyBase.OnException(filterContext)
                filterContext.ExceptionHandled = False
            End Sub
        End Class
    End Class
End Namespace