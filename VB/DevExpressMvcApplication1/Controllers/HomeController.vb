Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.XtraScheduler

Namespace DevExpressMvcApplication1.Views
	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult
			Return View(SchedulerDataHelper.DataObject)
		End Function

        Public Function SchedulerPartial() As ActionResult
            Dim resourcesString As String = If((Request.Params("SelectedResources") IsNot Nothing), (Request.Params("SelectedResources")), String.Empty)
            Dim resourcesIds = If((resourcesString <> String.Empty), resourcesString.Split(";"c).[Select](Function(n) Convert.ToInt32(n)).ToList(), New List(Of Integer)())

            Return PartialView("SchedulerPartial", SchedulerDataHelper.GetDataObjectFilteredByResources(resourcesIds))
        End Function
	End Class
End Namespace
