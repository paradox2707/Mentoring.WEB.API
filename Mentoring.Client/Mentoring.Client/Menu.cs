using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.Client
{
    enum Menu
    {
        [Description("Університети")]
        Universities = 1,
        [Description("Спеціальності")]
        Specialities,
        [Description("Університети зі спеціальностями")]
        SpecialitiesWithSpecialities
    }
}
