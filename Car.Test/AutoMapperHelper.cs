using AutoMapper;
using Car.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Test
{
    static class AutoMapperHelper
    {
        private readonly static MapperConfiguration _mapperConfiguration;

        static AutoMapperHelper()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<MachineProfile>();
                cfg.AddProfile<CommentProfile>();
                cfg.AddProfile<BrandProfile>();
            });
        }

        public static IMapper GetMapper()
        {
            return new Mapper(_mapperConfiguration);
        }
    }
}
