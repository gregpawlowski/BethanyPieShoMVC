# Startup Class
In startup you configure service and define the request/response pipeline middleware.
Two methods will be invoked automatically by ASP.net.

ConfigureServices and Configure

Configure services is where you configure the dependency injection.

# Dependency Injection
Removes tight coupling, instead of initializing classes in classes they are passed in the constructor. But dependency injection will create the instance to be passed in. You can select the lifetime of the service and the DI container will be in charge of creatinging and disposing of classes.

# Routing In MVC
Requests are handled by action methods on controller.

MVC maps request to correct action and controller.


MVC maps URLI to an endpoint, this is configured in the middleware.

```C#
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
```

There are two types of routing:
Convention and Attribute Based (mostly used for APIs).

Convention based rotes
http://localhost/pie/list

Will look for PieController and List method.

For more segments:
http://localhost/pie/details/1

the 1 will be passed in the parameter to the method by default.

## Navigation with tag helpers
You can create links in views using tag helpers such as asp-page. The routing system will generate the link HTML.

```C#
<a asp-controller="pie" asp-action="list">View Pie List</a>
```
Tag helpers are server side code, code will be executed before a response is returned.

## Registering Tag helpers.
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers

This would have to be added to every page or into the ViewImports.cshtml so that it's imported in all the views.

asp-route-* - name of parameter, to pass id.
asp-route


# Sessions
Sessions can be used as a feature of MVC. Can be used if you don't have a user account yet. Can store data to server while the user browser the site.
Sessions are stored using a cookie.

Adding support for sessions:

// Gives access to http context
services.AddHttpContextAccessor();
services.AddSessions();

//in Middleware:
app.UseSessions();

# View Components 
Unlike partial views that need data bassed in, view components will load their own data. Only used for displayin partial compnent. Has a class and a View.
Supports dependency injection, always linked  to a view but can execute it's own code.

Examples:
Login Panel
Dynamic Navigation that checks if user is logged in.
Shopping Cart - displays items in basket

```C#
public class ShoppingCartSummary : View Component
{
    public IViewComonentResult Invoke()
    {
        return View(model);
    }
}
```

It doesn't need to return a view, it could return a string even. 
Typically the view is placed inside Shared => Components => NameOfComponent
And the view will be in called default.cshtml.


To invoke the view from a view:
```C#
@await Component.InvokeAsync();
```

# Custom Tag Helpers
Tag helpers enable server-side C# code to participate in creating and rendering HTML elements for Razor files.

```C#
public class EmailTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        ...
    }
}
```

<email
    address="info@whatever.com"
    content="Contact Us"/>
</email>

Now the tag Helper has to be registered in the Viewimports
@addTagHelper BethanysPieShop.TagHelpers.**


# Model Binding
.NET core MVC can bind data coming in from the request into the parameters required by the controller. This is called model binding.

Various searches will be check including query, body and route parameters.

Complex types can be used as well.

# Validation Attributes
Required
StringLength
Range - numbers
RegularExpression
DataType
- PHone
- Email
- Url

Error messages can be dipalyed by proving a tag helper
asp-validation-summary="All"

# Packages for Identity
Microsoft.AspNetCore.Identity.UI
Microsoft.AspNetCore.Identity.EntityFrameworkCore