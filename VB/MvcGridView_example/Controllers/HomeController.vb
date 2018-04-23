Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Data
Imports DevExpress.Web.Mvc
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxClasses

Namespace MvcGridView_example.Controllers
	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult
			Return View()
		End Function

		Public Function [Error]() As ActionResult
			ViewData("Log") = HttpContext.Application("Log")

			Return View("Error")
		End Function

		Public Function CallbackPanelPartial() As ActionResult
			Dim innerException As New Exception("No Report")
			Throw New Exception("This exception is thrown to demonstrate an <b>ASPxWebControl.CallbackError</b> event handler.", innerException)
		End Function
	End Class
End Namespace
