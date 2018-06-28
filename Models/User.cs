using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Models.Annotations;

namespace Models
{
    [DataContract]
    public class User : BaseModel
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string Username { get; set; }
        [DataMember] public string Firstname { get; set; }
        [DataMember] public string Lastname { get; set; }
        [DataMember] public string Password { get; set; }
        [DataMember] public bool IsAdmin { get; set; }
        [DataMember] public int Version { get; set; }

        protected bool Equals(User other)
        {
            return Id == other.Id && string.Equals(Username, other.Username) &&
                   string.Equals(Firstname, other.Firstname) && string.Equals(Lastname, other.Lastname) &&
                   string.Equals(Password, other.Password) && IsAdmin == other.IsAdmin;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User) obj);
        }
    }
}