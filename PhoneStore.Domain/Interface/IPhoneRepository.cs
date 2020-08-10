using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneStore.Domain.Entities;


namespace PhoneStore.Domain.Interface
{
    public interface IPhoneRepository
    {
        IEnumerable<Phone> Phones { get; }
        void SavePhone(Phone phone);
        Phone DeletePhone(int phoneId);
    }
}
