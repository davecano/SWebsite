using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z
{
    /// <summary>
    /// 实体错误异常
    /// </summary>
    public class EntityErrorException : Exception
    {
        public virtual object Entity { get; set; }

        public EntityErrorException()
        {

        }

        public EntityErrorException(string message)
        {

        }

        public EntityErrorException(string message, object entity)
        {

        }


        public EntityErrorException(string message, Exception innerException)
            : base(message, innerException)
        {


        }

        public EntityErrorException(string message, object entity, Exception innerException)
        {

        }
    }
}
