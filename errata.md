# Errata for *Pro ASP.NET Core MVC 2*

Microsoft has removed the Bower Configuration File template from Visual Studio. To create the Bower file required by the example projects:

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

5. Save the changes to the `bower.json` file and Visual Studio will download the Bootstrap package.

(Thanks to Michael Horn for reporting this problem)
