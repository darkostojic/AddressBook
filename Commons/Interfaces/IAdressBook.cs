using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.Interfaces
{
    public interface IAdressBook
    {
        IContact ContactsDataSource();
        IContactNumber ContactNumbersDataSource();

    }
}
