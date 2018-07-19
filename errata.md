# Errata for *Pro ASP.NET Core MVC 2*

Microsoft has removed the Bower Configuration File template from Visual Studio. To create the Bower file required by the example projects:

1. Right-click on the project item in the Solution Explorer window, select Add > New Item, select JSON File from the ASP.NET Core/General category and set the file name to `.bowerrc` (note the letter `r` appears twice), and click the Add button.
2. Set the contents of the `.bowerrc` file as follows:

    ````
    {
        "directory": "wwwroot/lib"
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

---

On **Page 859**, the jQuery code that selects invalid elements and applies a Bootstrap class won't work with the final release of Bootstrap 4 (although it does work with the pre-release version specified in the book). If you want to use the final release, then you will need to replace the contents of the `script` element that contains the jQuery code in **Listing 27-10** with the following:

    ...
    <script type="text/javascript">
        $(document).ready(function () {
            $("input.input-validation-error")
                .addClass("is-invalid")
                .siblings(".form-check-label")
                .addClass("text-danger")                
        });
    </script>
    ...

(Thanks to David Kennedy for reporting this problem)