using System.Collections.Generic;
using Vidly_MVCProject.Models;

namespace Vidly_MVCProject.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}