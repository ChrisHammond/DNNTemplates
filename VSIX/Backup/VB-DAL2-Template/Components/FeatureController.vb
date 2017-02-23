' Copyright (c) $year$  $ownername$
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 

Imports System.Globalization
Imports System.Xml
Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Services.Search.Entities

Namespace Components

    ''' <summary>
    ''' The Controller class for $safeprojectname$
    ''' 
    ''' The FeatureController class is defined as the BusinessController in the manifest file (.dnn)
    ''' DotNetNuke will poll this class to find out which Interfaces the class implements. 
    ''' 
    ''' The IPortable interface is used to import/export content from a DNN module
    ''' 
    ''' The ISearchable interface is used by DNN to index the content of a module
    ''' 
    ''' The IUpgradeable interface allows module developers to execute code during the upgrade 
    ''' process for a module.
    ''' 
    ''' Below you will find stubbed out implementations of each, uncomment and populate with your own data
    ''' </summary>
    Public Class FeatureController
        Inherits ModuleSearchBase
        Implements IPortable
        Implements IUpgradeable
        ' feel free to remove any interfaces that you don't wish to use
        ' (requires that you also update the .dnn manifest file)

#Region " Optional Interfaces "

        ''' <summary>
        ''' Gets the modified search documents for the DNN search engine indexer.
        ''' </summary>
        ''' <param name="moduleInfo">The module information.</param>
        ''' <param name="beginDate">The begin date.</param>
        ''' <returns></returns>
        Public Overrides Function GetModifiedSearchDocuments(moduleInfo As ModuleInfo, beginDate As DateTime) As IList(Of SearchDocument)
            Dim searchDocuments = New List(Of SearchDocument)()
            Dim controller = New ItemController()
            Dim items = controller.GetItems(moduleInfo.ModuleID)

            For Each item As Item In items
                If item.LastModifiedOnDate.ToUniversalTime() <= beginDate.ToUniversalTime() OrElse item.LastModifiedOnDate.ToUniversalTime() >= DateTime.UtcNow Then
                    Continue For
                End If

                Dim content = String.Format("{0}<br />{1}", item.ItemName, item.ItemDescription)

                Dim document = New SearchDocument()
                With document
                    ' any unique identifier to be able to query for your individual record
                    .UniqueKey = String.Format("Items:{0}:{1}", moduleInfo.ModuleID, item.ItemId)
                    .PortalId = moduleInfo.PortalID ' the PortalID
                    .TabId = moduleInfo.TabID ' the TabID
                    .AuthorUserId = item.LastModifiedByUserId ' the person who created the content
                    .Title = moduleInfo.ModuleTitle ' the title of the content, but should be the module title
                    .Description = moduleInfo.DesktopModule.Description ' the description or summary of the content
                    .Body = content ' the long form of your content
                    .ModifiedTimeUtc = item.LastModifiedOnDate.ToUniversalTime() ' a time stamp for the search results page
                    .CultureCode = moduleInfo.CultureCode ' the current culture code
                    .IsActive = True ' allows you to remove the item from the search index (great for soft deletes)
                End With

                searchDocuments.Add(document)
            Next

            Return searchDocuments
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' ExportModule implements the IPortable ExportModule Interface
        ''' </summary>
        ''' <param name="moduleId">The Id of the module to be exported</param>
        ''' -----------------------------------------------------------------------------
        Public Function ExportModule(moduleId As Integer) As String Implements IPortable.ExportModule
            Dim controller = New ItemController()
            Dim items = controller.GetItems(moduleId)
            Dim sb = New StringBuilder()

            Dim itemList = If(TryCast(items, IList(Of Item)), items.ToList())

            If Not itemList.Any() Then
                Return String.Empty
            End If

            sb.Append("<Items>")

            For Each item As Item In itemList
                sb.Append("<Item>")

                sb.AppendFormat("<AssignedUserId>{0}</AssignedUserId>", item.AssignedUserId)
                sb.AppendFormat("<CreatedByUserId>{0}</CreatedByUserId>", item.CreatedByUserId)
                sb.AppendFormat("<CreatedOnDate>{0}</CreatedOnDate>", item.CreatedOnDate)
                sb.AppendFormat("<ItemId>{0}</ItemId>", item.ItemId)
                sb.AppendFormat("<ItemDescription>{0}</ItemDescription>", XmlUtils.XMLEncode(item.ItemDescription))
                sb.AppendFormat("<ItemName>{0}</ItemName>", XmlUtils.XMLEncode(item.ItemName))
                sb.AppendFormat("<LastModifiedByUserId>{0}</LastModifiedByUserId>", item.LastModifiedByUserId)
                sb.AppendFormat("<LastModifiedOnDate>{0}</LastModifiedOnDate>", item.LastModifiedOnDate)
                sb.AppendFormat("<ModuleId>{0}</ModuleId>", item.ModuleId)

                sb.Append("</Item>")
            Next

            sb.Append("</Items>")

            ' you might consider doing something similar here for any important module settings

            Return sb.ToString()
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' ImportModule implements the IPortable ImportModule Interface
        ''' </summary>
        ''' <param name="ModuleID">The Id of the module to be imported</param>
        ''' <param name="Content">The content to be imported</param>
        ''' <param name="Version">The version of the module to be imported</param>
        ''' <param name="UserId">The Id of the user performing the import</param>
        ''' -----------------------------------------------------------------------------
        Public Sub ImportModule(moduleId As Integer, content As String, version As String, userId As Integer) Implements IPortable.ImportModule
            Dim controller = New ItemController()
            Dim items = DotNetNuke.Common.Globals.GetContent(content, "Items")
            Dim xmlNodeList = items.SelectNodes("Item")

            If xmlNodeList Is Nothing Then
                Return
            End If

            For Each item As XmlNode In xmlNodeList
                ' assigning everything to the current UserID, because this might be a new DNN installation
                ' your use case might be different though
                Dim newItem = New Item()
                With newItem
                    .ModuleId = moduleId
                    .CreatedByUserId = userId
                    .LastModifiedByUserId = userId
                    .CreatedOnDate = DateTime.Now
                    .LastModifiedOnDate = DateTime.Now
                End With

                ' NOTE: If moving from one installation to another, this user will not exist
                newItem.AssignedUserId = Integer.Parse(item.SelectSingleNode("AssignedUserId").InnerText, NumberStyles.[Integer])
                newItem.ItemDescription = item.SelectSingleNode("ItemDescription").InnerText
                newItem.ItemName = item.SelectSingleNode("ItemName").InnerText

                controller.CreateItem(newItem)
            Next
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' UpgradeModule implements the IUpgradeable Interface
        ''' </summary>
        ''' <param name="Version">The current version of the module</param>
        ''' -----------------------------------------------------------------------------
        Public Function UpgradeModule(version As String) As String Implements IUpgradeable.UpgradeModule
            Try
                Select Case version
                    Case "00.00.01"
                        ' run your custom code here
                        Return "success"
                    Case Else
                        Return "success"
                End Select
            Catch
                Return "failure"
            End Try
        End Function

#End Region

    End Class

End Namespace