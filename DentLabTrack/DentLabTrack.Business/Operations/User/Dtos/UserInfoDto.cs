﻿using DentLabTrack.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.Operations.User.Dtos
{
    public class UserInfoDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; set; }

    }
}
