set resourceGroup=adventure-works-rg-1
set gatewayName=aw-app-gtw
set gatewayIp=aw-app-gtw-ip
set loadBalancerName=aw-vnet-gateway
set vnetName=aw-net
set loadBalancerDns=aw-lb
set loadBalancerProbe=sql-probe
set loadBalancerRule=default
set sqlProtocol=tcp
set sqlPort=1433
set loadBalancerPool=sql-pool

echo "delete old application gateway"
call az network application-gateway delete -g %resourceGroup% -n %gatewayName%

echo "delete old gateway IP"
call az network public-ip delete -g %resourceGroup% -n %gatewayIp%

echo "create new load balancer points to SQL server VM"
call az network lb create -g %resourceGroup% -n %loadBalancerName% --sku Basic --vnet-name %vnetName% --public-ip-address-allocation Static --public-ip-dns-name %loadBalancerDns%

echo "create health probe for SQL Server port"
call az network lb probe create -g %resourceGroup% --lb-name %loadBalancerName% -n %loadBalancerProbe% --protocol %sqlProtocol% --port %sqlPort%

echo "create load balancer backend pool and rule"
call az network lb rule create -g %resourceGroup% --lb-name %loadBalancerName% -n %loadBalancerRule% --protocol %sqlProtocol% --frontend-port %sqlPort% --backend-port %sqlPort% --probe-name %loadBalancerProbe%
