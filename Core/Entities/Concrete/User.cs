using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
