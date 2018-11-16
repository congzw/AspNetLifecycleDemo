# asp.net lifecycle

demo for asp.net mvc and webapi lifecycle

## lifecyles

01 Validate the request potentially malicious markup.
02 Perform URL mapping, if any URLs have been configured in the UrlMappingsSection section of the Web.config file.
03 Raise the BeginRequest event.
04 Raise the AuthenticateRequest event.
05 Raise the PostAuthenticateRequest event.
06 Raise the AuthorizeRequest event.
07 Raise the PostAuthorizeRequest event.
08 Raise the ResolveRequestCache event.
09 Raise the PostResolveRequestCache event.
10 Raise the MapRequestHandler event. An appropriate handler is selected based on the file-name extension of the requested resource. The handler can be a native-code module such as the IIS 7.0 StaticFileModule or a managed-code module such as the PageHandlerFactory class (which handles .aspx files). 
11 Raise the PostMapRequestHandler event.
12 Raise the AcquireRequestState event.
13 Raise the PostAcquireRequestState event.
14 Raise the PreRequestHandlerExecute event.
15 Call the ProcessRequest method (or the asynchronous version IHttpAsyncHandler.BeginProcessRequest) of the appropriate IHttpHandler class for the request. For example, if the request is for a page, the current page instance handles the request.
16 Raise the PostRequestHandlerExecute event.
17 Raise the ReleaseRequestState event.
18 Raise the PostReleaseRequestState event.
19 Perform response filtering if the Filter property is defined.
20 Raise the UpdateRequestCache event.
21 Raise the PostUpdateRequestCache event.
22 Raise the LogRequest event.
23 Raise the PostLogRequest event.
24 Raise the EndRequest event.
25 Raise the PreSendRequestHeaders event.
26 Raise the PreSendRequestContent event.

## IHttpModule

## mvc

## webapi

## miscs

nuget： Update-Package -reinstall

## refs

[ASP.NET HttpApplication lifecycle](https://stackoverflow.com/questions/1394041/asp-net-httpapplication-lifecycle)
[ASP.NET Application Life Cycle Overview for IIS 7.0](https://msdn.microsoft.com/en-us/library/bb470252.aspx)
[ASP.NET Application and Page Life Cycle](https://www.codeproject.com/Articles/73728/ASP-NET-Application-and-Page-Life-Cycle)
[IIS 7.0 的 ASP.NET 应用程序生命周期概述](https://msdn.microsoft.com/zh-cn/library/bb470252(v=vs.100).aspx)