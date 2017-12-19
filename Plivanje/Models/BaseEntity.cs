using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Plivanje
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
    }
}