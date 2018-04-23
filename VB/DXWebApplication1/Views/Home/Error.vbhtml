@Using Html.BeginForm()
    @Html.DevExpress().Button(Sub(settings)
                                   settings.Name = "BackButton"
                                   settings.RenderMode = ButtonRenderMode.Link
                                   settings.RouteValues = New With {
                                       Key .Controller = "Home",
                                       Key .Action = "Index"
                                   }
                                   settings.Text = "Back to Example"
                               End Sub).GetHtml()
    @<br />
    @<br />
    @<span>Error log:</span>
    @Html.DevExpress().Memo(Sub(settings)
                                 settings.Name = "Memo"
                                 settings.Height = New Unit(500, UnitType.Pixel)
                                 settings.Width = New Unit(100, UnitType.Percentage)
                             End Sub).Bind(ViewData("Log")).GetHtml()

    @Html.DevExpress().Button(Sub(settings)
                                   settings.Name = "ClearButton"
                                   settings.RenderMode = ButtonRenderMode.Link
                                   settings.Text = "Clear"
                                   settings.UseSubmitBehavior = True
                               End Sub).GetHtml()

End Using