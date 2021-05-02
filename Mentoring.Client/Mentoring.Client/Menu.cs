using System.ComponentModel;

namespace Mentoring.Client
{
    enum Menu
    {
        [Description("Університети")]
        Universities = 1,
        [Description("Спеціальності")]
        Specialities,
        [Description("Університети зі спеціальностями")]
        SpecialitiesWithSpecialities,
        [Description("Анкета")]
        Application
    }
}
