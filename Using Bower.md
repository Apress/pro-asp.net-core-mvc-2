# Using Bower with Visual Studio


Microsoft has removed the Bower Configuration File template from Visual Studio and the source for Bower packages has changed.

**You can continue using Bower by following the instructions below or you can use the LibMan tool, which Microsoft has provided as a replacement and which is described [here](Using%20LibMan.md)**

To create the Bower file required by the example projects:

1. Right-click on the project item in the Solution Explorer window, select Add > New Item, select JSON File from the ASP.NET Core/General category and set the file name to `.bowerrc` (note the letter `r` appears twice), and click the Add button.
2. Set the contents of the `.bowerrc` file as follows:

    ````
    {
        "directory": "wwwroot/lib",
        "registry": "https://registry.bower.io"        
    }

3. Save the changes. (This is important - you must save the changes to the `.bowerrc` file before proceeding)

4. Right-click on the project item and create another JSON file, this time called `bower.json`. Set the contents of the file as follows:

    ````
    {
        "name": "asp.net",
        "private": true,
        "dependencies": {
            "bootstrap": "4.0.0-alpha.6"            
        }
    }

5. Save the changes to the `bower.json` file. Close and re-open  the project and Visual Studio will download the Bootstrap package.