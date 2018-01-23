using System;
using System.Collections.Generic;

namespace DECAds.AutoMapper.Tests.Types
{
    public class LineUserLineViewModel
    {
        public LineUserLineViewModel()
        {
            ChannelInfoes = new HashSet<LineChannelInfoViewModel>();
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string LineUserId { get; set; }
        public string DisplayName { get; set; }
        public string PictureUrl { get; set; }
        public string StatusMessage { get; set; }
        public DateTime? LastUpdate { get; set; }
        public virtual ICollection<LineChannelInfoViewModel> ChannelInfoes { get; set; }
    }
}
