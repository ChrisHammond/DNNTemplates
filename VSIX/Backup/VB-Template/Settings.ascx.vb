' Copyright (c) $year$  $ownername$
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
Imports DotNetNuke
Imports DotNetNuke.Services.Exceptions

''' -----------------------------------------------------------------------------
''' <summary>
''' The Settings class manages Module Settings
''' 
''' Typically your settings control would be used to manage settings for your module.
''' There are two types of settings, ModuleSettings, and TabModuleSettings.
''' 
''' ModuleSettings apply to all "copies" of a module on a site, no matter which page the module is on. 
''' 
''' TabModuleSettings apply only to the current module on the current page, if you copy that module to
''' another page the settings are not transferred.
''' 
''' If you happen to save both TabModuleSettings and ModuleSettings, TabModuleSettings overrides ModuleSettings.
''' 
''' Below we have some examples of how to access these settings but you will need to uncomment to use.
''' 
''' Because the control inherits from $safeprojectname$SettingsBase you have access to any custom properties
''' defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
''' </summary>
''' -----------------------------------------------------------------------------
Public Class Settings
    Inherits $safeprojectname$SettingsBase

#Region "Base Method Implementations"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' LoadSettings loads the settings from the Database and displays them
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides Sub LoadSettings()
        Try
            If (Page.IsPostBack = False) Then


                'uncomment to load saved settings in the text boxes
                'if(Settings.Contains("Setting1"))
                '	txtSetting1.Text = Settings("Setting1").ToString()

                'if (Settings.Contains("Setting2"))
                '	txtSetting2.Text = Settings("Setting2")


            End If
        Catch exc As Exception           'Module failed to load
            ProcessModuleLoadException(Me, exc)
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' UpdateSettings saves the modified settings to the Database
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides Sub UpdateSettings()
        Try
            Dim objModules As New Entities.Modules.ModuleController
            'the following are two sample Module Settings, using the text boxes that are commented out in the ASCX file.
            'objModules.UpdateModuleSetting(ModuleId, "Setting1", txtSetting1.Text)
            'objModules.UpdateModuleSetting(ModuleId, "Setting2", txtSetting2.Text)


            'objModules.UpdateTabModuleSetting(TabModuleId, "Setting1", txtSetting1.Text)
            'objModules.UpdateTabModuleSetting(TabModuleId, "Setting2", txtSetting2.Text)

        Catch exc As Exception           'Module failed to load
            ProcessModuleLoadException(Me, exc)
        End Try
    End Sub

#End Region


End Class