# Lab 3 - Deploy the and provision the entire application to Azure

In this lab, you will deploy the entire application to Azure Container Apps (ACA) using the Azure Developer CLI (`azd`).

## Login to Azure

1. Open a terminal and run the following command to login to Azure:

    ```bash
    azd auth login
    ```

## Initialize the deployment environment

1. Make sure you are in the `Labs/Lab 3 - Deploy` directory:

    ```bash
    cd "$(git rev-parse --show-toplevel)/Labs/Lab 3 - Deploy"
    ```

1. Run the following command to initialize the deployment environment:

    ```bash
    azd init
    ```

1. Choose the following options:

   - `? How do you want to initialize your app?`
     - `> Use code in the current directory`
   - `? Select an optio`
     - `> Confirm and continue initializing my app`
   - `? Enter a new environment name`
     - `<RANDOM_NAME>`

   > **Note**:
   > 
   > 1. Replace `<RANDOM_NAME>` with your preferred environment name.

1. Confirm the following files have been generated:

   - `.azure/.gitignore`
   - `.azure/config.json`
   - `.azure/<RANDOM_NAME>/.env`
   - `.azure/<RANDOM_NAME>/config.json`
   - `azure.yaml`
   - `next-steps.md`

## Provision and deploy the application

1. Run the following command to provision and deploy the application to Azure Container Apps:

    ```bash
    azd up
    ```

1. Choose the following options:

   - `? Select an Azure Subscription to use:`
     - `> <AZURE_SUBSCRIPTION>`
   - `? Select an Azure location to use:`
     - `> <AZURE_LOCATION>`

   > **Note**:
   > 
   > 1. If you have only one Azure subscription, it will be automatically chosen.
   > 1. Replace `<AZURE_SUBSCRIPTION>` and `<AZURE_LOCATION>` with your Azure subscription and location.

1. Wait for the deployment to complete. It may take a few minutes.
1. Once the deployment is over, go to the Azure Portal and navigate to the resource group of `rg-<RANDOM_NAME>` and find the Azure Container Apps instances.

## Analyze the provisioning

1. Make sure you are in the `Labs/Lab 3 - Deploy` directory:

    ```bash
    cd "$(git rev-parse --show-toplevel)/Labs/Lab 3 - Deploy"
    ```

1. Generate Bicep files from the app:

    ```bash
    azd config set alpha.infraSynth on
    azd infra synth
    ```

1. Confirm the following files have been generated:

   - `infra/main.bicep`
   - `infra/main.parameters.json`
   - `infra/resources.bicep`

1. Open those files and see which resources are being provisioned.

## Analyze the deployment

1. Make sure you are in the `Labs/Lab 3 - Deploy` directory:

    ```bash
    cd "$(git rev-parse --show-toplevel)/Labs/Lab 3 - Deploy"
    ```

1. Generate manifest files from the app:

    ```bash
    dotnet run --project eShopLite.AppHost/eShopLite.AppHost.csproj `
        -- `
        --publisher manifest `
        --output-path ../aspire-manifest.json
    ```

1. Confirm the following file has been generated:

   - `aspire-manifest.json`

1. Open the `aspire-manifest.json` file and see which resources are being deployed.

