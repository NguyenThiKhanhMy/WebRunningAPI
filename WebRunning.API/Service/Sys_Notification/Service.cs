﻿using Microsoft.EntityFrameworkCore;
using WebRunning.API.Infrastructure;
using WebRunning.Lib.Constant;
using WebRunning.Lib.Helpers;
using WebRunning.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRunning.API.Service.Sys_Notification
{
    public class Service:RepositoryBase<Model.Sys_Notification>, Sys_Notification.IService
    {
        private readonly DomainDbContext _dbContext;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUserProvider _userProvider;
        public Service(DomainDbContext dbContext, IDateTimeProvider dateTimeProvider, IUserProvider userService):base(dbContext, dateTimeProvider, userService)
        {
            _dbContext = dbContext;
            _dateTimeProvider = dateTimeProvider;
            _userProvider = userService;
        }
    }
}
