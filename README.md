Christoc's DotNetNuke Module and Theme Development Template
==========

Project Description
-----------
Quick and easy to use Module and Theme (skin) Development templates for DNN 9 and Visual Studio 2022.

If you need support for older versions of Visual Studio check out previous [releases on GitHub](https://github.com/ChrisHammond/DNNTemplates/releases).

[Blog Announcement for the 2.0 release of the templates project](https://www.chrishammond.com/Blog/itemid/2616/using-the-new-module-development-templates-for-dot)
[For instructions on how to modify the templates read this post](https://christoc.com/Tutorials/All-Tutorials/Customizing-the-latest-DotNetNuke-Module-Development-Project-Templates)

*After you build in Release Mode the installable packages (source/install) can be found in the INSTALL folder now, within your module's folder, not the packages folder anymore*

Installation instructions
-----------
* Download the VSIX from [GitHub Releases](https://github.com/ChrisHammond/DNNTemplates/releases), or find the Project in the [Visual Studio Gallery](https://visualstudiogallery.msdn.microsoft.com/bdd506ef-d5c3-4274-bf1d-9e673fb23484)

V11.1 - DNN 9 Visual Studio 2022 (2/24/2022) 
-----------
Correcting support for all editions of Visual Studio 2022


V11.0 - DNN 9 Visual Studio 2022 (1/5/2022) 
-----------
Support for Visual Studio 2022
Fix to C# Dal2 Mod when editing an item without any users assigned


V10.3 - DNN 9 Visual Studio 2019 (12/7/2021) 
-----------
[Issue # 65 fix for hardcoded dnndev.me in theme template](https://github.com/ChrisHammond/DNNTemplates/issues/65)  


V10.2 - DNN 9 Visual Studio 2019 (03/01/2021) 
-----------
[Issue # 63 fix(es)](https://github.com/ChrisHammond/DNNTemplates/issues/63)  
Updated Module DNN requirement to DNN 9.8.0 if you're using anything less, you are doing it wrong. UPGRADE YOUR SITES PEOPLE  
Upgraded Target Framework to 4.7.2 for all projects, updated other necessary references as well.


V10.1 DNN 7/8/9 Visual Studio 2019 (6/16/2020)
-----------
Updated Visual Studio version number in Template files  
Updated Bootstrap in C# Theme project to V3.4.1  
Added additional notes to documentation after new project creation.


V10.0 DNN 7/8/9 Visual Studio 2019 (4/9/2019)
-----------
Updated to Visual Studio 2019


V9.1 DNN 7/8/9 Visual Studio 2017 (3/11/2018)
-----------
Pull Request: Shane Walker, Updates to support multiple namespaces for defaults (SKIN and MODULE), fixes for Project Dialog bugs if closing before completion.


V9.0 DNN 7/8/9 Visual Studio 2017 (2/23/2017)
-----------
Upgraded templates for Visual Studio 2017 Support  
Upgraded to MSBuildTasks 1.5.0.235


V8.0 DNN 7/8/9 Visual Studio 2015 (1/1/2017)
-----------
MVC Template fixes  
Upgraded to Bootstrap 3.3.7 for Theme template  
Fixed White link problem  
Upgraded to MSBuildTasks 1.5.0.214  
Tested against DNN 9

V7.1 DNN 7/8 Visual Studio 2015 (3/9/2016)
-----------
MVC Fix for better Intellisense management in the CSHTML files.


V7 DNN 7/8 Visual Studio 2015 (2/24/2016)
-----------
Added Wizard interface for configuring "owner" and "dev" information for Projects  
MVC Template fixes  
Upgraded to MSBuildTasks V1.4.0.128  
Fixed SPA Settings manifest to QuickSettings  
Upgraded Target Framework to 4.5.1 for all projects  
Upgraded to Bootstrap 3.3.6 for Theme template

V6.1 Beta for Visual Studio 2015 (1/16/2016)
-----------
Initial Release of the DNN8 MVC Template

V6 Beta for Visual Studio 2015 (1/13/2016)
-----------
Initial Release of the DNN8 SPA Template

V5 for Visual Studio 2015 (7/31/2015)
-----------
Initial release with Visual Studio 2015 support. 

V4.1 - Release Date 4/20/2015
-----------
Description: Upgraded Bootstrap to V3.3.4  
Fixes for Bootstrap load order causing DNN Dropdown list issues  
Fix for DNNRadio button conflict with Bootstrap.

Changes for V4.0 (01/04/2015)
-----------
Description: Upgraded to MSBuildTasks V1.4.0.88  
Added a new Theme (skin) template  
Updates to copyright year

Changes for V3.0 (06/18/2014)
-----------
Update to only support VS 2013 (should fix VS 2013 Express issues)  
Updated module package targets file to exclude .git folder  
Updated MSBuildTasks project to v1.4.0.74

Changes for V2.5 (11/13/2013)
-----------
Updated for Visual Studio 2013 support (still supports 2012)

Changes for V2.4 (6/10/2013)
-----------
Updated MSBuild Community Tasks reference to 1.4.0.61

Changes for V2.3 (6/6/2013)
-----------
This release fixes a BusinessController namespace issue, and has updated documentation included in the project templates to try to address issues that you might run into.

Changes for V2.2 (4/3/2013)
-----------
This release addresses an issue with the release build location, and changes default namespace, company name, and a few other properties. This release also upgrades the reference to MSBuildTasks (1.4.0.56)

Changes for V2.1 (1/28/2013)
-----------
This release addresses an issue with template modification and namespace problems.
[For instructions on how to modify the templates read this post](https://christoc.com/Tutorials/All-Tutorials/Customizing-the-latest-DotNetNuke-Module-Development-Project-Templates)

Changes for V2.0 (1/24/2013)
-----------
Requires DNN 7.0.2+
Uses DNNDEV.ME for the development environment URL instead of DNNDEV (requires no host file changes)
Includes two new templates that create a functioning DAL2 module, one for C# and one for VB.net
VSIX Download from Codeplex should work in VS Web Dev Express and all paid versions of Visual Studio 2012 (the VS Gallery package does not work on Express)

Changes for v1.1
-----------
Complete rewrite for Visual Studio 2012
Visual Studio Gallery Support

Changes for 00.00.09
-----------
Fixed C# template that was still hard coded in the CSPROJ file to DNNDEV
Changes to .DNN file for SOURCE installs to keep the .DNN file in place

Changes for 00.00.08
-----------
Fixed a couple of VB issues that didn't have the same code as the C# template
Added comments to the .CS/.VB files at the top to explain the files/classes a bit
Added documentation link to the Task Manager series for module development

Changes for 00.00.07
-----------
This release has updates to the DNN manifest file for DotNetNuke 6
Commented out examples of the Form Pattern in the Settings user control

Changes for 00.00.06
-----------
This release includes a License.Txt and ReleasNotes.txt file in the project and manifest files. 
We also created a property in the VS Project file for CopyrightYear. 
The three DotNetNuke interfaces in the Components/FeatureController file are commented out instead of being enabled by default.
The Manifest File has been updated for DotNetNuke 6, thus 6.0.0 is now a dependency.

This project is maintained by [Chris Hammond](https://www.chrishammond.com)
