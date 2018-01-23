using System.Collections.Generic;
using AutoMapper;
using DECAds.AutoMapper.Tests.Types;
using NUnit.Framework;
using Shouldly;

namespace DECAds.AutoMapper.Tests
{
    [TestFixture]
    public class AutoMapperServiceTest
    {
        private IAutoMapperService _autoMapperService;

        [SetUp]
        public void Setup()
        {
            _autoMapperService = new AutoMapperService();
//            _autoMapperService.AddBidirectionalMapper<FacebookChannelInfoSourceType, FacebookChannelInfoTargetType>();
//            _autoMapperService.AddBidirectionalMapper<FacebookUserSourceType, FacebookUserTargetType>();
        }

        [Test]
        public void AutoMapperService_AddedSpecificMapperToList_ReturnCorrectMapper()
        {
            //Arrange
            AutoMapperService.AddBidirectionalMapper<FacebookChannelInfoSourceType, FacebookChannelInfoTargetType>();
            AutoMapperService.AddBidirectionalMapper<FacebookUserSourceType, FacebookUserTargetType>();

            //Act
            var STmapper1 = AutoMapperService.GetMapper<FacebookChannelInfoSourceType, FacebookChannelInfoTargetType>();
            var STmapper2 = AutoMapperService.GetMapper<FacebookChannelInfoTargetType, FacebookChannelInfoSourceType>();
            var TSmapper1 = AutoMapperService.GetMapper<FacebookUserSourceType, FacebookUserTargetType>();
            var TSmapper2 = AutoMapperService.GetMapper<FacebookUserTargetType, FacebookUserSourceType>();

            //Assert
            STmapper1.ShouldBeOfType(typeof(Mapper));
            STmapper2.ShouldBeOfType(typeof(Mapper));
            TSmapper1.ShouldBeOfType(typeof(Mapper));
            TSmapper2.ShouldBeOfType(typeof(Mapper));

        }

        [Test]
        public void AutoMapperService_GivenLineSourceTypeObject_ReturnLineTargetTypeObject()
        {
            //Arrange
            var eId = "000";
            var eAppSecret = "appsecret1234";
            var eIsUsed = true;

            var channelInfoSourceObj = new LineChannelInfoSourceType()
            {
                Id = eId,
                IsUsed = eIsUsed
            };

            var facebookUserSourceObj = new FacebookUserSourceType
            {
                Id = "111",
            };

            //Act
            var channelInfoResult = _autoMapperService.Map<LineChannelInfoSourceType, LineChannelInfoViewModel>(channelInfoSourceObj);
//            var userResult = _autoMapperService.Map<FacebookUserSourceType, FacebookUserTargetType>(facebookUserSourceObj);

            //Assert
            channelInfoResult.GetType().ShouldBe(typeof(LineChannelInfoViewModel));
            channelInfoResult.Id.ShouldBe(eId);
            channelInfoResult.IsUsed.ShouldBe(eIsUsed);

//            userResult.GetType().ShouldBe(typeof(FacebookUserTargetType));
//            userResult.Id.ShouldBe("111");
        }

        [Test]
        public void AutoMapperService_GivenSourceTypeObject_ReturnTargetTypeObject()
        {
            //Arrange
            var eId = "000";
            var eAppSecret = "appsecret1234";
            var eIsUsed = true;

            var channelInfoSourceObj = new FacebookChannelInfoSourceType
            {
                Id = eId,
                AppSecret = eAppSecret,
                IsUsed = eIsUsed
            };

            var facebookUserSourceObj = new FacebookUserSourceType
            {
                Id = "111",
            };

            //Act
            var channelInfoResult = _autoMapperService.Map<FacebookChannelInfoSourceType, FacebookChannelInfoTargetType>(channelInfoSourceObj);
            var userResult = _autoMapperService.Map<FacebookUserSourceType, FacebookUserTargetType>(facebookUserSourceObj);

            //Assert
            channelInfoResult.GetType().ShouldBe(typeof(FacebookChannelInfoTargetType));
            channelInfoResult.Id.ShouldBe(eId);
            channelInfoResult.AppSecret.ShouldBe(eAppSecret);
            channelInfoResult.IsUsed.ShouldBe(eIsUsed);

            userResult.GetType().ShouldBe(typeof(FacebookUserTargetType));
            userResult.Id.ShouldBe("111");
        }

