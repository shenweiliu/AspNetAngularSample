## ASP.NET MVC Areas Plugin and Angular for Visual Studio Projects

The ASP.NET MVC Areas plugin is a unique website development model for combination of parent and children’s applications in a large website and parallel code works by multiple teams. This sample shows the full structures, setups, and workflow of this website code patterns in ASP.NET MVC 5 and Angular 11 with the Microsoft Visual Studio.

### Prerequisites on Local Machine

1. Visual Studio 2019 or 2022 (any version should work but latest versions are recommended).

2. [TypeScript 4.0 for Visual Studio](https://marketplace.visualstudio.com/items?itemName=TypeScriptTeam.typescript-40) if the "4.0" folder is not in your *"C:\Program Files (x86)\Microsoft SDKs\TypeScript\"* path.

3. [node.js](https://nodejs.org/en/) (recommended version 14.15.3 - version 15.xx or above may not be compatible with Angular CLI 11). The corresponding LTS version of the npm is auto installed globally.

4. Install the Angular CLI 11 by running the command on the Command Prompt:
 
    `npm install -g @angular/cli@11.0.5`

5. Install Gulp globally by running this command with Command Prompt:
 
    `npm install -g gulp`

### Setting Up Projects

1. "CMD" to the directory *angular-content* of both AspNet.Angular.Mod and AspNet.Angular.Web projects, run the command to install the `node_modules` packages:

    `npm install`
	
    Run the `npm audit fix` if asking so.

2. Run the command in the *AspNet.Angular.Web/angular-content* directory to create the *npm-libs* folder under the *angular-debug*:

    `gulp copyLibs`

3. Open the solution, *AspNet.Angular.Mod.sln*, with the Visual Studio and rebuild it. NuGet packages will also automatically be downloaded.

4. Open and edit the *CopyModToWeb.bat* file located in the *"{Your_Path}/AspNet_Angular_Mod/AspNet.Angular.Mod/"*. Replace the "{Your_Path}" with the path in which you set the sample application. 

5. Copy built and source code files from the AspNet.Angular.Mod project to AspNet.Angular.Web project by running the *CopyModToWeb.bat*. This copy/paste operation is also needed for every build and code change if any files or code pieces are updated in the AspNet.Angular.Mod project later.

6. Open the solution, AspNet.Angular.Web.sln, with the Visual Studio and rebuild it. NuGet packages will also automatically be downloaded.

6. Open the *C:\Windows\System32\drivers\etc\hosts* with the Notepad and add this line and then save the file:

    `127.0.0.1  AspNetAngularWeb`

7. Run the **inetmgr** to open the local IIS Manager and perform these steps:

    - Add a new Application Pool with the name *"AspNetAngularWebPool"*, .NET CLR version *".NET CLR Version v4.0.30319"*, and Managed pipeline mode *"Integrated"*. 
    
	- Add a new website with the Site name *"AspNetAngularWeb"*, Application pool *"AspNetAngularWebPool"* (from the dropdown), Physical path *"{Your-loaction-for-AspNetAngularWeb-project}"*, IP address *"All Unassigned"* or *"127.0.0.1"*, and Host name *"AspNetAngularWeb"*. 

8. "CMD" to the *AspNet.Angular.Web/angular-content* directory, build the Angular CLI output files for non-development environments:

    `ng build --prod`

### Running Applications

1. If you run the application for debugging the AspNet.Angular.Mod project, you need to start the Visual Studio session with the *AspNet.Angular.Mod.sln*. Otherwise, you can start with the *AspNet.Angular.Web.sln*. Both AspNet.Angular.Web and AspNet.Angular.Mod projects use the same local IIS website with the "External Host" settings.

2. Set any breakpoints for your debugging work either on ASP.NET C# or Angular TypeScript parts.

3. Select "Microsoft Edge" as the Web Server from the Visual Studio tool bar.

4. Click the Web Server tool bar item or press F5 to run the debug instance. 

5. If you would like to browse the website without debugging the Angular TypeScript code, you can change the "AngularModuleLoader" value to "cli" in the *Web.config* file of the AspNet.Angular.Web project. You can then run the website either still with Visual Studio Web Server command or F5 (the ASP.NET server-side debugging for C# code is kept) or directly using the site URL with browsers (no debugging processes for both server-side and client-side code).  

### Related Info

[Angular Dual Module Loaders for Visual Studio Projects](https://github.com/shenweiliu/AngularDualModuleLoaders)

### Other Notes

This sample is built based on the real-world operating website. One of the purposes is to provide the sample to Microsoft for troubleshooting reported issues with Visual Studio 2022. The sample uses the .NET Framework 4.6.1, ASP.NET MVC 5, and Angular 11. Currently, there is no any plan for upgrading the Areas Plugin structures and Angular, such as .NET Core 6 and Angular 14, respectively.
 
The Angular parts of this sample application use the SystemJS module loader with which we can run the Visual Studio built-in debugger for TypeScript debugging. This feature depends on the UMD (Universal Module Definition) type of the Angular and related libraries. The Google Angular team has not provided the UMD JavaScript files since the later versions of Angular 12. If we upgrade the application to Angular 14 (or above later), we need to build own UMD library files from those released files using the *rolllup* tool and functionality.
