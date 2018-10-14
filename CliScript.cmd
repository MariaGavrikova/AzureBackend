set resourceGroup=adventure-works-rg-1
set gatewayName=aw-app-gtw

echo "create new backend pool that points to SQL server VM"
call az network application-gateway address-pool create -g %resourceGroup% --gateway-name %gatewayName% -n sql-pool --servers 10.0.1.7

echo "add new http setting"
call az network application-gateway http-settings create -g %resourceGroup% --gateway-name %gatewayName% -n sql-http-settings --port 1433 --protocol Http --cookie-based-affinity Disabled --timeout 30

echo "add new port"
call az network application-gateway frontend-port create -g %resourceGroup% --gateway-name %gatewayName% -n sql-1433 --port 1433

echo "add new listener"
call az network application-gateway http-listener create -g %resourceGroup% --gateway-name %gatewayName% --frontend-port sql-1433 -n sql-listener --frontend-ip appGatewayFrontendIp

echo "add new rule"
call az network application-gateway rule create -g %resourceGroup% --gateway-name %gatewayName% -n sql-rule --http-listener sql-listener --rule-type Basic --address-pool sql-pool --http-settings sql-http-settings