        [Test]
        public void AutoMapperService_GivenListSourceTypeObject_ReturnListTargetTypeObject()
        {
            //Arrange
            var eId = "001";
            var eAppSecret = "appsecret1234";
            var eIsUsed = true;
            var eId2 = "002";

            var channelInfoSourceObj = new LineChannelInfoSourceType()
            {
                Id = eId,
                IsUsed = eIsUsed
            };
            var channelInfoSourceObj2 = new LineChannelInfoSourceType()
            {
                Id = eId2,
                IsUsed = eIsUsed
            };
            var channelInfoSourceObjs = new List<LineChannelInfoSourceType>
            {
                channelInfoSourceObj, channelInfoSourceObj2
            };

            var userSourceObj = new LineUserLineSourceType()
            {
                Id = eId,
            };
            var userSourceObj2 = new LineUserLineSourceType()
            {
                Id = eId2,
            };
            var userSourceObjs = new List<LineUserLineSourceType>
            {
                userSourceObj, userSourceObj2
            };

            //Act
            IEnumerable<LineChannelInfoViewModel> channelInfoListResult = _autoMapperService.Map<LineChannelInfoSourceType, LineChannelInfoViewModel>(channelInfoSourceObjs);
            IEnumerable<LineUserLineViewModel> userListResult = _autoMapperService.Map<LineUserLineSourceType, LineUserLineViewModel>(userSourceObjs);

            //Assert
            channelInfoListResult.GetType().ShouldBe(typeof(List<LineChannelInfoViewModel>));
            foreach (var result in channelInfoListResult)
            {
                result.IsUsed.ShouldBe(eIsUsed);
            }

            userListResult.GetType().ShouldBe(typeof(List<LineUserLineViewModel>));
            foreach (var result in userListResult)
            {
                result.Id.ShouldContain("00");
            }
        }

        [Test]
        public void AutoMapperService_GivenTargetTypeObject_ReturnSourceTypeObject()
        {
            //Arrange
            var eId = "000";
            var eAppSecret = "appsecret1234";
            var eIsUsed = true;

            var channelInfoTargetObj = new FacebookChannelInfoTargetType
            {
                Id = eId,
                AppSecret = eAppSecret,
                IsUsed = eIsUsed
            };

            var facebookUserTargetObj = new FacebookUserTargetType
            {
                Id = "111",
            };

            //Act
            var channelInfoResult = _autoMapperService.Map<FacebookChannelInfoTargetType, FacebookChannelInfoSourceType>(channelInfoTargetObj);
            var userResult = _autoMapperService.Map<FacebookUserTargetType, FacebookUserSourceType>(facebookUserTargetObj);

            //Assert
            channelInfoResult.GetType().ShouldBe(typeof(FacebookChannelInfoSourceType));
            channelInfoResult.Id.ShouldBe(eId);
            channelInfoResult.AppSecret.ShouldBe(eAppSecret);
            channelInfoResult.IsUsed.ShouldBe(eIsUsed);

            userResult.GetType().ShouldBe(typeof(FacebookUserSourceType));
            userResult.Id.ShouldBe("111");
        }

        [Test]
        public void AutoMapperService_GivenListTargetTypeObject_ReturnListSourceTypeObject()
        {
            //Arrange
            var eId = "001";
            var eAppSecret = "appsecret1234";
            var eIsUsed = true;
            var eId2 = "002";

            var channelInfoTargetObj = new FacebookChannelInfoTargetType
            {
                Id = eId,
                AppSecret = eAppSecret,
                IsUsed = eIsUsed
            };
            var channelInfoTargetObj2 = new FacebookChannelInfoTargetType
            {
                Id = eId2,
                AppSecret = eAppSecret,
                IsUsed = eIsUsed
            };
            var channelInfoTargetObjs = new List<FacebookChannelInfoTargetType>
            {
                channelInfoTargetObj, channelInfoTargetObj2
            };

            var facebookUserTargetObj = new FacebookUserTargetType
            {
                Id = eId,
            };
            var facebookUserTargetObj2 = new FacebookUserTargetType
            {
                Id = eId2,
            };
            var facebookUserTargetObjs = new List<FacebookUserTargetType>
            {
                facebookUserTargetObj, facebookUserTargetObj2
            };

            //Act
            var channelInfoListResult = _autoMapperService.Map<FacebookChannelInfoTargetType, FacebookChannelInfoSourceType>(channelInfoTargetObjs);
            var userListResult = _autoMapperService.Map<FacebookUserTargetType, FacebookUserSourceType>(facebookUserTargetObjs);

            //Assert
            channelInfoListResult.GetType().ShouldBe(typeof(List<FacebookChannelInfoSourceType>));
            foreach (var result in channelInfoListResult)
            {
                result.AppSecret.ShouldBe(eAppSecret);
                result.IsUsed.ShouldBe(eIsUsed);
            }

            userListResult.GetType().ShouldBe(typeof(List<FacebookUserSourceType>));
            foreach (var result in userListResult)
            {
                result.Id.ShouldContain("00");
            }
        }

        [Test]
        public void AutoMapperService_TryAddSameMapperItem_ReturnOneMapperItem()
        {
            //Arrange
            var mapperItemSet = new HashSet<MapperItem>();
            var dbType = typeof(FacebookChannelInfoSourceType);
            var uiType = typeof(FacebookChannelInfoTargetType);

            //Act
            mapperItemSet.Add(new MapperItem(dbType, uiType, null));
            mapperItemSet.Add(new MapperItem(dbType, uiType, null));
            mapperItemSet.Add(new MapperItem(dbType, uiType, null));

            //Assert
            mapperItemSet.Count.ShouldBe(1);
        }
    }
}
