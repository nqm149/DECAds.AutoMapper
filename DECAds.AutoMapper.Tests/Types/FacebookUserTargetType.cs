using System;
using System.Collections.Generic;

namespace DECAds.AutoMapper.Tests.Types
{
    public class FacebookUserTargetType
    {
        public string Id { get; set; }
        public string FacebookUserId { get; set; }
        public string DisplayName { get; set; }
        public string PictureUrl { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public virtual ICollection<FacebookChannelInfoSourceType> ChannelInfoes { get; set; }

    }
}