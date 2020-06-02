module.exports = async function (context, req) {
    context.log('JavaScript HTTP trigger function processed a request v1.');

    // If input data is null, show block page
    if (!req.body)
    {
        context.res = { body: {"version": "1.0.0", "status": 200, "action": "ShowBlockPage", "code": "SingUp-Validation-01", "userMessage": "Invalid input data."}};
        return;
    }

    // Print out the request body
    context.log(`Request body: ${JSON.stringify(req.body)}`);

    // Get the current user language 
    var language =  (req.body.ui_locales == null || req.body.ui_locales === "") ? "default" : req.body.ui_locales;
    context.log(`string text ${language} string text`);

    // If displayName claim not found, show validation error message. So, user can fix the input data
    if (!req.body.displayName)
    {
        context.res = { body: {"version": "1.0.0", "status": 400, "action": "ValidationError", "code": "SingUp-Validation-02", "userMessage": "Display name is mandatory."}};
        return;
    }

    // If displayName claim is too short, show validation error message. So, user can fix the input data.
    if (req.body.displayName.length < 4)
    {
        context.res = { body: {"version": "1.0.0", "status": 400, "action": "ValidationError", "code": "SingUp-Validation-03", "userMessage": "Display name must contain at least four characters."}};
        return;
    }
    
    // Input validation passed successfully, return `Allow` response.
    context.res = {
            body: "Ok"
        };
};