We'll add a database to this project in this step

1. We'll create the dev db directly in azure .. ye ye .. it's the integration which is the purpose of this tutorial
2. We'll use entity framework core for the purpose of data migrations
3. We'll display some data from the database in our view.


1. run the script to create a server, sql db, & set firewall rules

```
#!/bin/bash

# Set an admin login and password for your database
export adminlogin=ServerAdmin
export password=ChangeYourAdminPassword1
# The logical server name has to be unique in the system
export servername=server-$RANDOM
export resourceGroup=myResourceGroup

# The ip address range that you want to allow to access your DB
export startip=0.0.0.0
export endip=0.0.0.0

# Create a resource group
az group create \
    --name $resourceGroup \
    --location westeurope

# Create a logical server in the resource group
az sql server create \
    --name $servername \
    --resource-group $resourceGroup \
    --location westeurope  \
    --admin-user $adminlogin \
    --admin-password $password

# Configure a firewall rule for the server
az sql server firewall-rule create \
    --resource-group $resourceGroup \
    --server $servername \
    -n AllowYourIp \
    --start-ip-address $startip \
    --end-ip-address $endip

# Create a database in the server with zone redundancy as true
az sql db create \
    --resource-group $resourceGroup \
    --server $servername \
    --name mySampleDatabase \
    --sample-name AdventureWorksLT \
    --service-objective S0 \

# Update database and set zone redundancy as false
az sql db update \
    --resource-group $resourceGroup \
    --server $servername \
    --name mySampleDatabase \
    --zone-redundant false
```

2. get the connection string

```
az sql db show-connection-string -s server-13026 -n mySampleDatabase -c ado.net
```

3. use the database in code