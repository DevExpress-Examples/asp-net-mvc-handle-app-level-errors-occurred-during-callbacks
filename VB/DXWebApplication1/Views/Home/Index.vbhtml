@Html.Partial("CallbackPanelPartial")

@Html.DevExpress().Button(Sub(btnSettings)
    btnSettings.Name = "Button"
    btnSettings.Text = "Throw Exception on Callback"
    btnSettings.ClientSideEvents.Click = "function(s, e) { CallbackPanel.PerformCallback({ThrowExceptionOnCallback: true}); }"
End Sub).GetHtml()
