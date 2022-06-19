# EmurgoTest
Basic test Framework to test UI application and APIs. 
Framework is built on C# .net 5.0 
You may need to setup .net 5.0 project to resolve dependencies in case nuget is missing
This solution has UI and API test support.
We have Datareader which read XML and convert that  to C# object so that you can validate your data
It also has basic logging functionality -> Create a new directory for each execution and create log file for each test with logging info
It has Selenium base utilities to perform various selenium interactions
You can test your web API just by extending framework

# Improvement to be coming
Custom test executor - CLI based (can be launched remotely)
Refactoring -> To handle intermediate custom logic to interact with selenium
Report generation
