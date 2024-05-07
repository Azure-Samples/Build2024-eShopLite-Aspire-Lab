# Lab 2 - Adding caching and exploring the .NET Aspire dashboard

In this lab, you will add Redis caching to increase performance to the eShopLite application and discover how .NET Aspire makes it easy to access Redis caching services.

## Adding a Redis Cache

1. Open the eShopLite solution from the Labs/Lab 2. This should looks exactly like you left the solution in Lab 1.
1. Right click on the project **eShopLite.AppHost** and select  Add > .NET Aspire Component. 
1. In the search bar, at the top left of the NuGet Package Manager, type **Aspire.Hosting.Redis**. Select the component and click the install button.
1. Click the **I accept** button to accept the license agreement.
1. Open the **Program.cs** file from the **eShopLite.AppHost** project.
1. Let's create a *RedisResource* by adding the following code just after **builder** is created.
	
	``` csharp
	var builder = DistributedApplication.CreateBuilder(args);

	var redis = builder.AddRedis("redis");
	```
1. Now add another reference to the **Projects.AppHost** declaration to add the Redis reference.
	
	``` csharp
	builder.AddProject<Projects.Store>("store")
		.WithReference(products)
		.WithReference(redis);
	```

So now we have a Redis resource that we can use in our application. Let's add a cache to the Store Website.

1. Right click on the project **Store** and select  Add > .NET Aspire Component. 
1. In the search bar, at the top left of the NuGet Package Manager, type **Aspire.StackExchange.Redis.OutputCache**. Select the component and click the install button.
1. Click the **I accept** button to accept the license agreement.
1. Open the **Program.cs** file from the **Store** project.
1. Just after the **builder** is created, add the following code to add the Redis Output Cache.
	
	``` csharp
	builder.AddRedisOutputCache("redis");
	...
1. Now to add the caching middleware to the request pipeline add the following code just after the **app** is created.
	``` csharp
	app.UseOutputCache();
	```
1. To cache the products list, open the **Products.razor** file from the **Components > Pages** folder. Add the following code to the top of the file, after the last *@attribute* command.
	``` csharp
	@attribute [Microsoft.AspNetCore.OutputCaching.OutputCache(Duration = 10)]
	```

Now, when you run the application, the products list will be cached for 10 seconds. You can change the duration to see the effect of the cache. The first time you access the page, the products list will be retrieved from the database. The next time you access the page within the cache duration, the products list will be retrieved from the cache.

## Explore the .NET Aspire dashboard

Let's test it:

1. In Visual Studio, to start the app, press `F5` or **select Debug > Start Debugging**.
	> If Docker is not running, you will be prompted to start it.
1. When the .NET Aspire dashboard appears, note the you have now three resources: **store**, **products**, and **redis**. Redis is Type is **Container**.
1. Click on the store the endpoints, a new tab will open with the store website.
1. For the next few steps it will be easier to visualize the impact of the cache, to have the store website and the .NET Aspire dashboard side by side.
1. In the .NET Aspire dashboard, click on **Traces** from the left menu. This display the traces of the requests made to the store website through the different resources.
1. In the store website, click on the **Products** link. This will display the products list.
1. Note that in the .NET Aspire dashboard, new lines were added. Note that in the **Spans** column, some are identified as **store** and one with **store: GET /products** as name has **store** and **products**. This is because the first time the products list was retrieved from the database (aka products).
1. Now refresh the store website displaying the product list.
1. Looking back at the .NET Aspire dashboard, new lines were added, but this time the **Spans** column for the line **store: GET /products** has only **store**. This is because the products list was retrieved from the cache.
1. Click on the **View** link in the column details of the line **store: GET /products**. This will display the details of the request.
1. Note that the detail line **DATA redis GET**. This is where the cache was used instead of the database.
1. Try a few more time with-in or out the 10 second limit that was set in the **Products.razor** page.