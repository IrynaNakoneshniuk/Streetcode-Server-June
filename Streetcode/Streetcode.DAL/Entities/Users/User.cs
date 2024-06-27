﻿using Streetcode.DAL.Entities.Base;

using Streetcode.DAL.Enums;

namespace Streetcode.DAL.Entities.Users
{
    public class User : IEntityId<int>
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Login { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public UserRole Role { get; set; }
    }
}
