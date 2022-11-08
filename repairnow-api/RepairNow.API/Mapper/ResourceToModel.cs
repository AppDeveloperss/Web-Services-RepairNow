using AutoMapper;
using RepairNow.Infraestructure;
using RepairNowAPI.Resources;

namespace RepairNowAPI.Mapper;

public class ResourceToModel:Profile
{
    public ResourceToModel()
    {
        CreateMap<UserResource, User>();
        CreateMap<ApplianceResource, Appliance>();
        CreateMap<AppointmentResource,Appointment>();
        CreateMap<ReportResource, Report>();
    }
}