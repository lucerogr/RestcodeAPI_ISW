using System;
namespace RestCode_WebApplication.Resources
{
    public class AssignmentResource
    {
        public int Id { get; set; }
        public bool State { get; set; }
        public int RestaurantId { get; set; }
        public int ConsultantId { get; set; }
    }
}
