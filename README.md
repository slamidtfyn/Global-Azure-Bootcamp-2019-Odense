# Global-Azure-Bootcamp-2019-Odense


# Getting started 

Prerequisites:
1. Visual Studio or VS Code
2. Azure App Serivce extension installed for VS Code
3. Azure Subscription - Azure Passes is available, just ask.
4. Git installed 
5. .NET Core 2.1


# Website running on local machine

## Website running local on Mac / Linux / Windows using VS Code

1. Open the project in VS code
2. Open the terminal and type `dotnet run` and follow instructions on screen.

## Website running local on Windows using Visual Studio

1. Open the project in Visual Studio.
2. Click `F5`.

# Website running in Azure
## 1. Create Web App in Azure
First, we need to create the Web App where our website will be running on.

We'll do this using Azure CLI @ shell.azure.com. This way we don't need to deal with authentication.

1. Login to shell.azure.com
2. Remember to be in Powershell mode
3. Let's define required variables / configuration settings in the shell.
```
$ResourceGroup = 'WebAppResourceGroup'
$Location = 'westeurope'
$appserviceplanname = 'agbodenseappplan'
$webappname = 'agbodensesuperapp'
$Sku = 'F1'
```
4. Create a Resource group, the logical container for the web app.
```
az group create `
    --name $ResourceGroup `
    --location $location
```
5. Create the App Service Plan within the resource group.
The App Service Plan is a "container" in which your web apps will be created.
You can create more than one web app in a single App Service Plan.
```
az appservice plan create `
    --name $appserviceplanname `
    --resource-group $ResourceGroup `
    --sku $Sku
```
6. Now we create our webapp 
```
az webapp create `
    --name $webappname `
    --resource-group $ResourceGroup `
    --plan $appserviceplanname
```
7. Visit your new empty website
```
The url for your website will be https://$webappname.azurewebsites.net
```

## 2. Upload website to the newly created web app using VS Code

1. In VS Code open your Azure Pane to the left and under "App Services" click the fancy "Deploy to Web App" and follow the guide.
2. When it's done publishing your website, VS Code will give you a direct url for your website.
3. Profit

## 3. Upload website to the newly created web app using Visual Studio

