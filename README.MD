# DOCUMENTATION
This is an MVC app developed with .NET Framework for learning purposes

## File Structure
* App_Start: Configuration Files. Loads at application start
* Content: CSS,images, client side assets
* Controllers: Operations for handling requests
* Models: Domain classes
* Scripts: JS files
* Views: Corresponding views for controller actions
* favicon: Website icon
* Global.asax: Hooks for various events and application lifecycle
* packages.config: Nuget package dependencies list
* Startup.cs: New approach for startup configurations and logic (Net Core and beyond)
* Web.config: Configuration for application like DB connection strings,app settings for defining configuration settings

## Fundamentals

### Controller Action Structures

**Action Results**

<table>
    <tr>
    	<th>Type</th>
    	<th>Helper Method</th>
    </tr>
    <tr>
		<td>ViewResult</td>
        <td>View()</td>
    </tr>
    <tr>
		<td>PartialViewResult</td>
        <td>PartialView()</td>
    </tr>
    <tr>
		<td>ContentResult</td>
        <td>Content()</td>
    </tr>
    <tr>
		<td>RedirectResult</td>
        <td>Redirect()</td>
    </tr>
        <tr>
		<td>RedirectToRouteResult</td>
        <td>RedirectToAction()</td>
    </tr>
        <tr>
		<td>JsonResult</td>
        <td>Json()</td>
    </tr>
        <tr>
		<td>FileResult</td>
        <td>File()</td>
    </tr>
        <tr>
		<td>HttpNotFoundResult</td>
        <td>HttpNotFound()</td>
    </tr>
            <tr>
		<td>EmptyResult</td>
        <td>-</td>
    </tr>
some examples

```csharp
public ActionResult Test()
	{
		return View(data);
		return Content("Hello World!");
		return HttpNotFound();
		return new EmptyResult();
		return RedirectToAction("Index", "Home", new {page="1",sortBy="name"});
    }		
```

### Routing

- **Convention based routing:** in Routeconfig.cs

- ```c#
  routes.MapRoute(
             "MoviesByReleaseDate", //name of route
            "movies/released/{year}/{month}", //route url
            new{controller="Movies",action="ByReleaseDate"}, //default corresponding controller and actions
            new{year=@"2020|2021",month=@"\d{2}"}); //constraints for parameters
  ```

- **Attribute routing**: in Routeconfig.cs add `routes.MapMvcAttributeRoutes();` Before controller use attribute `[Route("url template")]`. *Also constraints like min, max, minlength, maxlength, int, float, guid could be used.*

- ```csharp
  [Route("movies/released/{year:regex(\\d{4}:range(1800,2021))}/{month:regex(\\d{2}:range(1,12))}")]
  public ActionResult ByReleaseDate(int year,int month)
    {
        return Content(year + "/" + month);
    }
  ```

### Passing Data to View

* in controller

```c#
public ActionResult Test()
	{
    var movie = new Movie() { Name = "Shrek!" };
	
    ViewData["Movie"] = movie;
    ViewBag.Movie = movie;
    
    return View(movie);
}
```

* in view

```html
<h2>@Model.Name</h2> <!-- preffered way -->
<h2>@( ((Movie) ViewData["Movie"]).Name)</h2> <!-- ugly way / dont use -->
<h2>@ViewBag.Movie.Name</h2> <!-- casted at runtime / not safe -->
```

* **ViewModels**: consists multiple models. 
* in ViewModel folder

```csharp
public class RandomMovieViewModel
{
    public Movie Movie { get; set; }
    public List<Customer> Customers { get; set; }
}
```

* in controller

```cs
public class MoviesController : Controller
{
    // GET: Movies
    public ActionResult Random()
    {
        //adding data
        var movie = new Movie() { Name = "Shrek!" };
        
        var customers = new List<Customer>
        {
            new Customer {Name = "cust1"},
            new Customer {Name = "cust2"}
        };
 		//filing viewmodel with data
        var viewModel = new RandomMovieViewModel()
        {
            Movie = movie, 
            Customers = customers
        };

        return View(viewModel);
    }
```

### Razor Syntax 

```cs
@*
    this is a razor comment
*@
@{
    //multiple lines
    //when razor sees html prints it and when razor sees csharp interprets it
}
@{
    var className = Model.Customers.Count > 0 ? "popular" : null;
}
 
<h2 class="@className">@Model.Movie.Name</h2>  <!-- preferred way -->
@if (Model.Customers.Count == 0)
{
    <p>No one has rented this movie before.</p>
}
 
<ul>
@foreach (var customer in Model.Customers)
   {
       <li>@customer.Name</li>
   }
</ul>
```