using AutoMapper;
using Core.ClientDataBuilder;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Profiles
{
	public class ClientDataProfile : Profile
	{
		public ClientDataProfile()
		{
			CreateMap<ClientData, Client>();
			CreateMap<ClientData, ForeignerRentContract>();
			CreateMap<ClientData, JuridicalPersonRentContract>()
				.ForMember(dest => dest.DriverLicenseIdentifier,
					opt => opt.MapFrom(src => src.DriverLicenseId));
			CreateMap<ClientData, PhysicalPersonRentContract>();
		}
	}
}
