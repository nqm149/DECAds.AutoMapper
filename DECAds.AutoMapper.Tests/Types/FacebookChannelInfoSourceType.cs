using System;
using System.Collections.Generic;

namespace DECAds.AutoMapper.Tests.Types
{
    public class FacebookChannelInfoSourceType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FacebookChannelInfoSourceType()
        {
            UserFacebooks = new HashSet<FacebookUserSourceType>();
        }

        public string FacebookBotId { get; set; }
        public string ClientName { get; set; }
        public string CoreBotId { get; set; }
        public string AppSecret { get; set; }
        public string PageToken { get; set; }
        public string VerifyToken { get; set; }
        public string Owner { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public bool IsUsed { get; set; }
        public string Id { get; set; }
        public Nullable<bool> DeleteFlag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacebookUserSourceType> UserFacebooks { get; set; }
    }
}
