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

## Source code

REST API source code for following platform: 

<table border="0" style="border:none;">
    <tr style="border: none;">
        <td style="padding-left:0; border: none;"><a href="../../tree/master/source-code/csharp" ><img src="https://docs.microsoft.com/azure/app-service/media/index/logo_net.svg" height="48px" width="48px" alt=".Net Core" ><br /><span>.Net Core</span></a></div></td>
        <td style="padding-left:20px; border: none;"><a href="../../tree/master/source-code/node-js" ><img src="https://docs.microsoft.com/azure/app-service/media/index/logo_nodejs.svg" height="48px" width="48px" alt="Node.js" ><br /><span>Node.js</span></a></div></td>
        <td style="padding-left:20px; border: none;"><a href="../../tree/master/source-code/python" ><img src="https://docs.microsoft.com/azure/app-service/media/index/logo_python.svg" height="48px" width="48px" alt="Python (on Linux)" ><br /><span>Python</span></a></div></td>
    </tr>
</table>

### Clone, deploy and run the sample
TBD

### Test your REST API service
TBD

### Bring your own business logic
TBD
