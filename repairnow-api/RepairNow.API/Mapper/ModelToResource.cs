using AutoMapper;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using RepairNow.Infraestructure;
using RepairNowAPI.Resources;
using RepairNowAPI.Response;

namespace RepairNowAPI.Mapper;

public class ModelToResource: Profile
{
    public ModelToResource()
    {
        CreateMap<User, UserResource>();
        CreateMap<Appliance, ApplianceResource>();
        CreateMap<Appointment, AppointmentResource>();
        CreateMap<Report, ReportResource>();
        CreateMap<User, AutenthicateResponse>();
    }
}