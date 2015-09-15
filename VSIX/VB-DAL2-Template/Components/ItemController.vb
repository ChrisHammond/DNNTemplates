' Copyright (c) $year$  $ownername$
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 

Imports System.Collections.Generic
Imports DotNetNuke.Data

Namespace Components

    Public Class ItemController
        Public Sub CreateItem(ByVal t As Item)
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep As IRepository(Of Item) = ctx.GetRepository(Of Item)()
                rep.Insert(t)
            End Using
        End Sub

        Public Sub DeleteItem(ByVal t As Integer, ByVal moduleId As Integer)
            Dim _item As Item = GetItem(t, moduleId)
            DeleteItem(_item)
        End Sub

        Public Sub DeleteItem(ByVal t As Item)
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep As IRepository(Of Item) = ctx.GetRepository(Of Item)()
                rep.Delete(t)
            End Using
        End Sub

        Public Function GetItems(ByVal _moduleId As Integer) As IEnumerable(Of Item)
            Dim t As IEnumerable(Of Item)

            Using ctx As IDataContext = DataContext.Instance()
                Dim rep As IRepository(Of Item) = ctx.GetRepository(Of Item)()
                t = rep.Get(_moduleId)
            End Using
            Return t
        End Function

        Public Function GetItem(ByVal itemid As Integer, ByVal moduleId As Integer) As Item
            Dim t As Item

            Using ctx As IDataContext = DataContext.Instance()
                Dim rep As IRepository(Of Item) = ctx.GetRepository(Of Item)()
                t = rep.GetById(Of Int32, Int32)(itemid, moduleId)
            End Using
            Return t
        End Function

        Public Sub UpdateItem(ByVal t As Item)
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep As IRepository(Of Item) = ctx.GetRepository(Of Item)()
                rep.Update(t)
            End Using
        End Sub

    End Class

End Namespace