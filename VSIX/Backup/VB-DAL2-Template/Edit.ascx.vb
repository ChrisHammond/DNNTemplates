' Copyright (c) $year$  $ownername$
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
Imports $rootnamespace$$safeprojectname$.Components
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Entities.Users


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
Public Class Edit
    Inherits $safeprojectname$ModuleBase


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

            If Not Page.IsPostBack Then
                ddlAssignedUser.DataSource = UserController.GetUsers(PortalId)
                ddlAssignedUser.DataTextField = "Username"
                ddlAssignedUser.DataValueField = "UserId"
                ddlAssignedUser.DataBind()

                If ItemId > 0 Then
                    Dim tc As New ItemController
                    Dim t As Item = tc.GetItem(ItemId, ModuleId)
                    If t IsNot Nothing Then
                        txtName.Text = t.ItemName
                        txtDescription.Text = t.ItemDescription
                        ddlAssignedUser.Items.FindByValue(t.AssignedUserId.ToString()).Selected = True
                    End If
                End If
            End If
        Catch exc As Exception
            Exceptions.ProcessModuleLoadException(Me, exc)
        End Try

    End Sub


    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim t As New Item()
        Dim tc As New ItemController
        If ItemId > 0 Then
            t = tc.GetItem(ItemId, ModuleId)
            t.ItemName = txtName.Text.Trim()
            t.ItemDescription = txtDescription.Text.Trim()
            t.AssignedUserId = Convert.ToInt32(ddlAssignedUser.SelectedValue)

        Else
            t.ItemName = txtName.Text.Trim()
            t.ItemDescription = txtDescription.Text.Trim()
            t.AssignedUserId = Convert.ToInt32(ddlAssignedUser.SelectedValue)

            t.CreatedByUserId = UserId
            t.CreatedOnDate = DateTime.Now
        End If

        t.LastModifiedByUserId = UserId
        t.LastModifiedOnDate = DateTime.Now
        t.ModuleId = ModuleId

        If t.ItemId > 0 Then
            tc.UpdateItem(t)
        Else
            tc.CreateItem(t)
        End If
        Response.Redirect(DotNetNuke.Common.Globals.NavigateURL())
    End Sub
    
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect(DotNetNuke.Common.Globals.NavigateURL())
    End Sub
    
End Class