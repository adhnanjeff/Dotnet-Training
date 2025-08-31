Directory structure: └── EcommercePro/ ├── EcommercePro.sln ├──
Ecommerce.API/ │ ├── appsettings.Development.json │ ├── appsettings.json
│ ├── Ecommerce.API.csproj │ ├── Ecommerce.API.http │ ├── Program.cs │
├── WeatherForecast.cs │ ├── Controllers/ │ │ ├── OrderController.cs │ │
├── OrderItemController.cs │ │ ├── ProductController.cs │ │ ├──
UserController.cs │ │ └── WeatherForecastController.cs │ ├── Extensions/
│ │ └── ExceptionMiddlewareExtensions.cs │ ├── Middleware/ │ │ └──
GlobalExceptionMiddleware.cs │ └── Properties/ │ └── launchSettings.json
├── Ecommerce.Application/ │ ├── Class1.cs │ ├──
Ecommerce.Application.csproj │ ├── Mapping/ │ │ └── MappingProfile.cs │
└── Services/ │ ├── OrderItemService.cs │ ├── OrderService.cs │ ├──
ProductService.cs │ └── UserService.cs ├── Ecommerce.Core/ │ ├──
Class1.cs │ ├── Ecommerce.Core.csproj │ ├── DTOs/ │ │ ├──
ErrorResponseDTO.cs │ │ ├── OrderItemRequestDTO.cs │ │ ├──
OrderItemResponseDTO.cs │ │ ├── OrderRequestDTO.cs │ │ ├──
OrderResponseDTO.cs │ │ ├── OrderSummaryDTO.cs │ │ ├──
ProductRequestDTO.cs │ │ ├── ProductResponseDTO.cs │ │ ├──
ProductSummaryDTO.cs │ │ ├── UserRequestDTO.cs │ │ └──
UserResponseDTO.cs │ ├── Entities/ │ │ ├── Order.cs │ │ ├── OrderItem.cs
│ │ ├── Product.cs │ │ └── User.cs │ ├── Exceptions/ │ │ ├──
ConflictException.cs │ │ ├── ForbiddenException.cs │ │ ├──
NotFoundException.cs │ │ ├── UnauthorizedException.cs │ │ └──
ValidationException.cs │ └── Interfaces/ │ ├── IOrderItemRepository.cs │
├── IOrderItemService.cs │ ├── IOrderRepository.cs │ ├──
IOrderService.cs │ ├── IProductRepository.cs │ ├── IProductService.cs │
├── IRepository.cs │ ├── IUserRepository.cs │ └── IUserService.cs ├──
Ecommerce.Infrastructure/ │ ├── Class1.cs │ ├──
Ecommerce.Infrastructure.csproj │ ├── Data/ │ │ └── AppDbContext.cs │
└── Repositories/ │ ├── OrderItemRepository.cs │ ├── OrderRepository.cs
│ ├── ProductRepository.cs │ └── UserRepository.cs ├── Ecommerce.MVC/ │
├── appsettings.Development.json │ ├── appsettings.json │ ├──
Ecommerce.MVC.csproj │ ├── Program.cs │ ├── Controllers/ │ │ ├──
HomeController.cs │ │ └── UserViewController.cs │ ├── Models/ │ │ ├──
ErrorViewModel.cs │ │ └── UserViewModel.cs │ ├── Properties/ │ │ └──
launchSettings.json │ ├── Views/ │ │ ├── \_ViewImports.cshtml │ │ ├──
\_ViewStart.cshtml │ │ ├── Home/ │ │ │ ├── Index.cshtml │ │ │ └──
Privacy.cshtml │ │ ├── Shared/ │ │ │ ├── \_Layout.cshtml │ │ │ ├──
\_Layout.cshtml.css │ │ │ ├── \_ValidationScriptsPartial.cshtml │ │ │
└── Error.cshtml │ │ └── UserView/ │ │ ├── Create.cshtml │ │ ├──
Delete.cshtml │ │ ├── Details.cshtml │ │ ├── Edit.cshtml │ │ └──
Index.cshtml │ └── wwwroot/ │ ├── css/ │ │ └── site.css │ ├── js/ │ │
└── site.js │ └── lib/ │ ├── bootstrap/ │ │ └── LICENSE │ ├── jquery/ │
│ └── LICENSE.txt │ ├── jquery-validation/ │ │ └── LICENSE.md │ └──
jquery-validation-unobtrusive/ │ ├── jquery.validate.unobtrusive.js │
└── LICENSE.txt └── Ecommerce.Test/ ├── Ecommerce.Test.csproj ├──
UnitTest1.cs └── Services/ ├── ProductServiceTests.cs └──
UserServiceTests.cs

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/EcommercePro.sln
================================================ ﻿ Microsoft Visual
Studio Solution File, Format Version 12.00 \# Visual Studio Version 17
VisualStudioVersion = 17.14.36310.24 MinimumVisualStudioVersion =
10.0.40219.1 Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") =
\"Ecommerce.Test\", \"Ecommerce.Test\\Ecommerce.Test.csproj\",
\"{2C2EF60A-6EFF-4AAE-8564-2D35A6BE62B5}\" EndProject
Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"Ecommerce.MVC\",
\"Ecommerce.MVC\\Ecommerce.MVC.csproj\",
\"{670B4D33-AFF9-4240-8082-EA4688F0669B}\" EndProject
Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") =
\"Ecommerce.Core\", \"Ecommerce.Core\\Ecommerce.Core.csproj\",
\"{BFA4BD7D-30B6-43E9-AE01-4EB743B3E515}\" EndProject
Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") =
\"Ecommerce.Application\",
\"Ecommerce.Application\\Ecommerce.Application.csproj\",
\"{805EFE4A-F0B5-4643-80A1-5FB495F0B868}\" EndProject
Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") =
\"Ecommerce.Infrastructure\",
\"Ecommerce.Infrastructure\\Ecommerce.Infrastructure.csproj\",
\"{D5964C3C-CBAF-4FD9-B2F0-E59BA69806C3}\" EndProject
Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"Ecommerce.API\",
\"Ecommerce.API\\Ecommerce.API.csproj\",
\"{41CEB153-F5E2-496E-8E49-7EDCA58051A8}\" EndProject Global
GlobalSection(SolutionConfigurationPlatforms) = preSolution Debug\|Any
CPU = Debug\|Any CPU Release\|Any CPU = Release\|Any CPU
EndGlobalSection GlobalSection(ProjectConfigurationPlatforms) =
postSolution {2C2EF60A-6EFF-4AAE-8564-2D35A6BE62B5}.Debug\|Any
CPU.ActiveCfg = Debug\|Any CPU
{2C2EF60A-6EFF-4AAE-8564-2D35A6BE62B5}.Debug\|Any CPU.Build.0 =
Debug\|Any CPU {2C2EF60A-6EFF-4AAE-8564-2D35A6BE62B5}.Release\|Any
CPU.ActiveCfg = Release\|Any CPU
{2C2EF60A-6EFF-4AAE-8564-2D35A6BE62B5}.Release\|Any CPU.Build.0 =
Release\|Any CPU {670B4D33-AFF9-4240-8082-EA4688F0669B}.Debug\|Any
CPU.ActiveCfg = Debug\|Any CPU
{670B4D33-AFF9-4240-8082-EA4688F0669B}.Debug\|Any CPU.Build.0 =
Debug\|Any CPU {670B4D33-AFF9-4240-8082-EA4688F0669B}.Release\|Any
CPU.ActiveCfg = Release\|Any CPU
{670B4D33-AFF9-4240-8082-EA4688F0669B}.Release\|Any CPU.Build.0 =
Release\|Any CPU {BFA4BD7D-30B6-43E9-AE01-4EB743B3E515}.Debug\|Any
CPU.ActiveCfg = Debug\|Any CPU
{BFA4BD7D-30B6-43E9-AE01-4EB743B3E515}.Debug\|Any CPU.Build.0 =
Debug\|Any CPU {BFA4BD7D-30B6-43E9-AE01-4EB743B3E515}.Release\|Any
CPU.ActiveCfg = Release\|Any CPU
{BFA4BD7D-30B6-43E9-AE01-4EB743B3E515}.Release\|Any CPU.Build.0 =
Release\|Any CPU {805EFE4A-F0B5-4643-80A1-5FB495F0B868}.Debug\|Any
CPU.ActiveCfg = Debug\|Any CPU
{805EFE4A-F0B5-4643-80A1-5FB495F0B868}.Debug\|Any CPU.Build.0 =
Debug\|Any CPU {805EFE4A-F0B5-4643-80A1-5FB495F0B868}.Release\|Any
CPU.ActiveCfg = Release\|Any CPU
{805EFE4A-F0B5-4643-80A1-5FB495F0B868}.Release\|Any CPU.Build.0 =
Release\|Any CPU {D5964C3C-CBAF-4FD9-B2F0-E59BA69806C3}.Debug\|Any
CPU.ActiveCfg = Debug\|Any CPU
{D5964C3C-CBAF-4FD9-B2F0-E59BA69806C3}.Debug\|Any CPU.Build.0 =
Debug\|Any CPU {D5964C3C-CBAF-4FD9-B2F0-E59BA69806C3}.Release\|Any
CPU.ActiveCfg = Release\|Any CPU
{D5964C3C-CBAF-4FD9-B2F0-E59BA69806C3}.Release\|Any CPU.Build.0 =
Release\|Any CPU {41CEB153-F5E2-496E-8E49-7EDCA58051A8}.Debug\|Any
CPU.ActiveCfg = Debug\|Any CPU
{41CEB153-F5E2-496E-8E49-7EDCA58051A8}.Debug\|Any CPU.Build.0 =
Debug\|Any CPU {41CEB153-F5E2-496E-8E49-7EDCA58051A8}.Release\|Any
CPU.ActiveCfg = Release\|Any CPU
{41CEB153-F5E2-496E-8E49-7EDCA58051A8}.Release\|Any CPU.Build.0 =
Release\|Any CPU EndGlobalSection GlobalSection(SolutionProperties) =
preSolution HideSolutionNode = FALSE EndGlobalSection
GlobalSection(ExtensibilityGlobals) = postSolution SolutionGuid =
{435E1C5F-7A7B-4CF4-AE9D-0EBC1AC094BE} EndGlobalSection EndGlobal

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.API/appsettings.Development.json
================================================ { \"Logging\": {
\"LogLevel\": { \"Default\": \"Information\", \"Microsoft.AspNetCore\":
\"Warning\" } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.API/appsettings.json
================================================ { \"Logging\": {
\"LogLevel\": { \"Default\": \"Information\", \"Microsoft.AspNetCore\":
\"Warning\" } }, \"AllowedHosts\": \"\*\", \"ConnectionStrings\": {
\"EcommerceDB\":
\"Server=localhost;TrustServerCertificate=True;Database=EcommerceProDB;User
Id=sa;Password=YourSecurepassword123!;\" } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.API/Ecommerce.API.csproj
================================================ \<Project
Sdk=\"Microsoft.NET.Sdk.Web\"\>

\<PropertyGroup\> \<TargetFramework\>net8.0\</TargetFramework\>
\<Nullable\>enable\</Nullable\>
\<ImplicitUsings\>enable\</ImplicitUsings\> \</PropertyGroup\>

\<ItemGroup\> \<PackageReference
Include=\"AutoMapper.Extensions.Microsoft.DependencyInjection\"
Version=\"12.0.1\" /\> \<PackageReference
Include=\"Microsoft.EntityFrameworkCore\" Version=\"9.0.8\" /\>
\<PackageReference Include=\"Microsoft.EntityFrameworkCore.Design\"
Version=\"9.0.8\"\> \<IncludeAssets\>runtime; build; native;
contentfiles; analyzers; buildtransitive\</IncludeAssets\>
\<PrivateAssets\>all\</PrivateAssets\> \</PackageReference\>
\<PackageReference Include=\"Microsoft.EntityFrameworkCore.SqlServer\"
Version=\"9.0.8\" /\> \<PackageReference
Include=\"Microsoft.EntityFrameworkCore.Tools\" Version=\"9.0.8\"\>
\<IncludeAssets\>runtime; build; native; contentfiles; analyzers;
buildtransitive\</IncludeAssets\> \<PrivateAssets\>all\</PrivateAssets\>
\</PackageReference\> \<PackageReference
Include=\"Swashbuckle.AspNetCore\" Version=\"6.6.2\" /\> \</ItemGroup\>

\<ItemGroup\> \<ProjectReference
Include=\"..\\Ecommerce.Application\\Ecommerce.Application.csproj\" /\>
\<ProjectReference Include=\"..\\Ecommerce.Core\\Ecommerce.Core.csproj\"
/\> \</ItemGroup\>

\</Project\>

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.API/Ecommerce.API.http
================================================
\@Ecommerce.API_HostAddress = http://localhost:5026

GET {{Ecommerce.API_HostAddress}}/weatherforecast/ Accept:
application/json

\###

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.API/Program.cs
================================================ using
Ecommerce.API.Extensions; using Ecommerce.Application.Services; using
Ecommerce.Core.Interfaces; using Ecommerce.Infrastructure.Data; using
Ecommerce.Infrastructure.Repositories; using
Microsoft.EntityFrameworkCore; using
Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register AutoMapper (it will scan for MappingProfile automatically)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register DbContext
builder.Services.AddDbContext\<AppDbContext\>(options =\>
options.UseSqlServer(builder.Configuration.GetConnectionString(\"EcommerceDB\")));

// Register repositories (Scoped for Entity Framework)
builder.Services.AddScoped\<IUserRepository, UserRepository\>();
builder.Services.AddScoped\<IProductRepository, ProductRepository\>();
builder.Services.AddScoped\<IOrderRepository, OrderRepository\>();
builder.Services.AddScoped\<IOrderItemRepository,
OrderItemRepository\>();

// Register services builder.Services.AddScoped\<IUserService,
UserService\>(); builder.Services.AddScoped\<IProductService,
ProductService\>(); builder.Services.AddScoped\<IOrderService,
OrderService\>(); builder.Services.AddScoped\<IOrderItemService,
OrderItemService\>();

// CORS configuration builder.Services.AddCors(options =\> {
options.AddDefaultPolicy(policy =\> {
policy.WithOrigins(\"https://localhost:5001\") // MVC port
.AllowAnyHeader() .AllowAnyMethod(); }); });

var app = builder.Build();

// Configure the HTTP request pipeline if
(app.Environment.IsDevelopment()) { app.UseSwagger();
app.UseSwaggerUI(); }

app.UseCors(); app.UseGlobalExceptionMiddleware();
app.UseHttpsRedirection(); app.UseAuthorization();

app.MapControllers();

app.Run();

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.API/WeatherForecast.cs
================================================ namespace Ecommerce.API
{ public class WeatherForecast { public DateOnly Date { get; set; }

public int TemperatureC { get; set; }

public int TemperatureF =\> 32 + (int)(TemperatureC / 0.5556);

public string? Summary { get; set; } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.API/Controllers/OrderController.cs
================================================ ﻿using
Ecommerce.Application.Services; using Ecommerce.Core.DTOs; using
Ecommerce.Core.Interfaces; using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers { \[ApiController\]
\[Route(\"api/\[controller\]\")\] public class OrderController :
ControllerBase { private readonly IOrderService \_orderService;

public OrderController(IOrderService orderService) { \_orderService =
orderService; }

\[HttpGet\] public async
Task\<ActionResult\<List\<OrderResponseDTO\>\>\> GetAllOrders() { var
orders = await \_orderService.GetAllOrdersAsync(); return Ok(orders); }

\[HttpGet(\"{id}\")\] public async
Task\<ActionResult\<OrderResponseDTO\>\> GetOrderById(int id) { var
order = await \_orderService.GetOrderByIdAsync(id); if (order == null)
return NotFound();

return Ok(order); }

\[HttpPost\] public async Task\<ActionResult\<OrderResponseDTO\>\>
CreateOrder(OrderRequestDTO request) { var order = await
\_orderService.AddOrderAsync(request); return
CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order); }

\[HttpPut(\"{id}\")\] public async Task\<IActionResult\> UpdateOrder(int
id, OrderRequestDTO request) { try { await
\_orderService.UpdateOrderAsync(id, request); return NoContent(); }
catch (KeyNotFoundException) { return NotFound(); } }

\[HttpDelete(\"{id}\")\] public async Task\<IActionResult\>
DeleteOrder(int id) { try { await \_orderService.DeleteOrderAsync(id);
return NoContent(); } catch (KeyNotFoundException) { return NotFound();
} catch (InvalidOperationException ex) { return BadRequest(ex.Message);
} } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.API/Controllers/OrderItemController.cs
================================================ ﻿using
Ecommerce.Core.DTOs; using Ecommerce.Core.Interfaces; using
Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers { \[ApiController\]
\[Route(\"api/\[controller\]\")\] public class OrderItemController :
ControllerBase { private readonly IOrderItemService \_orderItemService;

public OrderItemController(IOrderItemService orderItemService) {
\_orderItemService = orderItemService; }

\[HttpGet\] public async Task\<IActionResult\> GetAll() { var orderItems
= await \_orderItemService.GetAllOrderItemsAsync(); return
Ok(orderItems); }

\[HttpPost\] public async Task\<IActionResult\>
Create(OrderItemRequestDTO dto) { var orderItem = await
\_orderItemService.AddOrderItemAsync(dto); return
CreatedAtAction(nameof(GetAll), new { id = orderItem.Id }, orderItem); }

\[HttpDelete(\"{id}\")\] public async Task\<IActionResult\> Delete(int
id) { await \_orderItemService.DeleteOrderItemAsync(id); return
NoContent(); } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.API/Controllers/ProductController.cs
================================================ ﻿using
Ecommerce.Core.DTOs; using Ecommerce.Core.Interfaces; using
Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers { \[ApiController\]
\[Route(\"api/\[controller\]\")\] public class ProductController :
ControllerBase { private readonly IProductService \_productService;

public ProductController(IProductService productService) {
\_productService = productService; }

\[HttpGet\] public async Task\<IActionResult\> GetAll() { var products =
await \_productService.GetAllProductsAsync(); return Ok(products); }

\[HttpGet(\"{id}\")\] public async Task\<IActionResult\> GetById(int id)
{ var product = await \_productService.GetProductByIdAsync(id); if
(product == null) return NotFound(); return Ok(product); }

\[HttpPost\] public async Task\<IActionResult\> Create(ProductRequestDTO
product) { var created = await
\_productService.AddProductAsync(product); return
CreatedAtAction(nameof(GetById), new { id = created.Id }, created); }

\[HttpPut(\"{id}\")\] public async Task\<IActionResult\> Update(int id,
ProductRequestDTO product) { await
\_productService.UpdateProductAsync(id, product); return NoContent(); }

\[HttpDelete(\"{id}\")\] public async Task\<IActionResult\> Delete(int
id) { await \_productService.DeleteProductAsync(id); return NoContent();
} } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.API/Controllers/UserController.cs
================================================ ﻿using
Ecommerce.Core.DTOs; using Ecommerce.Core.DTOs.Ecommerce.Core.DTOs;
using Ecommerce.Core.Interfaces; using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers { \[ApiController\]
\[Route(\"api/\[controller\]\")\] public class UserController :
ControllerBase { private readonly IUserService \_userService;

public UserController(IUserService userService) { \_userService =
userService; }

\[HttpGet\] public async
Task\<ActionResult\<IEnumerable\<UserResponseDTO\>\>\> GetAll() { var
users = await \_userService.GetAllUsersAsync(); return Ok(users); }

\[HttpGet(\"{id}\")\] public async
Task\<ActionResult\<UserResponseDTO\>\> GetById(int id) { var user =
await \_userService.GetUserByIdAsync(id); if (user == null) return
NotFound();

return Ok(user); }

\[HttpPost\] public async Task\<ActionResult\<UserResponseDTO\>\>
Create(UserRequestDTO user) { var createdUser = await
\_userService.AddUserAsync(user); return
CreatedAtAction(nameof(GetById), new { id = createdUser.Id },
createdUser); }

\[HttpPut(\"{id}\")\] public async Task\<IActionResult\> Update(int id,
UserRequestDTO user) { try { await \_userService.UpdateUserAsync(id,
user); return NoContent(); } catch (KeyNotFoundException ex) { return
NotFound(ex.Message); } }

\[HttpDelete(\"{id}\")\] public async Task\<IActionResult\> Delete(int
id) { try { await \_userService.DeleteUserAsync(id); return NoContent();
} catch (KeyNotFoundException ex) { return NotFound(ex.Message); } } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.API/Controllers/WeatherForecastController.cs
================================================ using
Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers { \[ApiController\]
\[Route(\"\[controller\]\")\] public class WeatherForecastController :
ControllerBase { private static readonly string\[\] Summaries = new\[\]
{ \"Freezing\", \"Bracing\", \"Chilly\", \"Cool\", \"Mild\", \"Warm\",
\"Balmy\", \"Hot\", \"Sweltering\", \"Scorching\" };

private readonly ILogger\<WeatherForecastController\> \_logger;

public WeatherForecastController(ILogger\<WeatherForecastController\>
logger) { \_logger = logger; }

\[HttpGet(Name = \"GetWeatherForecast\")\] public
IEnumerable\<WeatherForecast\> Get() { return Enumerable.Range(1,
5).Select(index =\> new WeatherForecast { Date =
DateOnly.FromDateTime(DateTime.Now.AddDays(index)), TemperatureC =
Random.Shared.Next(-20, 55), Summary =
Summaries\[Random.Shared.Next(Summaries.Length)\] }) .ToArray(); } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.API/Extensions/ExceptionMiddlewareExtensions.cs
================================================ ﻿using
Ecommerce.API.Middleware; using System.Runtime.CompilerServices;

namespace Ecommerce.API.Extensions { public static class
ExceptionMiddlewareExtensions { public static IApplicationBuilder
UseGlobalExceptionMiddleware(this IApplicationBuilder app) { return
app.UseMiddleware\<GlobalExceptionMiddleware\>(); } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.API/Middleware/GlobalExceptionMiddleware.cs
================================================ ﻿using
Ecommerce.Core.DTOs; using Ecommerce.Core.Exceptions; using
System.Text.Json;

namespace Ecommerce.API.Middleware { public class
GlobalExceptionMiddleware { private readonly RequestDelegate \_next;
private readonly ILogger\<GlobalExceptionMiddleware\> \_logger; private
readonly IWebHostEnvironment \_env;

public GlobalExceptionMiddleware(RequestDelegate next,
ILogger\<GlobalExceptionMiddleware\> logger, IWebHostEnvironment env) {
\_next = next; \_logger = logger; \_env = env; }

public async Task InvokeAsync(HttpContext context) { try { await
\_next(context); } catch(Exception ex) { await
HandleExceptionAsync(context, ex); } }

// Handling Custom exceptions private async Task
HandleExceptionAsync(HttpContext context, Exception ex) { var
correlationId = context.TraceIdentifier; context.Response.ContentType =
\"application/json\";

int statusCode; string message; string? detail = null;

switch (ex) { case NotFoundException nf: statusCode =
StatusCodes.Status404NotFound; message = nf.Message; detail =
\_env.IsDevelopment() ? nf.StackTrace : null; break;

case ValidationException val: statusCode =
StatusCodes.Status400BadRequest; message = val.Message; detail =
\_env.IsDevelopment() ? val.StackTrace : null; break;

case UnauthorizedException unAuth: statusCode =
StatusCodes.Status401Unauthorized; message = unAuth.Message; detail =
\_env.IsDevelopment() ? unAuth.StackTrace : null; break;

case ForbiddenException forbidden: statusCode =
StatusCodes.Status403Forbidden; message = forbidden.Message; detail =
\_env.IsDevelopment() ? forbidden.StackTrace : null; break;

case ConflictException conflict: statusCode =
StatusCodes.Status409Conflict; message = conflict.Message; detail =
\_env.IsDevelopment() ? conflict.StackTrace : null; break;

default: statusCode = StatusCodes.Status500InternalServerError; message
= \"An unexpected error occurred.\"; detail = \_env.IsDevelopment() ?
ex.StackTrace : null; break; }

var error = new ErrorResponseDTO { CorrelationId = correlationId,
StatusCode = statusCode, Message = message, Details = detail };

\_logger.LogError( ex, \"Unhandled exception for {Method} {Path}.
CorrelationId: {CorrelationId}\", context.Request.Method,
context.Request.Path, correlationId ); context.Response.StatusCode =
statusCode;

var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy =
JsonNamingPolicy.CamelCase }; await
context.Response.WriteAsync(JsonSerializer.Serialize(error,
jsonOptions)); } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.API/Properties/launchSettings.json
================================================ ﻿{ \"\$schema\":
\"http://json.schemastore.org/launchsettings.json\", \"iisSettings\": {
\"windowsAuthentication\": false, \"anonymousAuthentication\": true,
\"iisExpress\": { \"applicationUrl\": \"http://localhost:21775\",
\"sslPort\": 44337 } }, \"profiles\": { \"http\": { \"commandName\":
\"Project\", \"dotnetRunMessages\": true, \"launchBrowser\": true,
\"launchUrl\": \"swagger\", \"applicationUrl\":
\"http://localhost:5026\", \"environmentVariables\": {
\"ASPNETCORE_ENVIRONMENT\": \"Development\" } }, \"https\": {
\"commandName\": \"Project\", \"dotnetRunMessages\": true,
\"launchBrowser\": true, \"launchUrl\": \"swagger\", \"applicationUrl\":
\"https://localhost:7280;http://localhost:5026\",
\"environmentVariables\": { \"ASPNETCORE_ENVIRONMENT\": \"Development\"
} }, \"IIS Express\": { \"commandName\": \"IISExpress\",
\"launchBrowser\": true, \"launchUrl\": \"swagger\",
\"environmentVariables\": { \"ASPNETCORE_ENVIRONMENT\": \"Development\"
} } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Application/Class1.cs
================================================ ﻿namespace
Ecommerce.Application { public class Class1 {

} }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Application/Ecommerce.Application.csproj
================================================ ﻿\<Project
Sdk=\"Microsoft.NET.Sdk\"\>

\<PropertyGroup\> \<TargetFramework\>net8.0\</TargetFramework\>
\<ImplicitUsings\>enable\</ImplicitUsings\>
\<Nullable\>enable\</Nullable\> \</PropertyGroup\>

\<ItemGroup\> \<PackageReference Include=\"AutoMapper\"
Version=\"12.0.1\" /\> \</ItemGroup\>

\<ItemGroup\> \<ProjectReference
Include=\"..\\Ecommerce.Core\\Ecommerce.Core.csproj\" /\>
\<ProjectReference
Include=\"..\\Ecommerce.Infrastructure\\Ecommerce.Infrastructure.csproj\"
/\> \</ItemGroup\>

\</Project\>

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Application/Mapping/MappingProfile.cs
================================================ ﻿using AutoMapper; using
Ecommerce.Core.DTOs; using Ecommerce.Core.Entities;

namespace Ecommerce.Application.Mapping { public class MappingProfile :
Profile { public MappingProfile() { CreateMap\<User,
UserRequestDTO\>().ReverseMap(); CreateMap\<User, UserResponseDTO\>();

CreateMap\<Product, ProductRequestDTO\>().ReverseMap();
CreateMap\<Product, ProductResponseDTO\>();

CreateMap\<OrderItem, OrderItemRequestDTO\>().ReverseMap();
CreateMap\<OrderItem, OrderItemResponseDTO\>();

CreateMap\<Order, OrderRequestDTO\>().ReverseMap(); CreateMap\<Order,
OrderResponseDTO\>() .ForMember(dest =\> dest.Items, opt =\>
opt.MapFrom(src =\> src.Items)); } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Application/Services/OrderItemService.cs
================================================ ﻿using AutoMapper; using
Ecommerce.Core.DTOs; using Ecommerce.Core.Entities; using
Ecommerce.Core.Exceptions; using Ecommerce.Core.Interfaces;

namespace Ecommerce.Application.Services { public class OrderItemService
: IOrderItemService { private readonly IOrderItemRepository
\_orderItemRepository; private readonly IProductRepository
\_productRepository; private readonly IUserRepository \_userRepository;
private readonly IMapper \_mapper;

public OrderItemService(IOrderItemRepository orderItemRepository,
IProductRepository productRepository, IUserRepository userRepository,
IMapper mapper) { \_orderItemRepository = orderItemRepository;
\_productRepository = productRepository; \_userRepository =
userRepository; \_mapper = mapper; }

public async Task\<OrderItemResponseDTO\>
AddOrderItemAsync(OrderItemRequestDTO dto) { var validationErrors = new
Dictionary\<string, string\>(); if (dto.CustomerId \<= 0)
validationErrors\[nameof(dto.CustomerId)\] = \"CustomerId is
required.\"; if (dto.ProductId \<= 0)
validationErrors\[nameof(dto.ProductId)\] = \"ProductId is required.\";
if (dto.Quantity \<= 0) validationErrors\[nameof(dto.Quantity)\] =
\"Quantity must be greater than zero.\"; if (validationErrors.Count \>
0) throw new ValidationException(validationErrors);

var customer = await \_userRepository.GetByIdAsync(dto.CustomerId); if
(customer == null) throw new NotFoundException(\$\"User with Id
{dto.CustomerId} not found.\"); if (!string.Equals(customer.Role,
\"Buyer\", StringComparison.OrdinalIgnoreCase) &&
!string.Equals(customer.Role, \"Customer\",
StringComparison.OrdinalIgnoreCase)) throw new ForbiddenException(\"Only
customers can add items to cart.\");

var product = await \_productRepository.GetByIdAsync(dto.ProductId); if
(product == null) throw new NotFoundException(\$\"Product with Id
{dto.ProductId} not found.\"); if (product.Stock \< dto.Quantity) throw
new ValidationException(new Dictionary\<string, string\> { {
nameof(dto.Quantity), \"Insufficient stock.\" } });

var entity = new OrderItem { CustomerId = dto.CustomerId, ProductId =
dto.ProductId, Quantity = dto.Quantity, UnitPrice = product.Price };

await \_orderItemRepository.AddAsync(entity); return
\_mapper.Map\<OrderItemResponseDTO\>(entity); }

public async Task DeleteOrderItemAsync(int id) { await
\_orderItemRepository.DeleteAsync(id); }

public async Task\<IEnumerable\<OrderItemResponseDTO\>\>
GetAllOrderItemsAsync() { var entities = await
\_orderItemRepository.GetAllAsync(); return
\_mapper.Map\<IEnumerable\<OrderItemResponseDTO\>\>(entities); } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Application/Services/OrderService.cs
================================================ ﻿using AutoMapper; using
Ecommerce.Core.DTOs; using Ecommerce.Core.Entities; using
Ecommerce.Core.Exceptions; using Ecommerce.Core.Interfaces;

namespace Ecommerce.Application.Services { public class OrderService :
IOrderService { private readonly IOrderRepository \_orderRepository;
private readonly IOrderItemRepository \_orderItemRepository; private
readonly IProductRepository \_productRepository; private readonly
IUserRepository \_userRepository; private readonly IMapper \_mapper;

public OrderService(IOrderRepository orderRepository,
IOrderItemRepository orderItemRepository, IProductRepository
productRepository, IUserRepository userRepository, IMapper mapper) {
\_orderRepository = orderRepository; \_orderItemRepository =
orderItemRepository; \_productRepository = productRepository;
\_userRepository = userRepository; \_mapper = mapper; }

public async Task\<OrderResponseDTO\> AddOrderAsync(OrderRequestDTO
request) { var errors = new Dictionary\<string, string\>(); if
(request.CustomerId \<= 0) errors\[nameof(request.CustomerId)\] =
\"CustomerId is required.\"; if (request.OrderItemIds == null \|\|
request.OrderItemIds.Count == 0) errors\[nameof(request.OrderItemIds)\]
= \"At least one order item id is required.\"; if (errors.Count \> 0)
throw new ValidationException(errors);

var customer = await \_userRepository.GetByIdAsync(request.CustomerId);
if (customer == null) throw new NotFoundException(\$\"User with Id
{request.CustomerId} not found.\");

var order = new Order { CustomerId = request.CustomerId, Status =
\"Completed\", Items = new List\<OrderItem\>() };

decimal total = 0; foreach (var idOrder in request.OrderItemIds) { var
cartItem = await \_orderItemRepository.GetByIdAsync(idOrder); if
(cartItem == null) throw new NotFoundException(\$\"Order item with Id
{idOrder} not found.\"); if (cartItem.CustomerId != request.CustomerId)
throw new ForbiddenException(\"Order item does not belong to this
customer.\");

var product = await
\_productRepository.GetByIdAsync(cartItem.ProductId); if (product ==
null) throw new NotFoundException(\$\"Product with Id
{cartItem.ProductId} not found.\"); if (cartItem.Quantity \<= 0) throw
new ValidationException(new Dictionary\<string, string\> { {
nameof(cartItem.Quantity), \"Quantity must be greater than zero.\" } });
if (product.Stock \< cartItem.Quantity) throw new
ValidationException(new Dictionary\<string, string\> { {
nameof(cartItem.Quantity), \"Insufficient stock.\" } });

cartItem.UnitPrice = product.Price; // ensure current price total +=
cartItem.TotalPrice; order.Items.Add(new OrderItem { ProductId =
cartItem.ProductId, Quantity = cartItem.Quantity, UnitPrice =
cartItem.UnitPrice });

product.Stock -= cartItem.Quantity; // reduce stock upon order creation
await \_productRepository.UpdateAsync(product);

// clear cart item await \_orderItemRepository.DeleteAsync(cartItem.Id);
}

order.TotalAmount = total; await \_orderRepository.AddAsync(order);
return \_mapper.Map\<OrderResponseDTO\>(order); }

public async Task UpdateOrderAsync(int id, OrderRequestDTO request) {
var existingOrder = await \_orderRepository.GetByIdAsync(id); if
(existingOrder == null) throw new NotFoundException(\"Order not
found\");

if (existingOrder.Status == \"Completed\") throw new
ForbiddenException(\"Cannot update completed orders\");

if (request.OrderItemIds == null \|\| request.OrderItemIds.Count == 0)
throw new ValidationException(new Dictionary\<string, string\> { {
nameof(request.OrderItemIds), \"At least one order item id is
required.\" } });

existingOrder.CustomerId = request.CustomerId;
existingOrder.Items.Clear();

decimal total = 0; foreach (var idOrder in request.OrderItemIds) { var
cartItem = await \_orderItemRepository.GetByIdAsync(idOrder); if
(cartItem == null) throw new NotFoundException(\$\"Order item with Id
{idOrder} not found.\"); if (cartItem.CustomerId != request.CustomerId)
throw new ForbiddenException(\"Order item does not belong to this
customer.\");

var product = await
\_productRepository.GetByIdAsync(cartItem.ProductId); if (product ==
null) throw new NotFoundException(\$\"Product with Id
{cartItem.ProductId} not found.\"); if (cartItem.Quantity \<= 0) throw
new ValidationException(new Dictionary\<string, string\> { {
nameof(cartItem.Quantity), \"Quantity must be greater than zero.\" } });
if (product.Stock \< cartItem.Quantity) throw new
ValidationException(new Dictionary\<string, string\> { {
nameof(cartItem.Quantity), \"Insufficient stock.\" } });

cartItem.UnitPrice = product.Price; total += cartItem.TotalPrice;
existingOrder.Items.Add(new OrderItem { ProductId = cartItem.ProductId,
Quantity = cartItem.Quantity, UnitPrice = cartItem.UnitPrice }); }

existingOrder.TotalAmount = total;

await \_orderRepository.UpdateAsync(existingOrder); }

public async Task DeleteOrderAsync(int id) { var existingOrder = await
\_orderRepository.GetByIdAsync(id); if (existingOrder == null) throw new
NotFoundException(\"Order not found\");

if (existingOrder.Status == \"Completed\") throw new
ForbiddenException(\"Cannot delete completed orders\");

await \_orderRepository.DeleteAsync(id); }

public async Task\<List\<OrderResponseDTO\>\> GetAllOrdersAsync() { var
orders = await \_orderRepository.GetAllAsync(); return
\_mapper.Map\<List\<OrderResponseDTO\>\>(orders); }

public async Task\<OrderResponseDTO?\> GetOrderByIdAsync(int id) { var
order = await \_orderRepository.GetByIdAsync(id); return order != null ?
\_mapper.Map\<OrderResponseDTO\>(order) : null; } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Application/Services/ProductService.cs
================================================ ﻿using AutoMapper; using
Ecommerce.Core.DTOs; using Ecommerce.Core.Exceptions; using
Ecommerce.Core.Interfaces;

namespace Ecommerce.Application.Services { public class ProductService :
IProductService { private readonly IProductRepository
\_productRepository; private readonly IUserRepository \_userRepository;
private readonly IMapper \_mapper;

public ProductService(IProductRepository productRepository,
IUserRepository userRepository, IMapper mapper) { \_productRepository =
productRepository; \_userRepository = userRepository; \_mapper = mapper;
}

public async Task\<ProductResponseDTO\>
AddProductAsync(ProductRequestDTO product) { var validationErrors = new
Dictionary\<string, string\>(); if
(string.IsNullOrWhiteSpace(product.Name))
validationErrors\[nameof(product.Name)\] = \"Name is required.\"; if
(product.Price \<= 0) validationErrors\[nameof(product.Price)\] =
\"Price must be greater than zero.\"; if (product.Stock \< 0)
validationErrors\[nameof(product.Stock)\] = \"Stock cannot be
negative.\"; if (product.SellerId \<= 0)
validationErrors\[nameof(product.SellerId)\] = \"SellerId must be a
positive integer.\";

if (validationErrors.Count \> 0) throw new
ValidationException(validationErrors);

var seller = await \_userRepository.GetByIdAsync(product.SellerId); if
(seller == null) throw new NotFoundException(\$\"User with Id
{product.SellerId} not found.\");

if (!string.Equals(seller.Role, \"Seller\",
StringComparison.OrdinalIgnoreCase)) throw new ForbiddenException(\"Only
users with role \'Seller\' can create products.\");

var entity = \_mapper.Map\<Product\>(product); entity.SellerId =
seller.Id;

await \_productRepository.AddAsync(entity); return
\_mapper.Map\<ProductResponseDTO\>(entity); }

public async Task UpdateProductAsync(int id, ProductRequestDTO product)
{ var existing = await \_productRepository.GetByIdAsync(id); if
(existing == null) throw new KeyNotFoundException(\$\"Product with Id
{id} not found.\");

// Map updated fields into a new entity var updatedEntity =
\_mapper.Map\<Product\>(product); updatedEntity.Id = id; // preserve
original Id

await \_productRepository.UpdateAsync(updatedEntity); }

public async Task DeleteProductAsync(int id) { var existing = await
\_productRepository.GetByIdAsync(id); if (existing == null) throw new
KeyNotFoundException(\$\"Product with Id {id} not found.\");

await \_productRepository.DeleteAsync(id); }

public async Task\<List\<ProductResponseDTO\>\> GetAllProductsAsync() {
var products = await \_productRepository.GetAllAsync(); return
\_mapper.Map\<List\<ProductResponseDTO\>\>(products); }

public async Task\<ProductResponseDTO?\> GetProductByIdAsync(int id) {
var product = await \_productRepository.GetByIdAsync(id); return product
== null ? null : \_mapper.Map\<ProductResponseDTO\>(product); } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Application/Services/UserService.cs
================================================ ﻿using AutoMapper; using
Ecommerce.Core.DTOs; using Ecommerce.Core.DTOs.Ecommerce.Core.DTOs;
using Ecommerce.Core.Entities; using Ecommerce.Core.Interfaces;

namespace Ecommerce.Application.Services { public class UserService :
IUserService { private readonly IUserRepository \_userRepository;
private readonly IMapper \_mapper;

public UserService(IUserRepository userRepository, IMapper mapper) {
\_userRepository = userRepository; \_mapper = mapper; }

public async Task\<UserResponseDTO\> AddUserAsync(UserRequestDTO user) {
var entity = \_mapper.Map\<User\>(user); await
\_userRepository.AddAsync(entity); return
\_mapper.Map\<UserResponseDTO\>(entity); }

public async Task UpdateUserAsync(int id, UserRequestDTO user) { var
existing = await \_userRepository.GetByIdAsync(id); if (existing ==
null) throw new KeyNotFoundException(\$\"User with Id {id} not
found.\");

\_mapper.Map(user, existing); // map updated fields into existing entity
await \_userRepository.UpdateAsync(existing); }

public async Task DeleteUserAsync(int id) { var existing = await
\_userRepository.GetByIdAsync(id); if (existing == null) throw new
KeyNotFoundException(\$\"User with Id {id} not found.\");

await \_userRepository.DeleteAsync(id); }

public async Task\<List\<UserResponseDTO\>\> GetAllUsersAsync() { var
users = await \_userRepository.GetAllAsync(); return
\_mapper.Map\<List\<UserResponseDTO\>\>(users); }

public async Task\<UserResponseDTO?\> GetUserByIdAsync(int id) { var
user = await \_userRepository.GetByIdAsync(id); return user == null ?
null : \_mapper.Map\<UserResponseDTO\>(user); } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Class1.cs
================================================ ﻿namespace
Ecommerce.Core { public class Class1 {

} }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Ecommerce.Core.csproj
================================================ ﻿\<Project
Sdk=\"Microsoft.NET.Sdk\"\>

\<PropertyGroup\> \<TargetFramework\>net8.0\</TargetFramework\>
\<ImplicitUsings\>enable\</ImplicitUsings\>
\<Nullable\>enable\</Nullable\> \</PropertyGroup\>

\</Project\>

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/DTOs/ErrorResponseDTO.cs
================================================ ﻿ namespace
Ecommerce.Core.DTOs { public class ErrorResponseDTO { public int
StatusCode { get; set; } public string Message { get; set; } public
string Details { get; set; } public string CorrelationId { get; set; } }
}

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/DTOs/OrderItemRequestDTO.cs
================================================ ﻿

namespace Ecommerce.Core.DTOs { public class OrderItemRequestDTO {
public int CustomerId { get; set; } public int ProductId { get; set; }
public int Quantity { get; set; } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/DTOs/OrderItemResponseDTO.cs
================================================ ﻿

namespace Ecommerce.Core.DTOs { public class OrderItemResponseDTO {
public int Id { get; set; } public int? OrderId { get; set; } public int
ProductId { get; set; } public int Quantity { get; set; } public decimal
UnitPrice { get; set; } public decimal TotalPrice { get; set; } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/DTOs/OrderRequestDTO.cs
================================================ ﻿

using Ecommerce.Core.Entities;

namespace Ecommerce.Core.DTOs { public class OrderRequestDTO { public
int CustomerId { get; set; } public List\<int\> OrderItemIds { get; set;
} = new List\<int\>(); } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/DTOs/OrderResponseDTO.cs
================================================ ﻿

using Ecommerce.Core.Entities;

namespace Ecommerce.Core.DTOs { public class OrderResponseDTO { public
int Id { get; set; } public DateTime OrderDate { get; set; } =
DateTime.UtcNow; public decimal TotalAmount { get; set; } public string
Status { get; set; } = \"Pending\"; public int CustomerId { get; set; }
public List\<OrderItemResponseDTO\> Items { get; set; } = new
List\<OrderItemResponseDTO\>(); } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/DTOs/OrderSummaryDTO.cs
================================================ ﻿

namespace Ecommerce.Core.DTOs { public class OrderSummaryDTO { public
int Id { get; set; } public DateTime OrderDate { get; set; } public
decimal TotalAmount { get; set; } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/DTOs/ProductRequestDTO.cs
================================================ ﻿

using Ecommerce.Core.Entities;

namespace Ecommerce.Core.DTOs { public class ProductRequestDTO { public
string Name { get; set; } = string.Empty; public string Description {
get; set; } = string.Empty; public decimal Price { get; set; } public
int Stock { get; set; } public string Category { get; set; } =
string.Empty; public int SellerId { get; set; } // FK to User } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/DTOs/ProductResponseDTO.cs
================================================ ﻿ using
Ecommerce.Core.Entities;

namespace Ecommerce.Core.DTOs { public class ProductResponseDTO { public
int Id { get; set; } public string Name { get; set; } = string.Empty;
public string Description { get; set; } = string.Empty; public decimal
Price { get; set; } public int Stock { get; set; } public string
Category { get; set; } = string.Empty; public int SellerId { get; set; }
// FK to User } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/DTOs/ProductSummaryDTO.cs
================================================ ﻿

namespace Ecommerce.Core.DTOs { public class ProductSummaryDTO { public
int Id { get; set; } public string Name { get; set; } = string.Empty;
public decimal Price { get; set; } public string Category { get; set; }
= string.Empty; } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/DTOs/UserRequestDTO.cs
================================================ ﻿

namespace Ecommerce.Core.DTOs { public class UserRequestDTO { public
string Username { get; set; } = string.Empty; public string Email { get;
set; } = string.Empty; public string Role { get; set; } = \"Buyer\"; } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/DTOs/UserResponseDTO.cs
================================================ ﻿

namespace Ecommerce.Core.DTOs { namespace Ecommerce.Core.DTOs { public
class UserResponseDTO { public int Id { get; set; } public string
Username { get; set; } = string.Empty; public string Email { get; set; }
= string.Empty; public string Role { get; set; } = \"Buyer\";

// For Buyers → Orders they placed public List\<OrderSummaryDTO\>?
Orders { get; set; }

// For Buyers → Products they bought public List\<ProductSummaryDTO\>?
BoughtProducts { get; set; }

// For Sellers → Products they listed public List\<ProductSummaryDTO\>?
SoldProducts { get; set; } } }

}

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Entities/Order.cs
================================================ ﻿using
System.ComponentModel.DataAnnotations; using
System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Core.Entities; public class Order { \[Key\] public
int Id { get; set; }

\[Required\] public DateTime OrderDate { get; set; } = DateTime.UtcNow;

\[Required\] \[Column(TypeName = \"decimal(18,2)\")\] public decimal
TotalAmount { get; set; }

\[Required\] \[ForeignKey(\"Customer\")\] public int CustomerId { get;
set; }

\[Required\] \[StringLength(50)\] public string Status { get; set; } =
\"Pending\";

// Navigation properties public virtual User Customer { get; set; } =
null!; public virtual ICollection\<OrderItem\> Items { get; set; } = new
List\<OrderItem\>(); }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Entities/OrderItem.cs
================================================ ﻿using
System.ComponentModel.DataAnnotations; using
System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Core.Entities; public class OrderItem { \[Key\]
public int Id { get; set; }

\[ForeignKey(\"Order\")\] public int? OrderId { get; set; } // Nullable
for cart items

\[Required\] \[ForeignKey(\"Customer\")\] public int CustomerId { get;
set; } // For cart association

\[Required\] \[ForeignKey(\"Product\")\] public int ProductId { get;
set; }

\[Required\] \[Range(1, int.MaxValue)\] public int Quantity { get; set;
}

\[Required\] \[Column(TypeName = \"decimal(18,2)\")\] public decimal
UnitPrice { get; set; }

\[NotMapped\] public decimal TotalPrice =\> Quantity \* UnitPrice;

// Navigation properties public virtual Order? Order { get; set; }
public virtual User Customer { get; set; } = null!; public virtual
Product Product { get; set; } = null!; }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Entities/Product.cs
================================================ ﻿using
System.ComponentModel.DataAnnotations; using
System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Core.Entities; public class Product { \[Key\] public
int Id { get; set; }

\[Required\] \[StringLength(200)\] public string Name { get; set; } =
string.Empty;

\[StringLength(1000)\] public string Description { get; set; } =
string.Empty;

\[Required\] \[Column(TypeName = \"decimal(18,2)\")\] public decimal
Price { get; set; }

\[Required\] public int Stock { get; set; }

\[Required\] \[StringLength(100)\] public string Category { get; set; }
= string.Empty;

\[Required\] \[ForeignKey(\"Seller\")\] public int SellerId { get; set;
}

// Navigation property public virtual User Seller { get; set; } = null!;

// Navigation properties public virtual ICollection\<OrderItem\>
OrderItems { get; set; } = new List\<OrderItem\>(); }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Entities/User.cs
================================================ ﻿using
System.ComponentModel.DataAnnotations; using
System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Core.Entities; public class User { \[Key\] public
int Id { get; set; }

\[Required\] \[StringLength(100)\] public string Username { get; set; }
= string.Empty;

\[Required\] \[EmailAddress\] \[StringLength(255)\] public string Email
{ get; set; } = string.Empty;

\[Required\] \[StringLength(255)\] public string PasswordHash { get;
set; } = string.Empty;

\[Required\] \[StringLength(50)\] public string Role { get; set; } =
\"Buyer\";

// Navigation properties public virtual ICollection\<Order\> Orders {
get; set; } = new List\<Order\>(); public virtual ICollection\<Product\>
SoldProducts { get; set; } = new List\<Product\>(); public virtual
ICollection\<OrderItem\> CartItems { get; set; } = new
List\<OrderItem\>(); }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Exceptions/ConflictException.cs
================================================ ﻿

namespace Ecommerce.Core.Exceptions { public class ConflictException :
Exception { //Meaning: The request conflicts with the current state of
the server. //When to throw: When trying to create a resource that
already exists. When handling concurrency issues (e.g., two users
editing the same record). public ConflictException() { }

public ConflictException(string message) : base(message) { }

public ConflictException(string message, Exception innerException) :
base(message, innerException) { } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Exceptions/ForbiddenException.cs
================================================ ﻿

using System; using System.Security;

namespace Ecommerce.Core.Exceptions { public class ForbiddenException :
Exception {

//Meaning: The client is authenticated, but doesn't have permission.

//When to throw:If a normal user tries to perform an admin-only action.
public ForbiddenException() { }

public ForbiddenException(string message) : base(message) { }

public ForbiddenException(string message, Exception innerException) :
base(message, innerException) { } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Exceptions/NotFoundException.cs
================================================ ﻿

namespace Ecommerce.Core.Exceptions { public class NotFoundException :
Exception {

// When trying to fetch, update or delete an object that is not
available public NotFoundException(string message) : base(message) { } }
}

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Exceptions/UnauthorizedException.cs
================================================ ﻿

namespace Ecommerce.Core.Exceptions { public class UnauthorizedException
: Exception {

// Tyring to access data when not logged in or invalid credentials
public UnauthorizedException() { }

public UnauthorizedException(string message) : base(message) { }

public UnauthorizedException(string message, Exception innerException) :
base(message, innerException) { } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Exceptions/ValidationException.cs
================================================ ﻿

namespace Ecommerce.Core.Exceptions { public class ValidationException :
Exception { // password length or when password does not meet business
needs like not using special characters etc.. public
IDictionary\<string, string\> Errors { get; } public
ValidationException(IDictionary\<string, string\> errors) :
base(\"Validation Failed\") { Errors = errors; } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Interfaces/IOrderItemRepository.cs
================================================ ﻿

namespace Ecommerce.Core.Interfaces { public interface
IOrderItemRepository { Task AddAsync(OrderItem orderItem); Task
DeleteAsync(int orderItemId); Task\<IEnumerable\<OrderItem\>\>
GetAllAsync(); Task\<OrderItem?\> GetByIdAsync(int id);
Task\<IEnumerable\<OrderItem\>\> GetByIdsAsync(IEnumerable\<int\> ids);
} }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Interfaces/IOrderItemService.cs
================================================ ﻿using
Ecommerce.Core.DTOs;

namespace Ecommerce.Core.Interfaces { public interface IOrderItemService
{ Task\<OrderItemResponseDTO\> AddOrderItemAsync(OrderItemRequestDTO
dto); Task DeleteOrderItemAsync(int orderId);
Task\<IEnumerable\<OrderItemResponseDTO\>\> GetAllOrderItemsAsync(); } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Interfaces/IOrderRepository.cs
================================================ ﻿

namespace Ecommerce.Core.Interfaces { public interface IOrderRepository
: IRepository\<Order\> {

} }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Interfaces/IOrderService.cs
================================================ ﻿

using Ecommerce.Core.DTOs;

namespace Ecommerce.Core.Interfaces { public interface IOrderService {
Task\<OrderResponseDTO\> AddOrderAsync(OrderRequestDTO user); Task
UpdateOrderAsync(int id, OrderRequestDTO user); Task
DeleteOrderAsync(int id); Task\<List\<OrderResponseDTO\>\>
GetAllOrdersAsync(); Task\<OrderResponseDTO?\> GetOrderByIdAsync(int
id); } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Interfaces/IProductRepository.cs
================================================ ﻿using
Ecommerce.Core.Entities;

namespace Ecommerce.Core.Interfaces { public interface
IProductRepository : IRepository\<Product\> { } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Interfaces/IProductService.cs
================================================ ﻿using
Ecommerce.Core.DTOs;

namespace Ecommerce.Core.Interfaces { public interface IProductService {
Task\<ProductResponseDTO\> AddProductAsync(ProductRequestDTO user); Task
UpdateProductAsync(int id, ProductRequestDTO user); Task
DeleteProductAsync(int id); Task\<List\<ProductResponseDTO\>\>
GetAllProductsAsync(); Task\<ProductResponseDTO?\>
GetProductByIdAsync(int id); } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Interfaces/IRepository.cs
================================================ ﻿namespace
Ecommerce.Core.Interfaces { public interface IRepository\<T\> where T :
class { Task\<IEnumerable\<T\>\> GetAllAsync(); Task\<T?\>
GetByIdAsync(int id); Task AddAsync(T entity); Task UpdateAsync(T
entity); Task DeleteAsync(int id); } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Interfaces/IUserRepository.cs
================================================ ﻿using
Ecommerce.Core.Entities;

namespace Ecommerce.Core.Interfaces { public interface IUserRepository :
IRepository\<User\> { } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Core/Interfaces/IUserService.cs
================================================ ﻿using
Ecommerce.Core.DTOs; using Ecommerce.Core.DTOs.Ecommerce.Core.DTOs;

namespace Ecommerce.Core.Interfaces { public interface IUserService {
Task\<UserResponseDTO\> AddUserAsync(UserRequestDTO user); Task
UpdateUserAsync(int id, UserRequestDTO user); Task DeleteUserAsync(int
id); Task\<List\<UserResponseDTO\>\> GetAllUsersAsync();
Task\<UserResponseDTO?\> GetUserByIdAsync(int id); } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Infrastructure/Class1.cs
================================================ ﻿namespace
Ecommerce.Infrastructure { public class Class1 {

} }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Infrastructure/Ecommerce.Infrastructure.csproj
================================================ ﻿\<Project
Sdk=\"Microsoft.NET.Sdk\"\>

\<PropertyGroup\> \<TargetFramework\>net8.0\</TargetFramework\>
\<ImplicitUsings\>enable\</ImplicitUsings\>
\<Nullable\>enable\</Nullable\> \</PropertyGroup\>

\<ItemGroup\> \<ProjectReference
Include=\"..\\Ecommerce.Core\\Ecommerce.Core.csproj\" /\> \</ItemGroup\>

\<ItemGroup\> \<PackageReference
Include=\"Microsoft.EntityFrameworkCore\" Version=\"9.0.8\" /\>
\<PackageReference Include=\"Microsoft.EntityFrameworkCore.Design\"
Version=\"9.0.8\"\> \<IncludeAssets\>runtime; build; native;
contentfiles; analyzers; buildtransitive\</IncludeAssets\>
\<PrivateAssets\>all\</PrivateAssets\> \</PackageReference\>
\<PackageReference Include=\"Microsoft.EntityFrameworkCore.SqlServer\"
Version=\"9.0.8\" /\> \<PackageReference
Include=\"Microsoft.EntityFrameworkCore.Tools\" Version=\"9.0.8\"\>
\<IncludeAssets\>runtime; build; native; contentfiles; analyzers;
buildtransitive\</IncludeAssets\> \<PrivateAssets\>all\</PrivateAssets\>
\</PackageReference\> \</ItemGroup\>

\</Project\>

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Infrastructure/Data/AppDbContext.cs
================================================ ﻿using
Ecommerce.Core.Entities; using Microsoft.EntityFrameworkCore; using
Microsoft.EntityFrameworkCore.Design; using
Microsoft.Extensions.Configuration; using System; using System.IO;

namespace Ecommerce.Infrastructure.Data { public class AppDbContext :
DbContext { public AppDbContext(DbContextOptions\<AppDbContext\>
options) : base(options) { }

public DbSet\<User\> Users { get; set; } public DbSet\<Product\>
Products { get; set; } public DbSet\<Order\> Orders { get; set; } public
DbSet\<OrderItem\> OrderItems { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder) {
base.OnModelCreating(modelBuilder);

// User configuration modelBuilder.Entity\<User\>(entity =\> {
entity.HasKey(e =\> e.Id); entity.Property(e =\>
e.Username).IsRequired().HasMaxLength(100); entity.Property(e =\>
e.Email).IsRequired().HasMaxLength(255); entity.Property(e =\>
e.PasswordHash).IsRequired().HasMaxLength(255); entity.Property(e =\>
e.Role).IsRequired().HasMaxLength(50);

// Unique constraints entity.HasIndex(e =\> e.Username).IsUnique();
entity.HasIndex(e =\> e.Email).IsUnique(); });

// Product configuration modelBuilder.Entity\<Product\>(entity =\> {
entity.HasKey(e =\> e.Id); entity.Property(e =\>
e.Name).IsRequired().HasMaxLength(200); entity.Property(e =\>
e.Description).HasMaxLength(1000); entity.Property(e =\>
e.Price).HasColumnType(\"decimal(18,2)\"); entity.Property(e =\>
e.Stock).IsRequired(); entity.Property(e =\>
e.Category).IsRequired().HasMaxLength(100);

// Foreign key relationship entity.HasOne(e =\> e.Seller) .WithMany(e
=\> e.SoldProducts) .HasForeignKey(e =\> e.SellerId)
.OnDelete(DeleteBehavior.Restrict); });

// Order configuration modelBuilder.Entity\<Order\>(entity =\> {
entity.HasKey(e =\> e.Id); entity.Property(e =\>
e.OrderDate).IsRequired(); entity.Property(e =\>
e.TotalAmount).HasColumnType(\"decimal(18,2)\"); entity.Property(e =\>
e.Status).IsRequired().HasMaxLength(50);

// Foreign key relationship entity.HasOne(e =\> e.Customer) .WithMany(e
=\> e.Orders) .HasForeignKey(e =\> e.CustomerId)
.OnDelete(DeleteBehavior.Restrict); });

// OrderItem configuration modelBuilder.Entity\<OrderItem\>(entity =\> {
entity.HasKey(e =\> e.Id); entity.Property(e =\>
e.Quantity).IsRequired(); entity.Property(e =\>
e.UnitPrice).HasColumnType(\"decimal(18,2)\");

// Foreign key relationships entity.HasOne(e =\> e.Order) .WithMany(e
=\> e.Items) .HasForeignKey(e =\> e.OrderId)
.OnDelete(DeleteBehavior.Cascade);

entity.HasOne(e =\> e.Customer) .WithMany(e =\> e.CartItems)
.HasForeignKey(e =\> e.CustomerId) .OnDelete(DeleteBehavior.Restrict);

entity.HasOne(e =\> e.Product) .WithMany(e =\> e.OrderItems)
.HasForeignKey(e =\> e.ProductId) .OnDelete(DeleteBehavior.Restrict);
}); } }

public class AppDbContextFactory :
IDesignTimeDbContextFactory\<AppDbContext\> { public AppDbContext
CreateDbContext(string\[\] args) { // Build configuration
IConfigurationRoot configuration = new ConfigurationBuilder()
.SetBasePath(Directory.GetCurrentDirectory()) // This will point to the
Infrastructure folder .AddJsonFile(Path.Combine(\"..\",
\"Ecommerce.API\", \"appsettings.json\"), optional: false,
reloadOnChange: true) .Build();

var optionsBuilder = new DbContextOptionsBuilder\<AppDbContext\>();

var connectionString =
configuration.GetConnectionString(\"EcommerceDB\");
optionsBuilder.UseSqlServer(connectionString);

return new AppDbContext(optionsBuilder.Options); } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Infrastructure/Repositories/OrderItemRepository.cs
================================================ ﻿using
Ecommerce.Core.Entities; using Ecommerce.Core.Interfaces; using
Ecommerce.Infrastructure.Data; using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories { public class
OrderItemRepository : IOrderItemRepository { private readonly
AppDbContext \_context;

public OrderItemRepository(AppDbContext context) { \_context = context;
}

public async Task\<IEnumerable\<OrderItem\>\> GetAllAsync() { return
await \_context.OrderItems .Include(oi =\> oi.Product) .Include(oi =\>
oi.Customer) .Include(oi =\> oi.Order) .ToListAsync(); }

public async Task AddAsync(OrderItem orderItem) { await
\_context.OrderItems.AddAsync(orderItem); await
\_context.SaveChangesAsync(); }

public async Task DeleteAsync(int orderItemId) { var orderItem = await
\_context.OrderItems.FindAsync(orderItemId); if (orderItem != null) {
\_context.OrderItems.Remove(orderItem); await
\_context.SaveChangesAsync(); } }

public async Task\<OrderItem?\> GetByIdAsync(int id) { return await
\_context.OrderItems .Include(oi =\> oi.Product) .Include(oi =\>
oi.Customer) .Include(oi =\> oi.Order) .FirstOrDefaultAsync(oi =\> oi.Id
== id); }

public async Task\<IEnumerable\<OrderItem\>\>
GetByIdsAsync(IEnumerable\<int\> ids) { var set = new
HashSet\<int\>(ids); return await \_context.OrderItems .Include(oi =\>
oi.Product) .Include(oi =\> oi.Customer) .Include(oi =\> oi.Order)
.Where(oi =\> set.Contains(oi.Id)) .ToListAsync(); } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Infrastructure/Repositories/OrderRepository.cs
================================================ ﻿using
Ecommerce.Core.Entities; using Ecommerce.Core.Interfaces; using
Ecommerce.Infrastructure.Data; using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories { public class
OrderRepository : IOrderRepository { private readonly AppDbContext
\_context;

public OrderRepository(AppDbContext context) { \_context = context; }

public async Task\<IEnumerable\<Order\>\> GetAllAsync() { return await
\_context.Orders .Include(o =\> o.Customer) .Include(o =\> o.Items)
.ThenInclude(i =\> i.Product) .ToListAsync(); }

public async Task\<Order?\> GetByIdAsync(int id) { return await
\_context.Orders .Include(o =\> o.Customer) .Include(o =\> o.Items)
.ThenInclude(i =\> i.Product) .FirstOrDefaultAsync(o =\> o.Id == id); }

public async Task AddAsync(Order entity) { await
\_context.Orders.AddAsync(entity); await \_context.SaveChangesAsync(); }

public async Task UpdateAsync(Order entity) {
\_context.Orders.Update(entity); await \_context.SaveChangesAsync(); }

public async Task DeleteAsync(int id) { var order = await
\_context.Orders.FindAsync(id); if (order != null) {
\_context.Orders.Remove(order); await \_context.SaveChangesAsync(); } }
} }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Infrastructure/Repositories/ProductRepository.cs
================================================ ﻿using
Ecommerce.Core.Entities; using Ecommerce.Core.Interfaces; using
Ecommerce.Infrastructure.Data; using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories { public class
ProductRepository : IProductRepository { private readonly AppDbContext
\_context;

public ProductRepository(AppDbContext context) { \_context = context; }

public async Task\<IEnumerable\<Product\>\> GetAllAsync() { return await
\_context.Products.Include(p =\> p.Seller).ToListAsync(); }

public async Task\<Product?\> GetByIdAsync(int id) { return await
\_context.Products.Include(p =\> p.Seller).FirstOrDefaultAsync(p =\>
p.Id == id); }

public async Task AddAsync(Product entity) { await
\_context.Products.AddAsync(entity); await \_context.SaveChangesAsync();
}

public async Task UpdateAsync(Product entity) {
\_context.Products.Update(entity); await \_context.SaveChangesAsync(); }

public async Task DeleteAsync(int id) { var product = await
\_context.Products.FindAsync(id); if (product != null) {
\_context.Products.Remove(product); await \_context.SaveChangesAsync();
} } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Infrastructure/Repositories/UserRepository.cs
================================================ ﻿using
Ecommerce.Core.Entities; using Ecommerce.Core.Interfaces; using
Ecommerce.Infrastructure.Data; using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories { public class
UserRepository : IUserRepository { private readonly AppDbContext
\_context;

public UserRepository(AppDbContext context) { \_context = context; }

public async Task\<IEnumerable\<User\>\> GetAllAsync() { return await
\_context.Users.ToListAsync(); }

public async Task\<User?\> GetByIdAsync(int id) { return await
\_context.Users.FindAsync(id); }

public async Task AddAsync(User entity) { await
\_context.Users.AddAsync(entity); await \_context.SaveChangesAsync(); }

public async Task UpdateAsync(User entity) {
\_context.Users.Update(entity); await \_context.SaveChangesAsync(); }

public async Task DeleteAsync(int id) { var user = await
\_context.Users.FindAsync(id); if (user != null) {
\_context.Users.Remove(user); await \_context.SaveChangesAsync(); } } }
}

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/appsettings.Development.json
================================================ { \"Logging\": {
\"LogLevel\": { \"Default\": \"Information\", \"Microsoft.AspNetCore\":
\"Warning\" } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/appsettings.json
================================================ { \"Logging\": {
\"LogLevel\": { \"Default\": \"Information\", \"Microsoft.AspNetCore\":
\"Warning\" } }, \"AllowedHosts\": \"\*\" }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Ecommerce.MVC.csproj
================================================ ﻿\<Project
Sdk=\"Microsoft.NET.Sdk.Web\"\>

\<PropertyGroup\> \<TargetFramework\>net8.0\</TargetFramework\>
\<Nullable\>enable\</Nullable\>
\<ImplicitUsings\>enable\</ImplicitUsings\> \</PropertyGroup\>

\<ItemGroup\> \<ProjectReference
Include=\"..\\Ecommerce.API\\Ecommerce.API.csproj\" /\>
\<ProjectReference
Include=\"..\\Ecommerce.Application\\Ecommerce.Application.csproj\" /\>
\<ProjectReference Include=\"..\\Ecommerce.Core\\Ecommerce.Core.csproj\"
/\> \<ProjectReference
Include=\"..\\Ecommerce.Infrastructure\\Ecommerce.Infrastructure.csproj\"
/\> \</ItemGroup\>

\</Project\>

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Program.cs
================================================ var builder =
WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient(\"EcommerceAPI\", client =\> {
client.BaseAddress = new Uri(\"https://localhost:7124/\"); });

var app = builder.Build();

// Configure the HTTP request pipeline. if
(!app.Environment.IsDevelopment()) {
app.UseExceptionHandler(\"/Home/Error\"); // The default HSTS value is
30 days. You may want to change this for production scenarios, see
https://aka.ms/aspnetcore-hsts. app.UseHsts(); }

app.UseHttpsRedirection(); app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute( name: \"default\", pattern:
\"{controller=Home}/{action=Index}/{id?}\");

app.Run();

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Controllers/HomeController.cs
================================================ using
Ecommerce.MVC.Models; using Microsoft.AspNetCore.Mvc; using
System.Diagnostics;

namespace Ecommerce.MVC.Controllers { public class HomeController :
Controller { private readonly ILogger\<HomeController\> \_logger;

public HomeController(ILogger\<HomeController\> logger) { \_logger =
logger; }

public IActionResult Index() { return View(); }

public IActionResult Privacy() { return View(); }

\[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None,
NoStore = true)\] public IActionResult Error() { return View(new
ErrorViewModel { RequestId = Activity.Current?.Id ??
HttpContext.TraceIdentifier }); } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Controllers/UserViewController.cs
================================================ ﻿using
Ecommerce.MVC.Models; using Microsoft.AspNetCore.Mvc; using
System.Net.Http.Json;

namespace Ecommerce.MVC.Controllers { public class UserViewController :
Controller { private readonly HttpClient \_httpClient;

public UserViewController(IHttpClientFactory httpClientFactory) {
\_httpClient = httpClientFactory.CreateClient(\"EcommerceAPI\"); }

// GET: /UserView/ public async Task\<IActionResult\> Index() { var
users = await
\_httpClient.GetFromJsonAsync\<List\<UserViewModel\>\>(\"api/User\");
return View(users); }

// GET: /UserView/Details/5 public async Task\<IActionResult\>
Details(int id) { var user = await
\_httpClient.GetFromJsonAsync\<UserViewModel\>(\$\"api/User/{id}\"); if
(user == null) return NotFound();

return View(user); }

// GET: /UserView/Edit/5 public async Task\<IActionResult\> Edit(int id)
{ var user = await
\_httpClient.GetFromJsonAsync\<UserViewModel\>(\$\"api/User/{id}\"); if
(user == null) return NotFound();

return View(user); }

// POST: /UserView/Edit/5 \[HttpPost\] \[ValidateAntiForgeryToken\]
public async Task\<IActionResult\> Edit(int id, UserViewModel model) {
if (!ModelState.IsValid) return View(model);

var response = await \_httpClient.PutAsJsonAsync(\$\"api/User/{id}\",
model); if (response.IsSuccessStatusCode) return
RedirectToAction(nameof(Index));

if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return
NotFound();

ModelState.AddModelError(string.Empty, \"Unable to update user.\");
return View(model); }

// GET: /UserView/Delete/5 public async Task\<IActionResult\> Delete(int
id) { var user = await
\_httpClient.GetFromJsonAsync\<UserViewModel\>(\$\"api/User/{id}\"); if
(user == null) return NotFound();

return View(user); }

// POST: /UserView/Delete/5 \[HttpPost, ActionName(\"Delete\")\]
\[ValidateAntiForgeryToken\] public async Task\<IActionResult\>
DeleteConfirmed(int id) { var response = await
\_httpClient.DeleteAsync(\$\"api/User/{id}\"); if
(response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));

if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return
NotFound();

ModelState.AddModelError(string.Empty, \"Unable to delete user.\");
return RedirectToAction(nameof(Delete), new { id }); }

// Optional: GET and POST for Create public IActionResult Create() =\>
View();

\[HttpPost\] \[ValidateAntiForgeryToken\] public async
Task\<IActionResult\> Create(UserViewModel model) { if
(!ModelState.IsValid) return View(model);

var response = await \_httpClient.PostAsJsonAsync(\"api/User\", model);
if (response.IsSuccessStatusCode) return
RedirectToAction(nameof(Index));

ModelState.AddModelError(string.Empty, \"Unable to create user.\");
return View(model); } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Models/ErrorViewModel.cs
================================================ namespace
Ecommerce.MVC.Models { public class ErrorViewModel { public string?
RequestId { get; set; }

public bool ShowRequestId =\> !string.IsNullOrEmpty(RequestId); } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Models/UserViewModel.cs
================================================ ﻿using
Ecommerce.Core.DTOs;

namespace Ecommerce.MVC.Models { public class UserViewModel { public int
Id { get; set; } public string Username { get; set; } = string.Empty;
public string Email { get; set; } = string.Empty; public string Role {
get; set; } = \"Buyer\";

// For Buyers → Orders they placed public List\<OrderSummaryDTO\>?
Orders { get; set; }

// For Buyers → Products they bought public List\<ProductSummaryDTO\>?
BoughtProducts { get; set; }

// For Sellers → Products they listed public List\<ProductSummaryDTO\>?
SoldProducts { get; set; } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Properties/launchSettings.json
================================================ ﻿{ \"\$schema\":
\"http://json.schemastore.org/launchsettings.json\", \"iisSettings\": {
\"windowsAuthentication\": false, \"anonymousAuthentication\": true,
\"iisExpress\": { \"applicationUrl\": \"http://localhost:30097\",
\"sslPort\": 44390 } }, \"profiles\": { \"http\": { \"commandName\":
\"Project\", \"dotnetRunMessages\": true, \"launchBrowser\": true,
\"applicationUrl\": \"http://localhost:5287\", \"environmentVariables\":
{ \"ASPNETCORE_ENVIRONMENT\": \"Development\" } }, \"https\": {
\"commandName\": \"Project\", \"dotnetRunMessages\": true,
\"launchBrowser\": true, \"applicationUrl\":
\"https://localhost:7097;http://localhost:5287\",
\"environmentVariables\": { \"ASPNETCORE_ENVIRONMENT\": \"Development\"
} }, \"IIS Express\": { \"commandName\": \"IISExpress\",
\"launchBrowser\": true, \"environmentVariables\": {
\"ASPNETCORE_ENVIRONMENT\": \"Development\" } } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Views/\_ViewImports.cshtml
================================================ ﻿@using Ecommerce.MVC
\@using Ecommerce.MVC.Models \@addTagHelper \*,
Microsoft.AspNetCore.Mvc.TagHelpers

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Views/\_ViewStart.cshtml
================================================ ﻿@{ Layout =
\"\_Layout\"; }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Views/Home/Index.cshtml
================================================ ﻿@{
ViewData\[\"Title\"\] = \"Home Page\"; }

\<div class=\"text-center\"\> \<h1 class=\"display-4\"\>Welcome\</h1\>
\<p\>Learn about \<a
href=\"https://learn.microsoft.com/aspnet/core\"\>building Web apps with
ASP.NET Core\</a\>.\</p\> \</div\>

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Views/Home/Privacy.cshtml
================================================ ﻿@{
ViewData\[\"Title\"\] = \"Privacy Policy\"; }
\<h1\>@ViewData\[\"Title\"\]\</h1\>

\<p\>Use this page to detail your site\'s privacy policy.\</p\>

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Views/Shared/\_Layout.cshtml
================================================ ﻿\<!DOCTYPE html\>
\<html lang=\"en\"\> \<head\> \<meta charset=\"utf-8\" /\> \<meta
name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" /\>
\<title\>@ViewData\[\"Title\"\] - Ecommerce.MVC\</title\> \<link
rel=\"stylesheet\" href=\"\~/lib/bootstrap/dist/css/bootstrap.min.css\"
/\> \<link rel=\"stylesheet\" href=\"\~/css/site.css\"
asp-append-version=\"true\" /\> \<link rel=\"stylesheet\"
href=\"\~/Ecommerce.MVC.styles.css\" asp-append-version=\"true\" /\>
\</head\> \<body\> \<header\> \<nav class=\"navbar navbar-expand-sm
navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow
mb-3\"\> \<div class=\"container-fluid\"\> \<a class=\"navbar-brand\"
asp-area=\"\" asp-controller=\"Home\"
asp-action=\"Index\"\>Ecommerce.MVC\</a\> \<button
class=\"navbar-toggler\" type=\"button\" data-bs-toggle=\"collapse\"
data-bs-target=\".navbar-collapse\"
aria-controls=\"navbarSupportedContent\" aria-expanded=\"false\"
aria-label=\"Toggle navigation\"\> \<span
class=\"navbar-toggler-icon\"\>\</span\> \</button\> \<div
class=\"navbar-collapse collapse d-sm-inline-flex
justify-content-between\"\> \<ul class=\"navbar-nav flex-grow-1\"\> \<li
class=\"nav-item\"\> \<a class=\"nav-link text-dark\" asp-area=\"\"
asp-controller=\"Home\" asp-action=\"Index\"\>Home\</a\> \</li\> \<li
class=\"nav-item\"\> \<a class=\"nav-link text-dark\" asp-area=\"\"
asp-controller=\"Home\" asp-action=\"Privacy\"\>Privacy\</a\> \</li\>
\</ul\> \</div\> \</div\> \</nav\> \</header\> \<div
class=\"container\"\> \<main role=\"main\" class=\"pb-3\"\>
\@RenderBody() \</main\> \</div\>

\<footer class=\"border-top footer text-muted\"\> \<div
class=\"container\"\> &copy; 2025 - Ecommerce.MVC - \<a asp-area=\"\"
asp-controller=\"Home\" asp-action=\"Privacy\"\>Privacy\</a\> \</div\>
\</footer\> \<script
src=\"\~/lib/jquery/dist/jquery.min.js\"\>\</script\> \<script
src=\"\~/lib/bootstrap/dist/js/bootstrap.bundle.min.js\"\>\</script\>
\<script src=\"\~/js/site.js\" asp-append-version=\"true\"\>\</script\>
\@await RenderSectionAsync(\"Scripts\", required: false) \</body\>
\</html\>

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Views/Shared/\_Layout.cshtml.css
================================================ ﻿/\* Please see
documentation at
https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
for details on configuring this project to bundle and minify static web
assets. \*/

a.navbar-brand { white-space: normal; text-align: center; word-break:
break-all; }

a { color: #0077cc; }

.btn-primary { color: #fff; background-color: #1b6ec2; border-color:
#1861ac; }

.nav-pills .nav-link.active, .nav-pills .show \> .nav-link { color:
#fff; background-color: #1b6ec2; border-color: #1861ac; }

.border-top { border-top: 1px solid #e5e5e5; } .border-bottom {
border-bottom: 1px solid #e5e5e5; }

.box-shadow { box-shadow: 0 .25rem .75rem rgba(0, 0, 0, .05); }

button.accept-policy { font-size: 1rem; line-height: inherit; }

.footer { position: absolute; bottom: 0; width: 100%; white-space:
nowrap; line-height: 60px; }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Views/Shared/\_ValidationScriptsPartial.cshtml
================================================ ﻿\<script
src=\"\~/lib/jquery-validation/dist/jquery.validate.min.js\"\>\</script\>
\<script
src=\"\~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js\"\>\</script\>

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Views/Shared/Error.cshtml
================================================ ﻿@model ErrorViewModel
\@{ ViewData\[\"Title\"\] = \"Error\"; }

\<h1 class=\"text-danger\"\>Error.\</h1\> \<h2 class=\"text-danger\"\>An
error occurred while processing your request.\</h2\>

\@if (Model.ShowRequestId) { \<p\> \<strong\>Request ID:\</strong\>
\<code\>@Model.RequestId\</code\> \</p\> }

\<h3\>Development Mode\</h3\> \<p\> Swapping to
\<strong\>Development\</strong\> environment will display more detailed
information about the error that occurred. \</p\> \<p\> \<strong\>The
Development environment shouldn\'t be enabled for deployed
applications.\</strong\> It can result in displaying sensitive
information from exceptions to end users. For local debugging, enable
the \<strong\>Development\</strong\> environment by setting the
\<strong\>ASPNETCORE_ENVIRONMENT\</strong\> environment variable to
\<strong\>Development\</strong\> and restarting the app. \</p\>

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Views/UserView/Create.cshtml
================================================ ﻿@model
Ecommerce.MVC.Models.UserViewModel

\@{ ViewData\[\"Title\"\] = \"Create Event\"; }

\<h2\>Create Event\</h2\>

\<form asp-action=\"Create\" method=\"post\"\> \<div
class=\"form-group\"\> \<label asp-for=\"Title\"
class=\"control-label\"\>\</label\> \<input asp-for=\"Title\"
class=\"form-control\" /\> \<span asp-validation-for=\"Title\"
class=\"text-danger\"\>\</span\> \</div\>

\<div class=\"form-group\"\> \<label asp-for=\"Desc\"
class=\"control-label\"\>\</label\> \<input asp-for=\"Desc\"
class=\"form-control\" /\> \<span asp-validation-for=\"Desc\"
class=\"text-danger\"\>\</span\> \</div\>

\<div class=\"form-group\"\> \<label asp-for=\"EventDate\"
class=\"control-label\"\>\</label\> \<input asp-for=\"EventDate\"
class=\"form-control\" type=\"date\" /\> \<span
asp-validation-for=\"EventDate\" class=\"text-danger\"\>\</span\>
\</div\>

\<div class=\"form-group\"\> \<label asp-for=\"Location\"
class=\"control-label\"\>\</label\> \<input asp-for=\"Location\"
class=\"form-control\" /\> \<span asp-validation-for=\"Location\"
class=\"text-danger\"\>\</span\> \</div\>

\<button type=\"submit\" class=\"btn btn-primary\"\>Create\</button\>
\<a asp-action=\"Index\" class=\"btn btn-secondary\"\>Back to List\</a\>
\</form\>

\@section Scripts { \@{ await
Html.RenderPartialAsync(\"\_ValidationScriptsPartial\"); } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Views/UserView/Delete.cshtml
================================================ ﻿@model
Ecommerce.MVC.Models.UserViewModel

\@{ ViewData\[\"Title\"\] = \"Delete User\"; }

\<h2\>Delete User\</h2\>

\<h4\>Are you sure you want to delete this user?\</h4\> \<hr /\>

\<dl class=\"row\"\> \<dt class=\"col-sm-2\"\>ID\</dt\> \<dd
class=\"col-sm-10\"\>@Model.Id\</dd\>

\<dt class=\"col-sm-2\"\>Username\</dt\> \<dd
class=\"col-sm-10\"\>@Model.Username\</dd\>

\<dt class=\"col-sm-2\"\>Email\</dt\> \<dd
class=\"col-sm-10\"\>@Model.Email\</dd\>

\<dt class=\"col-sm-2\"\>Role\</dt\> \<dd
class=\"col-sm-10\"\>@Model.Role\</dd\> \</dl\>

\<form asp-action=\"Delete\" method=\"post\"\> \<input type=\"hidden\"
asp-for=\"Id\" /\> \<button type=\"submit\" class=\"btn
btn-danger\"\>Delete\</button\> \<a asp-action=\"Index\" class=\"btn
btn-secondary\"\>Cancel\</a\> \</form\>

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Views/UserView/Details.cshtml
================================================ ﻿@model
Ecommerce.MVC.Models.UserViewModel

\@{ ViewData\[\"Title\"\] = \"User Details\"; }

\<h2\>User Details\</h2\>

\<dl class=\"row\"\> \<dt class=\"col-sm-2\"\>User ID\</dt\> \<dd
class=\"col-sm-10\"\>@Model.Id\</dd\>

\<dt class=\"col-sm-2\"\>Username\</dt\> \<dd
class=\"col-sm-10\"\>@Model.Username\</dd\>

\<dt class=\"col-sm-2\"\>Email\</dt\> \<dd
class=\"col-sm-10\"\>@Model.Email\</dd\>

\<dt class=\"col-sm-2\"\>Role\</dt\> \<dd
class=\"col-sm-10\"\>@Model.Role\</dd\>

\<dt class=\"col-sm-2\"\>Orders\</dt\> \<dd class=\"col-sm-10\"\> \@if
(Model.Orders != null && Model.Orders.Any()) { \<ul\> \@foreach (var
order in Model.Orders) { \<li\>@order.Id - \@order.TotalAmount\</li\> }
\</ul\> } else { \<p\>No orders placed.\</p\> } \</dd\>

\<dt class=\"col-sm-2\"\>Bought Products\</dt\> \<dd
class=\"col-sm-10\"\> \@if (Model.BoughtProducts != null &&
Model.BoughtProducts.Any()) { \<ul\> \@foreach (var product in
Model.BoughtProducts) { \<li\>@product.Name - \@product.Price\</li\> }
\</ul\> } else { \<p\>No products bought.\</p\> } \</dd\>

\<dt class=\"col-sm-2\"\>Sold Products\</dt\> \<dd class=\"col-sm-10\"\>
\@if (Model.SoldProducts != null && Model.SoldProducts.Any()) { \<ul\>
\@foreach (var product in Model.SoldProducts) { \<li\>@product.Name -
\@product.Price\</li\> } \</ul\> } else { \<p\>No products sold.\</p\> }
\</dd\> \</dl\>

\<p\> \<a asp-action=\"Index\" class=\"btn btn-secondary\"\>Back to
List\</a\> \</p\>

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Views/UserView/Edit.cshtml
================================================ ﻿@model
Ecommerce.MVC.Models.UserViewModel

\@{ ViewData\[\"Title\"\] = \"Edit User\"; }

\<h2\>Edit User\</h2\>

\<form asp-action=\"Edit\" method=\"post\"\> \<input type=\"hidden\"
asp-for=\"Id\" /\>

\<div class=\"form-group\"\> \<label asp-for=\"Username\"
class=\"control-label\"\>\</label\> \<input asp-for=\"Username\"
class=\"form-control\" /\> \<span asp-validation-for=\"Username\"
class=\"text-danger\"\>\</span\> \</div\>

\<div class=\"form-group\"\> \<label asp-for=\"Email\"
class=\"control-label\"\>\</label\> \<input asp-for=\"Email\"
class=\"form-control\" /\> \<span asp-validation-for=\"Email\"
class=\"text-danger\"\>\</span\> \</div\>

\<div class=\"form-group\"\> \<label asp-for=\"Role\"
class=\"control-label\"\>\</label\> \<input asp-for=\"Role\"
class=\"form-control\" /\> \<span asp-validation-for=\"Role\"
class=\"text-danger\"\>\</span\> \</div\>

\<button type=\"submit\" class=\"btn btn-primary\"\>Save\</button\> \<a
asp-action=\"Index\" class=\"btn btn-secondary\"\>Back to List\</a\>
\</form\>

\@section Scripts { \@await
Html.PartialAsync(\"\_ValidationScriptsPartial\") }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/Views/UserView/Index.cshtml
================================================ ﻿@model
IEnumerable\<Ecommerce.MVC.Models.UserViewModel\>

\@{ ViewData\[\"Title\"\] = \"Users\"; }

\<h2\>User List\</h2\>

\<table class=\"table table-striped\"\> \<thead\> \<tr\> \<th\>User
Id\</th\> \<th\>Username\</th\> \<th\>Email\</th\> \<th\>Role\</th\>
\<th\>Orders\</th\> \<th\>Bought Products\</th\> \<th\>Sold
Products\</th\> \<th\>\</th\> \</tr\> \</thead\> \<tbody\> \@if
(!Model.Any()) { \<tr\> \<td colspan=\"8\" class=\"text-center\"\>No
Users Found\</td\> \</tr\> } else { foreach (var user in Model) { \<tr\>
\<td\>@user.Id\</td\> \<td\>@user.Username\</td\>
\<td\>@user.Email\</td\> \<td\>@user.Role\</td\> \<td\>@(user.Orders !=
null ? user.Orders.Count : 0)\</td\> \<td\>@(user.BoughtProducts != null
? user.BoughtProducts.Count : 0)\</td\> \<td\>@(user.SoldProducts !=
null ? user.SoldProducts.Count : 0)\</td\> \<td\> \<a
asp-action=\"Details\" asp-route-id=\"@user.Id\"\>View\</a\> \| \<a
asp-action=\"Edit\" asp-route-id=\"@user.Id\"\>Edit\</a\> \| \<a
asp-action=\"Delete\" asp-route-id=\"@user.Id\"\>Delete\</a\> \</td\>
\</tr\> } } \</tbody\> \</table\>

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/wwwroot/css/site.css
================================================ html { font-size: 14px;
}

\@media (min-width: 768px) { html { font-size: 16px; } }

.btn:focus, .btn:active:focus, .btn-link.nav-link:focus,
.form-control:focus, .form-check-input:focus { box-shadow: 0 0 0 0.1rem
white, 0 0 0 0.25rem #258cfb; }

html { position: relative; min-height: 100%; }

body { margin-bottom: 60px; }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/wwwroot/js/site.js
================================================ ﻿// Please see
documentation at
https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static
web assets.

// Write your JavaScript code.

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/wwwroot/lib/bootstrap/LICENSE
================================================ The MIT License (MIT)

Copyright (c) 2011-2021 Twitter, Inc. Copyright (c) 2011-2021 The
Bootstrap Authors

Permission is hereby granted, free of charge, to any person obtaining a
copy of this software and associated documentation files (the
\"Software\"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be included
in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/wwwroot/lib/jquery/LICENSE.txt
================================================

Copyright OpenJS Foundation and other contributors, https://openjsf.org/

Permission is hereby granted, free of charge, to any person obtaining a
copy of this software and associated documentation files (the
\"Software\"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be included
in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/wwwroot/lib/jquery-validation/LICENSE.md
================================================ The MIT License (MIT)
=====================

Copyright Jörn Zaefferer

Permission is hereby granted, free of charge, to any person obtaining a
copy of this software and associated documentation files (the
\"Software\"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be included
in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/wwwroot/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js
================================================ /\*\* \* \@license \*
Unobtrusive validation support library for jQuery and jQuery Validate \*
Copyright (c) .NET Foundation. All rights reserved. \* Licensed under
the Apache License, Version 2.0. See License.txt in the project root for
license information. \* \@version v4.0.0 \*/

/\*jslint white: true, browser: true, onevar: true, undef: true, nomen:
true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, newcap:
true, immed: true, strict: false \*/ /\*global document: false, jQuery:
false \*/

(function (factory) { if (typeof define === \'function\' && define.amd)
{ // AMD. Register as an anonymous module.
define(\"jquery.validate.unobtrusive\", \[\'jquery-validation\'\],
factory); } else if (typeof module === \'object\' && module.exports) {
// CommonJS-like environments that support module.exports module.exports
= factory(require(\'jquery-validation\')); } else { // Browser global
jQuery.validator.unobtrusive = factory(jQuery); } }(function (\$) { var
\$jQval = \$.validator, adapters, data_validation =
\"unobtrusiveValidation\";

function setValidationValues(options, ruleName, value) {
options.rules\[ruleName\] = value; if (options.message) {
options.messages\[ruleName\] = options.message; } }

function splitAndTrim(value) { return value.replace(/\^\\s+\|\\s+\$/g,
\"\").split(/\\s\*,\\s\*/g); }

function escapeAttributeValue(value) { // As mentioned on
http://api.jquery.com/category/selectors/ return
value.replace(/(\[!\"#\$%&\'()\*+,./:;\<=\>?@\\\[\\\\\\\]\^\`{\|}\~\])/g,
\"\\\\\$1\"); }

function getModelPrefix(fieldName) { return fieldName.substr(0,
fieldName.lastIndexOf(\".\") + 1); }

function appendModelPrefix(value, prefix) { if (value.indexOf(\"\*.\")
=== 0) { value = value.replace(\"\*.\", prefix); } return value; }

function onError(error, inputElement) { // \'this\' is the form element
var container = \$(this).find(\"\[data-valmsg-for=\'\" +
escapeAttributeValue(inputElement\[0\].name) + \"\'\]\"),
replaceAttrValue = container.attr(\"data-valmsg-replace\"), replace =
replaceAttrValue ? \$.parseJSON(replaceAttrValue) !== false : null;

container.removeClass(\"field-validation-valid\").addClass(\"field-validation-error\");
error.data(\"unobtrusiveContainer\", container);

if (replace) { container.empty();
error.removeClass(\"input-validation-error\").appendTo(container); }
else { error.hide(); } }

function onErrors(event, validator) { // \'this\' is the form element
var container = \$(this).find(\"\[data-valmsg-summary=true\]\"), list =
container.find(\"ul\");

if (list && list.length && validator.errorList.length) { list.empty();
container.addClass(\"validation-summary-errors\").removeClass(\"validation-summary-valid\");

\$.each(validator.errorList, function () { \$(\"\<li
/\>\").html(this.message).appendTo(list); }); } }

function onSuccess(error) { // \'this\' is the form element var
container = error.data(\"unobtrusiveContainer\");

if (container) { var replaceAttrValue =
container.attr(\"data-valmsg-replace\"), replace = replaceAttrValue ?
\$.parseJSON(replaceAttrValue) : null;

container.addClass(\"field-validation-valid\").removeClass(\"field-validation-error\");
error.removeData(\"unobtrusiveContainer\");

if (replace) { container.empty(); } } }

function onReset(event) { // \'this\' is the form element var \$form =
\$(this), key = \'\_\_jquery_unobtrusive_validation_form_reset\'; if
(\$form.data(key)) { return; } // Set a flag that indicates we\'re
currently resetting the form. \$form.data(key, true); try {
\$form.data(\"validator\").resetForm(); } finally {
\$form.removeData(key); }

\$form.find(\".validation-summary-errors\")
.addClass(\"validation-summary-valid\")
.removeClass(\"validation-summary-errors\");
\$form.find(\".field-validation-error\")
.addClass(\"field-validation-valid\")
.removeClass(\"field-validation-error\")
.removeData(\"unobtrusiveContainer\") .find(\"\>\*\") // If we were
using valmsg-replace, get the underlying error
.removeData(\"unobtrusiveContainer\"); }

function validationInfo(form) { var \$form = \$(form), result =
\$form.data(data_validation), onResetProxy = \$.proxy(onReset, form),
defaultOptions = \$jQval.unobtrusive.options \|\| {}, execInContext =
function (name, args) { var func = defaultOptions\[name\]; func &&
\$.isFunction(func) && func.apply(form, args); };

if (!result) { result = { options: { // options structure passed to
jQuery Validate\'s validate() method errorClass:
defaultOptions.errorClass \|\| \"input-validation-error\", errorElement:
defaultOptions.errorElement \|\| \"span\", errorPlacement: function () {
onError.apply(form, arguments); execInContext(\"errorPlacement\",
arguments); }, invalidHandler: function () { onErrors.apply(form,
arguments); execInContext(\"invalidHandler\", arguments); }, messages:
{}, rules: {}, success: function () { onSuccess.apply(form, arguments);
execInContext(\"success\", arguments); } }, attachValidation: function
() { \$form .off(\"reset.\" + data_validation, onResetProxy)
.on(\"reset.\" + data_validation, onResetProxy) .validate(this.options);
}, validate: function () { // a validation function that is called by
unobtrusive Ajax \$form.validate(); return \$form.valid(); } };
\$form.data(data_validation, result); }

return result; }

\$jQval.unobtrusive = { adapters: \[\],

parseElement: function (element, skipAttach) { /// \<summary\> ///
Parses a single HTML element for unobtrusive validation attributes. ///
\</summary\> /// \<param name=\"element\" domElement=\"true\"\>The HTML
element to be parsed.\</param\> /// \<param name=\"skipAttach\"
type=\"Boolean\"\>\[Optional\] true to skip attaching the /// validation
to the form. If parsing just this single element, you should specify
true. /// If parsing several elements, you should specify false, and
manually attach the validation /// to the form when you are finished.
The default is false.\</param\> var \$element = \$(element), form =
\$element.parents(\"form\")\[0\], valInfo, rules, messages;

if (!form) { // Cannot do client-side validation without a form return;
}

valInfo = validationInfo(form); valInfo.options.rules\[element.name\] =
rules = {}; valInfo.options.messages\[element.name\] = messages = {};

\$.each(this.adapters, function () { var prefix = \"data-val-\" +
this.name, message = \$element.attr(prefix), paramValues = {};

if (message !== undefined) { // Compare against undefined, because an
empty message is legal (and falsy) prefix += \"-\";

\$.each(this.params, function () { paramValues\[this\] =
\$element.attr(prefix + this); });

this.adapt({ element: element, form: form, message: message, params:
paramValues, rules: rules, messages: messages }); } });

\$.extend(rules, { \"\_\_dummy\_\_\": true });

if (!skipAttach) { valInfo.attachValidation(); } },

parse: function (selector) { /// \<summary\> /// Parses all the HTML
elements in the specified selector. It looks for input elements
decorated /// with the \[data-val=true\] attribute value and enables
validation according to the data-val-\* /// attribute values. ///
\</summary\> /// \<param name=\"selector\" type=\"String\"\>Any valid
jQuery selector.\</param\>

// \$forms includes all forms in selector\'s DOM hierarchy (parent,
children and self) that have at least one // element with data-val=true
var \$selector = \$(selector), \$forms = \$selector.parents() .addBack()
.filter(\"form\") .add(\$selector.find(\"form\"))
.has(\"\[data-val=true\]\");

\$selector.find(\"\[data-val=true\]\").each(function () {
\$jQval.unobtrusive.parseElement(this, true); });

\$forms.each(function () { var info = validationInfo(this); if (info) {
info.attachValidation(); } }); } };

adapters = \$jQval.unobtrusive.adapters;

adapters.add = function (adapterName, params, fn) { /// \<summary\>Adds
a new adapter to convert unobtrusive HTML into a jQuery Validate
validation.\</summary\> /// \<param name=\"adapterName\"
type=\"String\"\>The name of the adapter to be added. This matches the
name used /// in the data-val-nnnn HTML attribute (where nnnn is the
adapter name).\</param\> /// \<param name=\"params\" type=\"Array\"
optional=\"true\"\>\[Optional\] An array of parameter names (strings)
that will /// be extracted from the data-val-nnnn-mmmm HTML attributes
(where nnnn is the adapter name, and /// mmmm is the parameter
name).\</param\> /// \<param name=\"fn\" type=\"Function\"\>The function
to call, which adapts the values from the HTML /// attributes into
jQuery Validate rules and/or messages.\</param\> /// \<returns
type=\"jQuery.validator.unobtrusive.adapters\" /\> if (!fn) { // Called
with no params, just a function fn = params; params = \[\]; }
this.push({ name: adapterName, params: params, adapt: fn }); return
this; };

adapters.addBool = function (adapterName, ruleName) { ///
\<summary\>Adds a new adapter to convert unobtrusive HTML into a jQuery
Validate validation, where /// the jQuery Validate validation rule has
no parameter values.\</summary\> /// \<param name=\"adapterName\"
type=\"String\"\>The name of the adapter to be added. This matches the
name used /// in the data-val-nnnn HTML attribute (where nnnn is the
adapter name).\</param\> /// \<param name=\"ruleName\" type=\"String\"
optional=\"true\"\>\[Optional\] The name of the jQuery Validate rule. If
not provided, the value /// of adapterName will be used
instead.\</param\> /// \<returns
type=\"jQuery.validator.unobtrusive.adapters\" /\> return
this.add(adapterName, function (options) { setValidationValues(options,
ruleName \|\| adapterName, true); }); };

adapters.addMinMax = function (adapterName, minRuleName, maxRuleName,
minMaxRuleName, minAttribute, maxAttribute) { /// \<summary\>Adds a new
adapter to convert unobtrusive HTML into a jQuery Validate validation,
where /// the jQuery Validate validation has three potential rules (one
for min-only, one for max-only, and /// one for min-and-max). The HTML
parameters are expected to be named -min and -max.\</summary\> ///
\<param name=\"adapterName\" type=\"String\"\>The name of the adapter to
be added. This matches the name used /// in the data-val-nnnn HTML
attribute (where nnnn is the adapter name).\</param\> /// \<param
name=\"minRuleName\" type=\"String\"\>The name of the jQuery Validate
rule to be used when you only /// have a minimum value.\</param\> ///
\<param name=\"maxRuleName\" type=\"String\"\>The name of the jQuery
Validate rule to be used when you only /// have a maximum
value.\</param\> /// \<param name=\"minMaxRuleName\"
type=\"String\"\>The name of the jQuery Validate rule to be used when
you /// have both a minimum and maximum value.\</param\> /// \<param
name=\"minAttribute\" type=\"String\" optional=\"true\"\>\[Optional\]
The name of the HTML attribute that /// contains the minimum value. The
default is \"min\".\</param\> /// \<param name=\"maxAttribute\"
type=\"String\" optional=\"true\"\>\[Optional\] The name of the HTML
attribute that /// contains the maximum value. The default is
\"max\".\</param\> /// \<returns
type=\"jQuery.validator.unobtrusive.adapters\" /\> return
this.add(adapterName, \[minAttribute \|\| \"min\", maxAttribute \|\|
\"max\"\], function (options) { var min = options.params.min, max =
options.params.max;

if (min && max) { setValidationValues(options, minMaxRuleName, \[min,
max\]); } else if (min) { setValidationValues(options, minRuleName,
min); } else if (max) { setValidationValues(options, maxRuleName, max);
} }); };

adapters.addSingleVal = function (adapterName, attribute, ruleName) {
/// \<summary\>Adds a new adapter to convert unobtrusive HTML into a
jQuery Validate validation, where /// the jQuery Validate validation
rule has a single value.\</summary\> /// \<param name=\"adapterName\"
type=\"String\"\>The name of the adapter to be added. This matches the
name used /// in the data-val-nnnn HTML attribute(where nnnn is the
adapter name).\</param\> /// \<param name=\"attribute\"
type=\"String\"\>\[Optional\] The name of the HTML attribute that
contains the value. /// The default is \"val\".\</param\> /// \<param
name=\"ruleName\" type=\"String\" optional=\"true\"\>\[Optional\] The
name of the jQuery Validate rule. If not provided, the value /// of
adapterName will be used instead.\</param\> /// \<returns
type=\"jQuery.validator.unobtrusive.adapters\" /\> return
this.add(adapterName, \[attribute \|\| \"val\"\], function (options) {
setValidationValues(options, ruleName \|\| adapterName,
options.params\[attribute\]); }); };

\$jQval.addMethod(\"\_\_dummy\_\_\", function (value, element, params) {
return true; });

\$jQval.addMethod(\"regex\", function (value, element, params) { var
match; if (this.optional(element)) { return true; }

match = new RegExp(params).exec(value); return (match && (match.index
=== 0) && (match\[0\].length === value.length)); });

\$jQval.addMethod(\"nonalphamin\", function (value, element,
nonalphamin) { var match; if (nonalphamin) { match =
value.match(/\\W/g); match = match && match.length \>= nonalphamin; }
return match; });

if (\$jQval.methods.extension) { adapters.addSingleVal(\"accept\",
\"mimtype\"); adapters.addSingleVal(\"extension\", \"extension\"); }
else { // for backward compatibility, when the \'extension\' validation
method does not exist, such as with versions // of JQuery Validation
plugin prior to 1.10, we should use the \'accept\' method for //
validating the extension, and ignore mime-type validations as they are
not supported. adapters.addSingleVal(\"extension\", \"extension\",
\"accept\"); }

adapters.addSingleVal(\"regex\", \"pattern\");
adapters.addBool(\"creditcard\").addBool(\"date\").addBool(\"digits\").addBool(\"email\").addBool(\"number\").addBool(\"url\");
adapters.addMinMax(\"length\", \"minlength\", \"maxlength\",
\"rangelength\").addMinMax(\"range\", \"min\", \"max\", \"range\");
adapters.addMinMax(\"minlength\",
\"minlength\").addMinMax(\"maxlength\", \"minlength\", \"maxlength\");
adapters.add(\"equalto\", \[\"other\"\], function (options) { var prefix
= getModelPrefix(options.element.name), other = options.params.other,
fullOtherName = appendModelPrefix(other, prefix), element =
\$(options.form).find(\":input\").filter(\"\[name=\'\" +
escapeAttributeValue(fullOtherName) + \"\'\]\")\[0\];

setValidationValues(options, \"equalTo\", element); });
adapters.add(\"required\", function (options) { // jQuery Validate
equates \"required\" with \"mandatory\" for checkbox elements if
(options.element.tagName.toUpperCase() !== \"INPUT\" \|\|
options.element.type.toUpperCase() !== \"CHECKBOX\") {
setValidationValues(options, \"required\", true); } });
adapters.add(\"remote\", \[\"url\", \"type\", \"additionalfields\"\],
function (options) { var value = { url: options.params.url, type:
options.params.type \|\| \"GET\", data: {} }, prefix =
getModelPrefix(options.element.name);

\$.each(splitAndTrim(options.params.additionalfields \|\|
options.element.name), function (i, fieldName) { var paramName =
appendModelPrefix(fieldName, prefix); value.data\[paramName\] = function
() { var field =
\$(options.form).find(\":input\").filter(\"\[name=\'\" +
escapeAttributeValue(paramName) + \"\'\]\"); // For checkboxes and radio
buttons, only pick up values from checked fields. if
(field.is(\":checkbox\")) { return field.filter(\":checked\").val() \|\|
field.filter(\":hidden\").val() \|\| \'\'; } else if
(field.is(\":radio\")) { return field.filter(\":checked\").val() \|\|
\'\'; } return field.val(); }; });

setValidationValues(options, \"remote\", value); });
adapters.add(\"password\", \[\"min\", \"nonalphamin\", \"regex\"\],
function (options) { if (options.params.min) {
setValidationValues(options, \"minlength\", options.params.min); } if
(options.params.nonalphamin) { setValidationValues(options,
\"nonalphamin\", options.params.nonalphamin); } if
(options.params.regex) { setValidationValues(options, \"regex\",
options.params.regex); } }); adapters.add(\"fileextensions\",
\[\"extensions\"\], function (options) { setValidationValues(options,
\"extension\", options.params.extensions); });

\$(function () { \$jQval.unobtrusive.parse(document); });

return \$jQval.unobtrusive; }));

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.MVC/wwwroot/lib/jquery-validation-unobtrusive/LICENSE.txt
================================================ The MIT License (MIT)

Copyright (c) .NET Foundation and Contributors

All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a
copy of this software and associated documentation files (the
\"Software\"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be included
in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Test/Ecommerce.Test.csproj
================================================ ﻿\<Project
Sdk=\"Microsoft.NET.Sdk\"\>

\<PropertyGroup\> \<TargetFramework\>net8.0\</TargetFramework\>
\<ImplicitUsings\>enable\</ImplicitUsings\>
\<Nullable\>enable\</Nullable\>

\<IsPackable\>false\</IsPackable\>
\<IsTestProject\>true\</IsTestProject\> \</PropertyGroup\>

\<ItemGroup\> \<PackageReference Include=\"coverlet.collector\"
Version=\"6.0.0\" /\> \<PackageReference
Include=\"Microsoft.NET.Test.Sdk\" Version=\"17.8.0\" /\>
\<PackageReference Include=\"Moq\" Version=\"4.20.72\" /\>
\<PackageReference Include=\"xunit\" Version=\"2.9.3\" /\>
\<PackageReference Include=\"xunit.runner.visualstudio\"
Version=\"3.1.4\"\> \<IncludeAssets\>runtime; build; native;
contentfiles; analyzers; buildtransitive\</IncludeAssets\>
\<PrivateAssets\>all\</PrivateAssets\> \</PackageReference\>
\</ItemGroup\>

\<ItemGroup\> \<Using Include=\"Xunit\" /\> \</ItemGroup\>

\<ItemGroup\> \<ProjectReference
Include=\"..\\Ecommerce.Application\\Ecommerce.Application.csproj\" /\>
\<ProjectReference Include=\"..\\Ecommerce.Core\\Ecommerce.Core.csproj\"
/\> \</ItemGroup\>

\</Project\>

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Test/UnitTest1.cs
================================================ using Xunit; namespace
Ecommerce.Test { public class UnitTest1 { \[Fact\] public void Test1() {

} } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Test/Services/ProductServiceTests.cs
================================================ ﻿using AutoMapper; using
Ecommerce.Application.Mapping; using Ecommerce.Application.Services;
using Ecommerce.Core.DTOs; using Ecommerce.Core.Entities; using
Ecommerce.Core.Interfaces; using Moq; using Xunit;

namespace Ecommerce.Test.Services { public class ProductServiceTests {
private readonly Mock\<IProductRepository\> \_productRepositoryMock;
private readonly Mock\<IUserRepository\> \_userRepositoryMock; private
readonly IMapper \_mapper; private readonly ProductService
\_productService;

public ProductServiceTests() { \_productRepositoryMock = new
Mock\<IProductRepository\>(); \_userRepositoryMock = new
Mock\<IUserRepository\>(); var mapperConfig = new
MapperConfiguration(cfg =\> cfg.AddProfile(new MappingProfile()));
\_mapper = mapperConfig.CreateMapper();

\_productService = new ProductService( \_productRepositoryMock.Object,
\_userRepositoryMock.Object, \_mapper ); }

\[Fact\] public async Task GetAllProductsAsync_ShouldReturnProducts() {
// Arrange var products = new List\<Product\> { new Product { Id = 1,
Name = \"P1\", Price = 10, Stock = 5, SellerId = 100 }, new Product { Id
= 2, Name = \"P2\", Price = 20, Stock = 2, SellerId = 101 } };
\_productRepositoryMock.Setup(r =\>
r.GetAllAsync()).ReturnsAsync(products);

// Act var result = await \_productService.GetAllProductsAsync();

// Assert Assert.NotNull(result); Assert.Equal(2, result.Count); }

\[Fact\] public async Task AddProductAsync_ShouldValidateSellerRole() {
// Arrange var request = new ProductRequestDTO { Name = \"P1\", Price =
10, Stock = 5, SellerId = 1 }; var seller = new User { Id = 1, Role =
\"Seller\" }; \_userRepositoryMock.Setup(r =\>
r.GetByIdAsync(1)).ReturnsAsync(seller); \_productRepositoryMock.Setup(r
=\> r.AddAsync(It.IsAny\<Product\>())).Returns(Task.CompletedTask);

// Act var response = await \_productService.AddProductAsync(request);

// Assert Assert.Equal(\"P1\", response.Name); } } }

================================================ FILE:
Assessments/Assessment6-EcommercePro/EcommercePro/Ecommerce.Test/Services/UserServiceTests.cs
================================================ ﻿using AutoMapper; using
Ecommerce.Application.Mapping; using Ecommerce.Application.Services;
using Ecommerce.Core.DTOs; using Ecommerce.Core.Entities; using
Ecommerce.Core.Interfaces; using Moq; using Xunit;

namespace Ecommerce.Test.Services { public class UserServiceTests {
private readonly Mock\<IUserRepository\> \_userRepoMock; private
readonly UserService \_userService; private readonly IMapper \_mapper;

public UserServiceTests() { \_userRepoMock = new
Mock\<IUserRepository\>(); var mapperConfig = new
MapperConfiguration(cfg =\> cfg.AddProfile(new MappingProfile()));
\_mapper = mapperConfig.CreateMapper(); \_userService = new
UserService(\_userRepoMock.Object, \_mapper); }

\[Fact\] public async Task
AddUserAsync_ShouldAssignNextId_AndReturnUserResponse() { // Arrange var
existingUsers = new List\<User\> { new User { Id = 1, Username =
\"Adhnan\", Email = \"adhnan@test.com\" } }; \_userRepoMock.Setup(r =\>
r.GetAllAsync()).ReturnsAsync(existingUsers); \_userRepoMock .Setup(r
=\> r.AddAsync(It.IsAny\<User\>())) .Callback\<User\>(u =\> u.Id = 2)
.Returns(Task.CompletedTask);

var request = new UserRequestDTO { Username = \"Subashini\", Email =
\"subashini@test.com\" };

// Act var result = await \_userService.AddUserAsync(request);

// Assert Assert.Equal(2, result.Id); Assert.Equal(\"Subashini\",
result.Username); Assert.Equal(\"subashini@test.com\", result.Email);
\_userRepoMock.Verify(r =\> r.AddAsync(It.Is\<User\>(u =\> u.Id == 2)),
Times.Once); }

\[Fact\] public async Task UpdateUserAsync_ShouldUpdateUser_WhenExists()
{ // Arrange var users = new List\<User\> { new User { Id = 1, Username
= \"Ahalya\", Email = \"ahalya@test.com\" } }; \_userRepoMock.Setup(r
=\> r.GetByIdAsync(1)).ReturnsAsync(users.First());
\_userRepoMock.Setup(r =\>
r.UpdateAsync(It.IsAny\<User\>())).Returns(Task.CompletedTask);

var request = new UserRequestDTO { Username = \"Amrith\", Email =
\"amrith@test.com\" };

// Act await \_userService.UpdateUserAsync(1, request);

// Assert \_userRepoMock.Verify(r =\> r.UpdateAsync(It.Is\<User\>(u =\>
u.Id == 1 && u.Username == \"Amrith\" && u.Email == \"amrith@test.com\"
)), Times.Once); }

\[Fact\] public async Task
UpdateUserAsync_ShouldThrowException_WhenUserNotFound() { // Arrange
\_userRepoMock.Setup(r =\>
r.GetByIdAsync(99)).ReturnsAsync((User?)null);

var request = new UserRequestDTO { Username = \"Sivadarsini\", Email =
\"sivadarsini@test.com\" };

// Act & Assert await Assert.ThrowsAsync\<KeyNotFoundException\>(() =\>
\_userService.UpdateUserAsync(99, request)); }

\[Fact\] public async Task GetAllUsersAsync_ShouldReturnMappedUsers() {
// Arrange var users = new List\<User\> { new User { Id = 1, Username =
\"Adhnan\", Email = \"adhnan@test.com\" }, new User { Id = 2, Username =
\"Subashini\", Email = \"subashini@test.com\" } };
\_userRepoMock.Setup(r =\> r.GetAllAsync()).ReturnsAsync(users);

// Act var result = await \_userService.GetAllUsersAsync();

// Assert Assert.Equal(2, result.Count); Assert.Contains(result, r =\>
r.Username == \"Adhnan\"); Assert.Contains(result, r =\> r.Username ==
\"Subashini\"); }

\[Fact\] public async Task
GetUserByIdAsync_ShouldReturnUser_WhenExists() { // Arrange var user =
new User { Id = 3, Username = \"Ahalya\", Email = \"ahalya@test.com\" };
\_userRepoMock.Setup(r =\> r.GetByIdAsync(3)).ReturnsAsync(user);

// Act var result = await \_userService.GetUserByIdAsync(3);

// Assert Assert.NotNull(result); Assert.Equal(\"Ahalya\",
result.Username); Assert.Equal(\"ahalya@test.com\", result.Email); }

\[Fact\] public async Task
GetUserByIdAsync_ShouldReturnNull_WhenNotExists() { // Arrange
\_userRepoMock.Setup(r =\>
r.GetByIdAsync(99)).ReturnsAsync((User?)null);

// Act var result = await \_userService.GetUserByIdAsync(99);

// Assert Assert.Null(result); } } }
