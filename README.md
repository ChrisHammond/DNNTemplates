 Christoc's DotNetNuke Module and Theme Development Template
==========

Project Description
-----------
Quick and easy to use Module and Theme (skin) Development templates for DotNetNuke 7.0.2+ and DNN 8 and Visual Studio 2015.

The latest release (6+) of the templates are for Visual Studio 2015. If you need a VS2008/10/12/13 support check out the older releases on Codeplex. https://christoctemplate.codeplex.com/releases/

Blog Announcement for the 2.0 release of the templates project http://www.chrishammond.com/blog/itemid/2616/using-the-new-module-development-templates-for-dot.aspx
For instructions on how to modify the templates read this post http://www.christoc.com/tutorials/aid/3

*After you build in Release Mode the installable packages (source/install) can be found in the INSTALL folder now, within your module's folder, not the packages folder anymore*

Installation instructions
-----------
* Download the VSIX from GitHub, or find the Project in the [Visual Studio Gallery](https://visualstudiogallery.msdn.microsoft.com/bdd506ef-d5c3-4274-bf1d-9e673fb23484)


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
For instructions on how to modify the templates read this post http://www.christoc.com/tutorials/aid/3

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

This project is maintained by Chris Hammond http://www.chrishammond.com