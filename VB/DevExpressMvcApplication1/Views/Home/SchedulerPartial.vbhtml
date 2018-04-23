@Html.DevExpress().Scheduler( _
    Sub(settings)
            settings.Name = "scheduler"
            settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "SchedulerPartial"}
            settings.Storage.Appointments.Assign(SchedulerDataHelper.DefaultAppointmentStorage)
            settings.Storage.Resources.Assign(SchedulerDataHelper.DefaultResourceStorage)

            settings.OptionsCustomization.AllowAppointmentCreate = UsedAppointmentType.None
            settings.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.None
            settings.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.None

            settings.ActiveViewType = SchedulerViewType.Timeline
            settings.GroupType = SchedulerGroupType.Resource

            settings.Start = New DateTime(2012, 4, 18)
            settings.ClientSideEvents.BeginCallback = "OnBeginSchedulerCallback"

    End Sub).Bind(Model.Appointments, Model.Resources).GetHtml()