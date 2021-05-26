# Test assesment for S.Street 

Folders structure in the project imitates the real good architecture since there was no so much sense to separate logic into other projects.
There are a lot of places in code to improve, at least the following points: 
* file parse logic - now it is pretty primitive
* have user-friendly errors on UI (now errors are written to file without any user notifications), handle global exceptions 4) I did not apply any custom styles to show file result, all styles are default Blazor styles.
* unit testing with large amount of different files

Code contains comments just to simplify review and save reviewer's time.

#### Functionality
User can upload the file (max upload size 3MB) on single main page and see parsed resuls in table below at the same page. All validation errors and other errors are written to log file, so no notifications about errors for user on UI. 


#### Frameworks

* .Net 5.0
* Serilog  for logging
* FluentValidation 


