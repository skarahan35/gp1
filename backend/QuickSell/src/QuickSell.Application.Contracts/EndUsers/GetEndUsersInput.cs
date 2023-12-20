using Volo.Abp.Application.Dtos;
using System;

namespace QuickSell.EndUsers
{
    public class GetEndUsersInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        public string  UserName { get; set; } 
        public string  Name { get; set; } 
        public string  SurName { get; set; } 
        public string  EMail { get; set; } 
        public string  PhoneNumber { get; set; } 
        public string  Address { get; set; } 
        public string  Password { get; set; } 
             
        public GetEndUsersInput()
        {

        }
    }
}
