using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository
{
    public class PhoneNumberRepository : Repository<PhoneNumber>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(RepositoryContext context) : base(context) { }

        public async Task<PhoneNumber> GetUnassignedPhoneNumberAsync()
        {
            // Fetch phone numbers that are not linked by any AssignedNumber
            var assignedPhoneNumberIds = RepositoryContext.AssignedNumbers
                                                 .Select(an => an.PhoneNumberId)
                                                 .Distinct();

            var unassignedPhoneNumber = await RepositoryContext.PhoneNumbers
                                                      .Where(pn => !assignedPhoneNumberIds.Contains(pn.Id))
                                                      .FirstOrDefaultAsync();

            return unassignedPhoneNumber;
        }
    }
}
