using System;
using System.ComponentModel.DataAnnotations;

namespace DECAds.AutoMapper.Tests.Types
{

        public class FacebookChannelInfoTargetType

        {

            [Display(Name = "FBBotId")]

            //[Required(ErrorMessageResourceName = "FacebookBotIdIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]

            //[RegularExpression("([0-9]+)", ErrorMessageResourceName = "OnlyNumber", ErrorMessageResourceType = typeof(Resources.Resources))]

            [MaxLength(15), MinLength(15)]

            public string FacebookBotId { get; set; }



            [Display(Name = "ClientName")]

            //[Required(ErrorMessageResourceName = "ClientNameIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]

            public string ClientName { get; set; }


            [Display(Name = "CoreBotId")]

            //[Required(ErrorMessageResourceName = "CoreBotIdisrequired", ErrorMessageResourceType = typeof(Resources.Resources))]

            public string CoreBotId { get; set; }


            [Display(Name = "AppSecret")]

            //[Required(ErrorMessageResourceName = "AppSecretisrequired", ErrorMessageResourceType = typeof(Resources.Resources))]

            //[RegularExpression(@"^\S*$", ErrorMessageResourceName = "Nowhitespaceallowed", ErrorMessageResourceType = typeof(Resources.Resources))]

            public string AppSecret { get; set; }


            [Display(Name = "PageToken")]

            //[Required(ErrorMessageResourceName = "PageTokenIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]

            //[RegularExpression(@"^\S*$", ErrorMessageResourceName = "Nowhitespaceallowed", ErrorMessageResourceType = typeof(Resources.Resources))]

            public string PageToken { get; set; }


            [Display(Name = "VerifyToken")]

            //[Required(ErrorMessageResourceName = "VerifyTokenIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]

            public string VerifyToken { get; set; }


            public string Owner { get; set; }


            public DateTime? LastUpdate { get; set; }


            public bool IsUsed { get; set; }


            public string Id { get; set; }


            public bool? DeleteFlag { get; set; }

        }
    
}