using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DECAds.AutoMapper.Tests.Types
{
    public class LineChannelInfoViewModel
    {
        public LineChannelInfoViewModel()
        {
            UserLines = new HashSet<LineUserLineViewModel>();
        }

        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        [MaxLength(10), MinLength(10)]
        public string LineBotId { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public string CoreBotId { get; set; }

        [Required]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string ChannelSecret { get; set; }

        [Required]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string ChannelToken { get; set; }

        public string Owner { get; set; }

        public DateTime? LastUpdate { get; set; }

        public bool IsUsed { get; set; }

        public string Id { get; set; }

        public bool? DeleteFlag { get; set; }

        public string QRCodeUrl { get; set; }

        public virtual ICollection<LineUserLineViewModel> UserLines { get; set; }
    }
}
