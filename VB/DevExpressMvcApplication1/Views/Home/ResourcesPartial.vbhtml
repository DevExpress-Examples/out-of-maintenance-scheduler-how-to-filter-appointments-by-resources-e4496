<table>
    <tr>
        <td>
            @Html.DevExpress().Label( _
            Sub(settings)
                    settings.Name = "ResourcesLabel"
                    settings.Width = System.Web.UI.WebControls.Unit.Pixel(220)
                    settings.Text = "Visible Appointments in Resources: "
            End Sub).GetHtml()
        </td>
        <td>
            @Html.DevExpress().DropDownEdit( _
            Sub(settings)
                    settings.Name = "checkComboBox"
                    settings.Width = 210
                    settings.Properties.DropDownWindowStyle.BackColor = System.Drawing.Color.FromArgb(&HEDEDED)

                    settings.SetDropDownWindowTemplateContent( _
                    Sub()
                            Html.DevExpress().ListBox( _
                            Sub(listBoxSettings)
                                    listBoxSettings.Name = "checkListBox"
                                    listBoxSettings.ControlStyle.Border.BorderWidth = 0
                                    listBoxSettings.ControlStyle.BorderBottom.BorderWidth = 1
                                    listBoxSettings.ControlStyle.BorderBottom.BorderColor = System.Drawing.Color.FromArgb(&HDCDCDC)
                                    listBoxSettings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
                                    listBoxSettings.Properties.SelectionMode = ListEditSelectionMode.CheckColumn
                                    listBoxSettings.Properties.ClientSideEvents.SelectedIndexChanged = "OnListBoxSelectionChanged"
                                    listBoxSettings.Properties.ClientSideEvents.Init = "OnListBoxSelectionChanged"
                                    listBoxSettings.Properties.ValueField = "ResourceID"
                                    listBoxSettings.Properties.TextField = "ResourceName"
                                    listBoxSettings.PreRender = _
                                    Sub(s, e)
                                            Dim lb As ASPxListBox = CType(s, ASPxListBox)
                                            lb.Items.Insert(0, New ListEditItem() With {.Text = "Select All", .Value = -1})
                                            lb.SelectAll()
                                    End Sub
                            End Sub).BindList(SchedulerDataHelper.GetResources()).Render()

                            ViewContext.Writer.Write("<table style=""width:100%""><tr><td align=""right"">")
                            Html.DevExpress().Button( _
                            Sub(buttonSettings)
                                    buttonSettings.Name = "buttonClose"
                                    buttonSettings.Text = "Close"
                                    buttonSettings.Style.Add("float", "right")
                                    buttonSettings.ClientSideEvents.Click = "OnCloseButtonClick"
                            End Sub).Render()
                            ViewContext.Writer.Write("</td></tr></table>")
                    End Sub)

                    settings.Properties.AnimationType = AnimationType.None
                    settings.Properties.ClientSideEvents.TextChanged = "SynchronizeListBoxValues"
                    settings.Properties.ClientSideEvents.DropDown = "SynchronizeListBoxValues"
                    settings.Properties.ClientSideEvents.CloseUp = "OnDropDownClose"
            End Sub).GetHtml()
        </td>
    </tr>
</table>