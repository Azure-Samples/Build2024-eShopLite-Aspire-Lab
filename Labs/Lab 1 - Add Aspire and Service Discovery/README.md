# Lab 1 - Adding .NET Aspire to an existing .NET Core application and enabling service discovery

In this lab, you will add the .NET Aspire library to an existing .NET Core application and enable service discovery. We'll be using the eShopLite application.

All of the code for this lab is available in the `Start` folder. If you need help along the way, the final code can be found in the `Finish` folder.

## Adding .NET Aspire to the eShopLite application

1. Open Visual Studio 2022
1. Open the **eShopLite** solution from the **Labs/Lab 1 - Add Aspire and Service Discovery** folder.
1. To see the application running before adding Aspire, right click on the solution node in Solution Explorer and select **Configure Startup Projects**. Select **Multiple startup projects** and set the **Products** and **Store** projects to **Start**. The run the application.
1. Close the web browsers to stop debugging the applications.
1. Now let's add Aspire. Back in Visual Studio, right-click the **Store** project, select **Add**, and then select **.NET Aspire Orchestrator Support** and then select **Ok**.
1. 2 new projects will be added to the solution:
    * **eShopLite.AppHost**
    * **eShopLite.ServiceDefaults**
1. Open the **Program.cs** file from the **eShopLite.AppHost** project.
1. Notice the following line of code which adds the **Store** project the the Aspire orchestration:

    ```csharp
    builder.AddProject<Projects.Store>("store");
    ```

1. To add the **Products** project to the Aspire orchestration, right click on the **Products** project, select **Add**, and then select **.NET Aspire Orchestrator Support**.
    > A warning will appear indicating that the solution already has Aspire support. Select **Yes** to add the project to the orchestration.

Both projects are now part of the Aspire orchestration. Now we need to make sure that the **Store**  can discover the **Products** backend url through .NET Aspire's service discovery.

## Enabling service discovery

1. Open the **Program.cs** file from the **eShopLite.AppHost** project.
2. Update the code to first assign *ProjectResource* products to a variable, then edit the code that adds **Store** to the Aspire orchestration to also include a reference to the **Products**:

    ```csharp
    var products = builder.AddProject<Projects.Store>("products");

    builder.AddProject<Projects.Store>("store").WithReference(products);
    ```

3. Next update the **appSettings.json** in the **Store** project for the **ProductEndpoint** and **ProductEndpointHttps**:

    ```json
    "ProductEndpoint": "http://products",
    "ProductEndpointHttps": "https://products",
    ```

4. Press **F5** or start debugging the application.
5. The Aspire dashboard appears.
6. Click on the endpoint for the **store** project.
7. A new tab appears with the same eShopLite application, but now the **Products** backend is being called through service discovery.

