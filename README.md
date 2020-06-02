# Azure AD external identities sign-up REST API samples

As a developer, IT administrator., you can use API connectors to integrate with your own web APIs as part of your [self-service sign-up user flow](https://docs.microsoft.com/en-us/azure/active-directory/b2b/self-service-sign-up-overview). You can use API connectors to enable your custom user approval system for managing who successfully signs up to your tenant. Read more [TBD](https://docs.microsoft.com/en-us/azure/active-directory/b2b/self-service-sign-up-add-approvals).

In this repo, you will find samples for many languages, using[Azure Functions](https://docs.microsoft.com/azure/azure-functions/functions-overview). Azure Function allows you to run small pieces of code (called "functions") without worrying about application infrastructure. With Azure Functions, the cloud infrastructure provides all the up-to-date servers you need to keep your application running at scale.

## REST API sample

The sample demonstrates how to validate the data return by the external identity provider, or provided by the user. You can use the samples *After sign-in with an identity provider*, or *Before creating the account in the directory*.

### Workflow

1. Check whether the incoming JSON is existed. If not, return *ShowBlockPage* error message. This will block the user from continuing with the sign-up process.
1. Print out the request body, so you can debug your service. Remove this code in production.
1. Get the current user language. Azure AD always sends the `ui_locales` parameter.
1. If the display name claim is existed. If not, return the *ValidationError* error message. So, user can fix the input data.
1. Check the length of the display name
1. If the sign-up validation passed successfully, return `Allow` response.
