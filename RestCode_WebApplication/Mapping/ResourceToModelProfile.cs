using AutoMapper;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Mapping
{
    public class ResourceToModelProfile : AutoMapper.Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveProductResource, Product>();
            CreateMap<SaveRestaurantResource, Restaurant>();
            CreateMap<SaveConsultantResource, Consultant>();
            CreateMap<SavePublicationResource, Publication>();
            CreateMap<SaveCommentResource, Comment>();
            CreateMap<SaveAssignmentResource, Assignment>();
            CreateMap<SaveOwnerResource, Owner>();
            CreateMap<SaveSaleResource, Sale>();
            CreateMap<SaveSaleDetailResource, SaleDetail>();
            CreateMap<SaveAppointmentResource, Appointment>();
            CreateMap<SaveConsultancyResource, Consultancy>();
        }
    }
}
