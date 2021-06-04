This is an MVC app developed with .NET Framework for learning purposes

## 1 - File Structure
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

## 2 - Fundamentals

### Controller Action Structures

**Action Results**

| Type                  | Helper Method      |
| --------------------- | ------------------ |
| ViewResult            | View()             |
| PartialViewResult     | PartialView()      |
| ContentResult         | Content()          |
| RedirectResult        | Redirect()         |
| RedirectToRouteResult | RedirectToAction() |
| JsonResult            | Json()             |
| FileResult            | File()             |
| HttpNotFoundResult    | HttpNotFound()     |
| EmptyResult           | \-                 |

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

### Parameter Sources

* **Embedded in the URL:** /movies/edit/1 
* In the query string: /movies/edit?id=1
* In the form data

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

### Passing Data to Views

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

### Partial Views

Create View in views as view and select partial view. Usage in another views`@Html.Partial("_PartialView", Model.Data)`

### Section Exercise

<img src="README_assets/sec2ex-1.jpg" alt="ex" style="zoom:67%;" />

<img src="README_assets/sec2ex-2.jpg" alt="ex" style="zoom:67%;" />

<img src="README_assets/sec2ex-3.jpg" alt="ex" style="zoom:67%;" />

<img src="README_assets/sec2ex-4.jpg" alt="ex" style="zoom:67%;" />

## 3 - Working with Data

* **Entity Framework:** an ORM that maps data in a relational database to our objects by using context file.

* **Linq:** Method like SQL queries.

* **Workflows:** Database First, Code First.

* **DB First:** Design database tables first, later let EF generate domain classes according to tables.

* **Code First:** Create domain classes first, later let EF generate database tables for us.

### Code-first migrations

DbSet<Domain Class> to table name in Context : DbContext class in package manager console `PM > enable-migrations` , `PM> add-migration migrationName`, `PM> update-database`

**Seeding db:** put sql commands in a migrations up() method

### Querying Objects

in controller

```csharp
private Context _context;
public CustomersController()
      {
          _context = new Context();
      }
//...
public ActionResult Index()
	{
    var customers = _context.Customers.ToList();
    return View(customers);
	}
//...
public ActionResult Details(int id)
	{
    var customer = _context.Customers.Single(c => c.Id == id);
    return View(customer);
	}		
```

### Eager Loading

**load relational foreign table** : `_context.Customer.Include(c=>c.MembershipType).ToList();` 

### Section Exercise

1. <img src="README_assets/sec3-ex1.jpg" alt="ex" style="zoom:70%;" />
2. <img src="README_assets/sec3-ex2.jpg" alt="ex" style="zoom:70%;" />
   <img src="README_assets/sec3-ex2-2.jpg" alt="ex" style="zoom:70%;" />