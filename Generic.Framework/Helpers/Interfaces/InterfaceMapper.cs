using Generic.Framework.Interfaces;
using Generic.Framework.Interfaces.Entity;
using Generic.Framework.Interfaces.Personal;

namespace Generic.Framework.Helpers.Interfaces
{
    public static class InterfaceMapper
    {
        public static void UpdateEntity(this IEntity to, IEntity from)
        {
            to.Id = from.Id;
            to.UpdateTracksTime(from);
        }

        public static void UpdateName(this IName to, IName from)
        {
            to.Name = from.Name;
        }
        
        public static void UpdateTracksTime(this ITracksTime to, ITracksTime from)
        {
            to.DateCreated = from.DateCreated;
            to.DateModified = from.DateModified;
        }

        public static void UpdateDescription(this IDescription to, IDescription from)
        {
            to.Description = from.Description;
        }

        public static void UpdateIsEnabled(this IIsEnabled to, IIsEnabled from)
        {
            to.IsEnabled = from.IsEnabled;
        }

        public static void UpdateIsOrdered(this IIsOrdered to, IIsOrdered from)
        {
            to.Order = from.Order;
        }

        public static void UpdateVolumeCc(this IVolumeCc to, IVolumeCc from)
        {
            to.VolumeCc = from.VolumeCc;
        }

        public static void UpdateWeightKg(this IWeightKg to, IWeightKg from)
        {
            to.WeightKg = from.WeightKg;
        }

        public static void UpdateCode(this ICode to, ICode from)
        {
            to.Code = from.Code;
        }

        public static void UpdatePrice(this IPrice to, IPrice from)
        {
            to.Price = from.Price;
        }

        public static void UpdateIsDefault(this IIsDefault to, IIsDefault from)
        {
            to.IsDefault = from.IsDefault;
        }

        public static void UpdatePerson(this IPerson to, IPerson from)
        {
            to.UpdateFirstName(from);
            to.UpdateMiddleName(from);
            to.UpdateLastName(from);
        }

        public static void UpdateFirstName(this IFirstName to, IFirstName from)
        {
            to.FirstName = from.FirstName;
        }

        public static void UpdateMiddleName(this IMiddleName to, IMiddleName from)
        {
            to.MiddleName = from.MiddleName;
        }

        public static void UpdateLastName(this ILastName to, ILastName from)
        {
            to.LastName = from.LastName;
        }

        public static void UpdateOrder(this IIsOrdered to, IIsOrdered from)
        {
            to.Order = from.Order;
        }

        public static void UpdateIntRange(this IIntRange to, IIntRange from)
        {
            to.StartValue = from.StartValue;
            to.EndValue = from.EndValue;
        }

        public static void UpdateIRailedClass(this IRailedNameAndDescription to, IRailedNameAndDescription from)
        {
            to.UpdateName(from);
            to.UpdateDescription(from);
            to.UpdateTracksTime(from);
        }
    }
}
