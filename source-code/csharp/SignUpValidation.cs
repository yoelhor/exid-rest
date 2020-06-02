using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Sample.ExternalIdentities
{
    public static class SignUpValidation
    {
        [FunctionName("SignUpValidation")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            // Get the request body
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            // If input data is null, show block page
            if (data == null)
            {
                return (ActionResult)new OkObjectResult(new ResponseContent("ShowBlockPage", "SingUp-Validation-01", "Invalid input data."));
            }

            // Print out the request body
            log.LogInformation("Request body: " + requestBody);

            // Get the current user language 
            string language = (data.ui_locales == null || data.ui_locales.ToString() == "") ? "default" : data.ui_locales.ToString();
            log.LogInformation($"Current language: {language}");

            // If displayName claim not found, show validation error message. So, user can fix the input data
            if (data.displayName == null || data.displayName.ToString() == "")
            {
                return (ActionResult)new BadRequestObjectResult(new ResponseContent("ValidationError", "SingUp-Validation-02", "Display name is mandatory."));
            }

            // If displayName claim is too short, show validation error message. So, user can fix the input data.
            if (data.displayName.ToString().Length < 4)
            {
                return (ActionResult)new BadRequestObjectResult(new ResponseContent("ValidationError", "SingUp-Validation-03", "Display name must contain at least four characters."));
            }

            // Input validation passed successfully, return `Allow` response.
            return (ActionResult)new OkObjectResult(new ResponseContent());
        }
    }
}
