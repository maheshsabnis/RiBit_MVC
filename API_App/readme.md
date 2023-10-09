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

