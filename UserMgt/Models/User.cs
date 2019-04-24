using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMgt.Models
{
    public class User
    {
        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("username")]
        public string username{ get; set; }

        [JsonProperty("firstname")]
        public string firstname{ get; set; }

        [JsonProperty("lastname")]
        public string lastname{ get; set; }

        [JsonProperty("email")]
        public string email{ get; set; }

        [JsonProperty("passwordHash")]
        public string passwordHash{ get; set; }

        [JsonProperty("gender")]
        public string gender{ get; set; }

        [JsonProperty("dateOfBirth")]
        public DateTime dateOfBirth{ get; set; }

        [JsonProperty("nationality")]
        public string nationality{ get; set; }

        [JsonProperty("phoneNumber")]
        public string phoneNumber{ get; set; }

        [JsonProperty("location")]
        public string location{ get; set; }

        [JsonProperty("primaryGenre")]
        public string primaryGenre{ get; set; }

        [JsonProperty("biography")]
        public string biography{ get; set; }

        [JsonProperty("website")]
        public string website{ get; set; }

        [JsonProperty("profileImagePath")]
        public string profileImagePath{ get; set; }

        [JsonProperty("coverImagePath")]
        public string coverImagePath{ get; set; }

        [JsonProperty("following")]
        public long following{ get; set; }

        [JsonProperty("followers")]
        public long followers{ get; set; }

        [JsonProperty("role")]
        public string role{ get; set; }

        [JsonProperty("accountVerificationStatus")]
        public string accountVerificationStatus{ get; set; }

        [JsonProperty("dateCreated")]
        public DateTime dateCreated{ get; set; }

        [JsonProperty("lockOutEnabled")]
        public bool lockOutEnabled{ get; set; }

        //[JsonProperty("lockOutEndDateUtc")]
        //public DateTime lockOutEndDateUtc{ get; set; }

        
    }
}
