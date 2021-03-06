# asp.net lifecycle

demo for asp.net mvc and webapi lifecycle

## lifecyles

- 01 Validate the request potentially malicious markup.
- 02 Perform URL mapping, if any URLs have been configured in the UrlMappingsSection section of the Web.config file.
- 03 BeginRequest event.
- 04 AuthenticateRequest event.
- 05 PostAuthenticateRequest event.
- 06 AuthorizeRequest event.
- 07 PostAuthorizeRequest event.
- 08 ResolveRequestCache event.
- 09 PostResolveRequestCache event.
- 10 MapRequestHandler event. An appropriate handler is selected based on the file-name extension of the requested resource. The handler can be a native-code module such as the IIS 7.0 StaticFileModule or a managed-code module such as the PageHandlerFactory class (which handles .aspx files). 
- 11 PostMapRequestHandler event.
- 12 AcquireRequestState event.
- 13 PostAcquireRequestState event.
- 14 PreRequestHandlerExecute event.
- 15 Call the ProcessRequest method (or the asynchronous version IHttpAsyncHandler.BeginProcessRequest) of the appropriate IHttpHandler class for the request. For example, if the request is for a page, the current page instance handles the request.
- 16 PostRequestHandlerExecute event.
- 17 ReleaseRequestState event.
- 18 PostReleaseRequestState event.
- 19 Perform response filtering if the Filter property is defined.
- 20 UpdateRequestCache event.
- 21 PostUpdateRequestCache event.
- 22 LogRequest event.
- 23 PostLogRequest event.
- 24 EndRequest event.
- 25 PreSendRequestHeaders event.
- 26 PreSendRequestContent event.

## IHttpModule

## IHttpHandler

MvcFramework
WebForms
...

## mvc

- mvc applicaiton lifecycle
- mvc request lifecycle


PreApplicationStart(Register HttpModules, ...)
WebActivatorEx.PreApplicationStart
Application_Start
WebActivatorEx.ApplicationShutdownMethod
Application_End



BeginRequest
AuthenticationRequest
AuthorizeRequest
ResolveRequestCache
PostResolveRequestCache

Request -> 
    URL Routing Module
    MVC RouteHandler
    MVC HttpHandler
        ControllerFactory Activator
        Dependency Resolution
            Action Executing(Filters)
                    Action Execute
                        Action Executed(Filters)
                            Result Executing
                                View Engine
                                    Result Executed
                                        Response
    

## webapi

## miscs

nuget： Update-Package -reinstall

## refs

[ASP.NET HttpApplication lifecycle](https://stackoverflow.com/questions/1394041/asp-net-httpapplication-lifecycle)
[ASP.NET Application Life Cycle Overview for IIS 7.0](https://msdn.microsoft.com/en-us/library/bb470252.aspx)
[ASP.NET Application and Page Life Cycle](https://www.codeproject.com/Articles/73728/ASP-NET-Application-and-Page-Life-Cycle)
[IIS 7.0 的 ASP.NET 应用程序生命周期概述](https://msdn.microsoft.com/zh-cn/library/bb470252(v=vs.100).aspx)