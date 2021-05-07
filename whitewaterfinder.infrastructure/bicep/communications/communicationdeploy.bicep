param name string
param location string
param plan_name string

@secure()
param password string
param email string
param acceptMarketingEmails string
param website string

resource name_resource 'Sendgrid.Email/accounts@2015-01-01' = {
  name: name
  location: location
  plan: {
    name: plan_name
    publisher: 'Sendgrid'
    product: 'sendgrid_azure'
    promotionCode: ''
  }
  properties: {
    password: password
    acceptMarketingEmails: acceptMarketingEmails
    email: email
    website: website
  }
}

output SendGrid object = name_resource.properties