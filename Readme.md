<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128566621/14.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4588)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# ASP.NET MVC - How to handle application-level errors occurred during callbacks

Use the static [ASPxWebControl.CallbackError](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxWebControl.CallbackError) event to handle callback exceptions thrown by DevExpress MCV extensions server side. Delegate callback exception handling to the `Application_Error` event handler.

```cs
protected void Application_Start() {
    ASPxWebControl.CallbackError += Application_Error;
}
```

```vb
Protected Sub Application_Start()
	AddHandler ASPxWebControl.CallbackError, AddressOf Application_Error
End Sub
```

The `Application_Error` event handler catches all unhandled ASP.NET errors while processing a request. You can use the [GetLastError](https://learn.microsoft.com/en-us/dotnet/api/system.web.httpserverutility.getlasterror) method to get and log the details of the last exception.

```cs
protected void Application_Error(object sender, EventArgs e) {
    Exception exception = HttpContext.Current.Server.GetLastError();
    if (exception is HttpUnhandledException)
        exception = exception.InnerException;
    AddToLog(exception.Message, exception.StackTrace);
}
```

```vb
Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
    Dim exception As Exception = HttpContext.Current.Server.GetLastError()
    If TypeOf exception Is HttpUnhandledException Then
        exception = exception.InnerException
    End If
    AddToLog(exception.Message, exception.StackTrace)
End Sub
```

When a callback exception occurs, you can redirect the application to another web resource. Use the [callbackErrorRedirectUrl](https://docs.devexpress.com/AspNet/6914/common-concepts/webconfig-modifications/webconfig-options/redirection-on-a-callback-error) configuration option to specify the redirection location.

```xml
<configuration>
    <devExpress>
        <errors callbackErrorRedirectUrl="/Home/Error" />
    </devExpress>
</configuration>
```

If the `customErrors.mode` option is set to `On`, add a custom error filter into **FilterConfig** to handle controller exceptions. 

```cs
public class FilterConfig {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
        filters.Add(new HandleErrorAttributeEx());
    }

    public class HandleErrorAttributeEx : HandleErrorAttribute {
        public HandleErrorAttributeEx() : base() { }
        public override void OnException(ExceptionContext filterContext) {
            base.OnException(filterContext);
            filterContext.ExceptionHandled = false;
        }
    }
}

```

```vb
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
```

## Files to Review

* [Global.asax.cs](./CS/DXWebApplication1/Global.asax.cs) (VB: [Global.asax.vb](./VB/DXWebApplication1/Global.asax.vb))
* [FilterConfig.cs](./CS/DXWebApplication1/App_Start/FilterConfig.cs) (VB: [FilterConfig.vb](./VB/DXWebApplication1/App_Start/FilterConfig.vb))
* [HomeController.cs](./CS/DXWebApplication1/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/DXWebApplication1/Controllers/HomeController.vb))
* [Web.config](./CS/DXWebApplication1/Web.config) (VB: [Web.config](./VB/DXWebApplication1/Web.config))

## Documentation 

* [Callbacks](https://docs.devexpress.com/AspNet/402559/common-concepts/callbacks)
* [Callback Exception Handling](https://docs.devexpress.com/AspNetMvc/402269/common-features/callback-based-functionality/callback-exception-handling)

## More Examples 

* [ASP.NET Web Forms - How to handle application-level errors occurred during callbacks](https://github.com/DevExpress-Examples/asp-net-web-forms-handle-app-level-errors-occurred-during-callbacks)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-mvc-handle-app-level-errors-occurred-during-callbacks&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-mvc-handle-app-level-errors-occurred-during-callbacks&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
