# Using LibMan for Client-Side Packages


Microsoft has introduced LibMan as a package manager for client-side packages. This update explains how to use LibMan to install the Bootstrap CSS package that is required for example projects. (You can also continue to use Bower, as described [here](Using%20Bower.md)).

1. Update .NET Core.

    LibMan relies on the `dotnet tool` command, which is only available in versions 2.1.300 and later of the .NET Core SDK. Download and install the latest version of the SDK from https://www.microsoft.com/net/download.

2. Open a new command prompt or PowerShell and run the following command to install LibMan:

        dotnet tool install --global Microsoft.Web.LibraryManager.Cli

3. Create the example project by following the instructions in the chapter you are reading. Ignore the section on using Bower.

4. Open a new command prompt or PowerShell, navigate to the project folder (which contains the `Startup.cs` file) and run the following command:

        libman install twitter-bootstrap@4.0.0-alpha.6 --destination wwwroot/lib/bootstrap/dist --provider cdnjs

5. Continue following the examples in the chapter.

