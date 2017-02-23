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
Imports DotNetNuke.Entities.Modules.Actions
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization
Imports $rootnamespace$$safeprojectname$.Components
Imports DotNetNuke.UI.Utilities

''' <summary>
''' The View class displays the content
''' 
''' Typically your view control would be used to display content or functionality in your module.
''' 
''' View may be the only control you have in your project depending on the complexity of your module
''' 
''' Because the control inherits from $safeprojectname$ModuleBase you have access to any custom properties
''' defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
''' 
''' </summary>
Partial Class View
    Inherits $safeprojectname$ModuleBase
    Implements IActionable

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Page_Load runs when the control is loaded
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try

            Dim tc As New ItemController()
            rptItemList.DataSource = tc.GetItems(ModuleId)
            rptItemList.DataBind()

        Catch exc As Exception
            Exceptions.ProcessModuleLoadException(Me, exc)
        End Try

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Registers the module actions required for interfacing with the portal framework
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property ModuleActions() As ModuleActionCollection Implements IActionable.ModuleActions
        Get
            Dim Actions As New ModuleActionCollection
            Actions.Add(GetNextActionID, Localization.GetString("EditModule", LocalResourceFile), Entities.Modules.Actions.ModuleActionType.AddContent, "", "", EditUrl(), False, DotNetNuke.Security.SecurityAccessLevel.Edit, True, False)
            Return Actions
        End Get
    End Property

    Protected Sub rptItemListOnItemDataBound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs) Handles rptItemList.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim lnkEdit As HyperLink = e.Item.FindControl("lnkEdit")
            Dim lnkDelete As LinkButton = e.Item.FindControl("lnkDelete")
            Dim pnlAdmin As Panel = e.Item.FindControl("pnlAdmin")
            Dim t As Item = e.Item.DataItem

            If IsEditable And lnkDelete IsNot Nothing And lnkEdit IsNot Nothing Then
                pnlAdmin.Visible = True
                lnkDelete.CommandArgument = t.ItemId.ToString()
                lnkDelete.Enabled = True
                lnkDelete.Visible = True
                lnkEdit.Enabled = True
                lnkEdit.Visible = True
                lnkEdit.NavigateUrl = EditUrl(String.Empty, String.Empty, "Edit", "tid=" + t.ItemId.ToString())
                ClientAPI.AddButtonConfirm(lnkDelete, Localization.GetString("ConfirmDelete", LocalResourceFile))
            Else
                pnlAdmin.Visible = False
            End If
        End If
    End Sub

    Protected Sub rptItemListOnItemCommand(ByVal sender As Object, ByVal e As RepeaterCommandEventArgs) Handles rptItemList.ItemCommand
        If e.CommandName = "Delete" Then
            Dim tc As New ItemController
            tc.DeleteItem(e.CommandArgument, ModuleId)
        End If
        Response.Redirect(DotNetNuke.Common.Globals.NavigateURL())
    End Sub
End Class