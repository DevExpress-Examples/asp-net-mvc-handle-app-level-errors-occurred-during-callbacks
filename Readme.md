<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128566621/14.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4588)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [FilterConfig.cs](./CS/DXWebApplication1/App_Start/FilterConfig.cs) (VB: [FilterConfig.vb](./VB/DXWebApplication1/App_Start/FilterConfig.vb))
* [RouteConfig.cs](./CS/DXWebApplication1/App_Start/RouteConfig.cs) (VB: [RouteConfig.vb](./VB/DXWebApplication1/App_Start/RouteConfig.vb))
* [WebApiConfig.cs](./CS/DXWebApplication1/App_Start/WebApiConfig.cs) (VB: [WebApiConfig.vb](./VB/DXWebApplication1/App_Start/WebApiConfig.vb))
* [HomeController.cs](./CS/DXWebApplication1/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/DXWebApplication1/Controllers/HomeController.vb))
* [Global.asax](./CS/DXWebApplication1/Global.asax) (VB: [Global.asax](./VB/DXWebApplication1/Global.asax))
* [Global.asax.cs](./CS/DXWebApplication1/Global.asax.cs) (VB: [Global.asax.vb](./VB/DXWebApplication1/Global.asax.vb))
<!-- default file list end -->
# How to handle app level errors occurred inside ASP.NET MVC controls during callbacks


<p>This example is an MVC version of the <a href="https://www.devexpress.com/Support/Center/p/E2398">How to use the ASPxWebControl.CallbackError event to handle application-level errors occurred inside ASPxWebControls during callback processing</a> WebForms solution.<br><br></p>
<p>It illustrates how to catch and handle

* Exceptions that occur inside DevExpress ASP.NET MVC extensions during a callback using the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxWebControl_CallbackErrortopic">ASPxWebControl.CallbackError</a> event;
* The remaining unhandled exceptions using the <a href="http://msdn.microsoft.com/en-us/library/24395wz3(v=vs.100).aspx">Application_Error</a> event in the Global.asax file.<br>It also shows how to write required information to the same log/storage (for further diagnostics, etc).</p>
<p><br>Global.asax:<br><br></p>


```cs
protected void Application_Start() {
    ASPxWebControl.CallbackError += Application_Error;
}
```


<p> </p>


```vb
Protected Sub Application_Start()
	AddHandler ASPxWebControl.CallbackError, AddressOf Application_Error
End Sub
```


<p> </p>


```cs
protected void Application_Error(object sender, EventArgs e) {
    Exception exception = HttpContext.Current.Server.GetLastError();
    if (exception is HttpUnhandledException)
        exception = exception.InnerException;
    AddToLog(exception.Message, exception.StackTrace);
}
```


<p> </p>


```vb
Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
    Dim exception As Exception = HttpContext.Current.Server.GetLastError()
    If TypeOf exception Is HttpUnhandledException Then
        exception = exception.InnerException
    End If
    AddToLog(exception.Message, exception.StackTrace)
End Sub
```


<p><br><br>The only difference is the format of the <a href="https://documentation.devexpress.com/#AspNet/CustomDocument6914">callbackErrorRedirectUrl</a> configuration option. It should be set according to the routing configuration:<br><br>Web.config:<br><br></p>


```xml
<configuration>
    <devExpress>
        <errors callbackErrorRedirectUrl="/Home/Error" />
    </devExpress>
</configuration>
```


<p> </p>
<p>Note that this approach won't catch exceptions thrown in a controller action when <strong>customErrors.mode</strong> is <strong>On</strong>. To handle controller exceptions in this case, add a custom error filter into FilterConfig:</p>


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


<p>This will make action errors raise the Application_Error event.</p>
<p><br><strong>WebForms Version:</strong><br><a href="https://www.devexpress.com/Support/Center/p/E2398">How to use the ASPxWebControl.CallbackError event to handle application-level errors occurred inside ASPxWebControls during callback processing</a></p>

<br/>


