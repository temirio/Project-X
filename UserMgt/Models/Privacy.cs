using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UserMgt.Models
{
    public enum Privacy
    {
        [DefaultValue("Public")]
        PUBLIC,
        [DefaultValue("Your followers")]
        FOLLOWERS,
        [DefaultValue("People you follow")]
        FOLLOWING,
        [DefaultValue("You follow each other")]
        FOLLOWBACK,
        [DefaultValue("Only you")]
        PRIVATE
    }
}
