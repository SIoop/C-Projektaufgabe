﻿using System;
using System.Runtime.Serialization;

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
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (Username != null ? Username.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Firstname != null ? Firstname.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Lastname != null ? Lastname.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Password != null ? Password.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ IsAdmin.GetHashCode();
                hashCode = (hashCode * 397) ^ Version;
                return hashCode;
            }
        }
    }
}