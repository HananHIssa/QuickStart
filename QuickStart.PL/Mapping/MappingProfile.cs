using AutoMapper;
using QuickStart.DAL.Data.Models;
using QuickStart.PL.Areas.Dashboard.ViewModels;
namespace QuickStart.PL.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<ServicesFormVm, Services>().ReverseMap();
			CreateMap<Services, vmService>().ReverseMap();
			CreateMap<Services, ServiceDetailsvm>().ReverseMap();
		}
	}
}
