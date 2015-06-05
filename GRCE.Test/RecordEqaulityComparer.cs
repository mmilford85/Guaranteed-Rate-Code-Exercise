namespace GRCE.Test
{
    using System.Collections.Generic;

    using GRCE.Domain.Models;

    public sealed class RecordEqualityComparer : IEqualityComparer<Record>
    {
        public bool Equals(Record x, Record y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (ReferenceEquals(x, null))
            {
                return false;
            }

            if (ReferenceEquals(y, null))
            {
                return false;
            }

            if (x.GetType() != y.GetType())
            {
                return false;
            }

            return x.DateOfBirth.Equals(y.DateOfBirth) && string.Equals(x.FavoriteColor, y.FavoriteColor)
                   && x.Gender == y.Gender && string.Equals(x.LastName, y.LastName)
                   && string.Equals(x.FirstName, y.FirstName);
        }

        public int GetHashCode(Record obj)
        {
            unchecked
            {
                int hashCode = obj.DateOfBirth.GetHashCode();
                hashCode = (hashCode * 397) ^ (obj.FavoriteColor != null ? obj.FavoriteColor.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)obj.Gender;
                hashCode = (hashCode * 397) ^ (obj.LastName != null ? obj.LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (obj.FirstName != null ? obj.FirstName.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
