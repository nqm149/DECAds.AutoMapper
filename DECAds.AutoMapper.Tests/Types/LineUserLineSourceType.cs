using System;
using System.Collections.Generic;

namespace DECAds.AutoMapper.Tests.Types
{
    public class LineUserLineSourceType
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LineUserLineSourceType()
        {
            ChannelInfoes = new HashSet<LineChannelInfoSourceType>();
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string LineUserId { get; set; }
        public string DisplayName { get; set; }
        public string PictureUrl { get; set; }
        public string StatusMessage { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LineChannelInfoSourceType> ChannelInfoes { get; set; }
    }
}