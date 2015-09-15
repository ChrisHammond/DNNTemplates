' Copyright (c) $Year$ $YourCompany$
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
Imports DotNetNuke.Entities.Modules



''' -----------------------------------------------------------------------------
''' <summary>
''' The Edit$safeprojectname$ class is used to manage content
''' 
''' Typically your edit control would be used to create new content, or edit existing content within your module.
''' The ControlKey for this control is "Edit", and is defined in the manifest (.dnn) file.
''' 
''' Because the control inherits from $safeprojectname$ModuleBase you have access to any custom properties
''' defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
''' 
''' </summary>
''' -----------------------------------------------------------------------------

Partial Class Edit
        Inherits $safeprojectname$ModuleBase

#Region "Private Members"

#End Region

#Region "Event Handlers"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Page_Load runs when the control is loaded
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


        Catch exc As Exception    'Module failed to load
            ProcessModuleLoadException(Me, exc)
        End Try
    End Sub

#End Region

End Class

