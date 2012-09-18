using System;
using System.ComponentModel.DataAnnotations;

namespace FootFace.Core.Infrastructure.Validation
{
    public class RequiredForeignKeyAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            if (value is Int16 || value is Int32 || value is Int64)
            {
                return (Convert.ToInt64(value) != 0);
            }

            if (value is UInt16 || value is UInt32 || value is UInt64)
            {
                return (Convert.ToUInt64(value) != 0);
            }

            if (value is Guid)
            {
                return ((Guid)value != Guid.Empty);
            }

            return base.IsValid(value);
        }
    }
}
