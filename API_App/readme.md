# DI Container

- THe Unity Application BLock
	- The 'Container', UnityContainer
		- A COntainer Objet that stores all dependencies for the application in it an auto-resolve them based on their internal dependencies
	- UnityContainer
		- IUnityContainer interface
````html
		- RegisterType<T,U>()
			- T the interface that defines schemas for methods 
			- U the class that implements T and all of its methods
				- U is the class that will be rigister in-to the container and it will be queries using T
		- RegisterType<T>()
			- T is the class that will be register in-to the Container
		- Resolve()
			- THis will be used to Extract an INstance of the class that is register in-to the container 
````
		- By default each object is having lifecyle for an active session, the moment the session is closed, the objet will be send bak to the container and all of it's references will be released 

# API Access using Fromt-End JS
- HTTP Calls with Async Execution in Browser
	- jQuery
		- $.ajax(request-object)
			- jqXhr Object, an async Object
				- done(response-callback-success)
				- fail(response-error-callback) 
		- request-object
			- url: http(s) url of the service
			- method: GET, POST, PUT, DELETE
			- data: used if request id POST/PUT
			- dataType: the type of the formatter that is used by the Browser while sending data 
			- contentType: Media-Formatter, that is specified by API to Process the HTTP REquest Body
		- response-callback-success
			- an async Object, that represents a successful Execution
		- response-error-callback
			- Callback function, thst represents failed response from Service 
		
	