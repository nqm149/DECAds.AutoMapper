using System;
using System.Collections.Generic;

namespace DECAds.AutoMapper.Tests.Types
{
    public class LineChannelInfoSourceType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LineChannelInfoSourceType()
        {
            this.UserLines = new HashSet<LineUserLineSourceType>();
        }
        public string LineBotId { get; set; }
        public string ClientName { get; set; }
        public string CoreBotId { get; set; }
        public string ChannelSecret { get; set; }
        public string ChannelToken { get; set; }
        public string Owner { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public bool IsUsed { get; set; }
        public string Id { get; set; }
        public Nullable<bool> DeleteFlag { get; set; }
        public string QRCodeUrl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LineUserLineSourceType> UserLines { get; set; }

    }
}