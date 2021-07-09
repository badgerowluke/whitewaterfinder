## UNRELEASED
- moving infrastructure provisioning to terraform
- building out a system to provision infrastructure with Azure Bicep


## ADDED
- new changelog
- converted app service to host the chatbot/ cog services into a function project
- provisioning for the azure container registry (put in all three formats, ARM, TF, Bicep)
- dockerfiles for each of the functions projects to facilitate deployment into a private K8S environment

## CHANGED
- the application settings block of the chatbot functions project in bicep

## REMOVED
- App Service for the Chatbot