#!/bin/bash

botName=""
spid=""

#parse and get the botName parameter
while [ $# -gt 0 ]; do

   if [[ $1 == *"--"* ]]; then
        param="${1/--/}"
        declare $param="$2"

   fi

  shift
done

echo $spid

#go and find the App Registration/MSFT ID if it exists
doCreate=true

for item in $(az ad app list | jq -c '.[] .displayName') 
do
     val="${item%\"}"
     val="${val#\"}"
     if [[ $val == $botName ]]; then
          doCreate=false
          break
     fi
done

appId=""

#create it first if it doesn't exist
if [ "$doCreate" =  true ]; then
     app=$(az ad app create --display-name $botName --password 'tacospastapizza4@11' --available-to-other-tenants)
fi

appId=$(az ad app list --all --display-name $botName | jq '.[0] .appId select({appId: .id})' )


#output the value to the deployment
echo $appId
