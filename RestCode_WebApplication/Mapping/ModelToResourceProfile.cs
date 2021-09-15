using AutoMapper;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Product, ProductResource>();
            CreateMap<Restaurant, RestaurantResource>();
            CreateMap<Consultant, ConsultantResource>();
            CreateMap<Publication, PublicationResource>();
            CreateMap<Comment, CommentResource>();
            CreateMap<Assignment, AssignmentResource>();
            CreateMap<Owner, OwnerResource>();
            CreateMap<Sale, SaleResource>();
            CreateMap<SaleDetail, SaleDetailResource>();
            CreateMap<Appointment, AppointmentResource>();
            CreateMap<Consultancy, ConsultancyResource>();
        }
    }
}
