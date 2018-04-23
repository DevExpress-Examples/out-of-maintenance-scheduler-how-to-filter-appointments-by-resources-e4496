using System.Collections;
using System.Linq;
using DevExpressMvcApplication1;
using DevExpress.Web.Mvc;
using System.Collections.Generic;

public class SchedulerDataObject {
    public IEnumerable Appointments { get; set; }
    public IEnumerable Resources { get; set; }
}

public class SchedulerDataHelper {
    public static IEnumerable GetResources() {
        SchedulingDataClassesDataContext db = new SchedulingDataClassesDataContext();
        return from res in db.DBResources select res;
    }
    public static IEnumerable GetAppointments() {
        SchedulingDataClassesDataContext db = new SchedulingDataClassesDataContext();
        return from apt in db.DBAppointments select apt;
    }
    public static IEnumerable GetAppointmentsFilteredByResources(List<int> resourceIds) {
        SchedulingDataClassesDataContext db = new SchedulingDataClassesDataContext();
        return from apt in db.DBAppointments
               where resourceIds.Contains(apt.ResourceID.Value) 
               select apt;
    }
    public static SchedulerDataObject DataObject {
        get {
            return new SchedulerDataObject() {
                Appointments = GetAppointments(),
                Resources = GetResources()
            };
        }
    }
    public static SchedulerDataObject GetDataObjectFilteredByResources(List<int> resourceIds) {
        return new SchedulerDataObject() {
            Appointments = GetAppointmentsFilteredByResources(resourceIds),
            Resources = GetResources()
        };
    }

    static MVCxAppointmentStorage defaultAppointmentStorage;
    public static MVCxAppointmentStorage DefaultAppointmentStorage {
        get {
            if (defaultAppointmentStorage == null)
                defaultAppointmentStorage = CreateDefaultAppointmentStorage();
            return defaultAppointmentStorage;
        }
    }

    static MVCxAppointmentStorage CreateDefaultAppointmentStorage() {
        MVCxAppointmentStorage appointmentStorage = new MVCxAppointmentStorage();
        appointmentStorage.Mappings.AppointmentId = "UniqueID";
        appointmentStorage.Mappings.Start = "StartDate";
        appointmentStorage.Mappings.End = "EndDate";
        appointmentStorage.Mappings.Subject = "Subject";
        appointmentStorage.Mappings.Description = "Description";
        appointmentStorage.Mappings.Location = "Location";
        appointmentStorage.Mappings.AllDay = "AllDay";
        appointmentStorage.Mappings.Type = "Type";
        appointmentStorage.Mappings.RecurrenceInfo = "RecurrenceInfo";
        appointmentStorage.Mappings.ReminderInfo = "ReminderInfo";
        appointmentStorage.Mappings.Label = "Label";
        appointmentStorage.Mappings.Status = "Status";
        appointmentStorage.Mappings.ResourceId = "ResourceID";
        return appointmentStorage;
    }

    static MVCxResourceStorage defaultResourceStorage;
    public static MVCxResourceStorage DefaultResourceStorage {
        get {
            if (defaultResourceStorage == null)
                defaultResourceStorage = CreateDefaultResourceStorage();
            return defaultResourceStorage;
        }
    }
    static MVCxResourceStorage CreateDefaultResourceStorage() {
        MVCxResourceStorage resourceStorage = new MVCxResourceStorage();
        resourceStorage.Mappings.ResourceId = "ResourceID";
        resourceStorage.Mappings.Caption = "ResourceName";
        return resourceStorage;
    }
}