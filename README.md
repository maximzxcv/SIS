##RESTful Service  
- Standart MS Web API. instead of [id] parameter in routes it uses [name], as it is task specifix unique identifire.
- Sis.Interview.Dal - contains data access logic as well as some buisseness logic, project simplicity allows to do it.
- MidiaFormat supporting implemented in WebApiConfig.cs.

##Interface
- Implemented using Angular. Controller can be find in scripts/app/RetrospectiveService.js
- Didn't care a lot about desing, but it was built using bootstrap.

##Logging
- Implemented using NLog. Never used it before, so was interesting to try it ;)
- Support request tracing [Framwork/LoggingHandler.cs] and unhandled exceptions [Framwork/UnhandledExceptionFilterAttribute.cs]

##Unit Testing
- Covers some functionality for retrospective CRUD service. 

