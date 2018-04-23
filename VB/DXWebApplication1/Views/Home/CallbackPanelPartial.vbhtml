@Html.DevExpress().CallbackPanel(Sub(settings)
	settings.Name = "CallbackPanel"
	settings.CallbackRouteValues = New With {
		Key .Controller = "Home",
		Key .Action = "CallbackPanelPartial"
	}
	settings.SetContent(Sub()
		If ViewData("ThrowExceptionOnCallback") IsNot Nothing Then
			Dim innerException As New Exception("NoReport")
			Throw New Exception("This Exception is thrown to demonstrate the ASPxWebControl.CallbackError Event.", innerException)
		End If
	End Sub)
End Sub).GetHtml()