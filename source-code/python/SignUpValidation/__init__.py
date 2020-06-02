import logging
import json
import azure.functions as func


def main(req: func.HttpRequest) -> func.HttpResponse:
    logging.info('Python HTTP trigger function processed a request v1.0.')

    # Get the request body
    try:
        req_body = req.get_json()
    except:
        return func.HttpResponse(
            json.dumps({"version": "1.0.0", "status": 200, "action": "ShowBlockPage", "code": "SingUp-Validation-01", "userMessage": "Invalid input data."}),
            status_code=200,
            mimetype="application/json"
         )

    # Print out the request body
    logging.info(f"Request body: {req_body}")

    # Get the current user language
    language = req_body.get('ui_locales') if 'ui_locales' in req_body and req_body.get('ui_locales') else "default" 
    logging.info(f"Current language: {language}")

    # If displayName claim not found, show validation error message. So, user can fix the input data
    if 'displayName' not in req_body or not req_body.get('displayName'):
        return func.HttpResponse(
            json.dumps({"version": "1.0.0", "status": 200, "action": "ShowBlockPage", "code": "SingUp-Validation-02", "userMessage": "Display name is mandatory."}),
            status_code=200,
            mimetype="application/json"
         )

    # # If displayName claim is too short, show validation error message. So, user can fix the input data.
    if len(req_body.get('displayName')) < 4:
        return func.HttpResponse(
            json.dumps({"version": "1.0.0", "status": 200, "action": "ShowBlockPage", "code": "SingUp-Validation-03", "userMessage": "Display name must contain at least four characters."}),
            status_code=200,
            mimetype="application/json"
         )
    
    # Input validation passed successfully, return `Allow` response.
    return func.HttpResponse("Ok")

