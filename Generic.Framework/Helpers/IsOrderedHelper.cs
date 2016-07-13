using System.Collections.Generic;
using System.Linq;
using Generic.Framework.Enumerations;
using Generic.Framework.Interfaces;

namespace Generic.Framework.Helpers
{
    public class IsOrderedHelper
    {
        public static void MoveWithinList<T>(IEnumerable<T> list, T mover, OrderMovement orderMovement) where T : class, IIsOrdered
        {
            //Firm up enumeration problems
            list = list.ToList();

            //Ensure contiguousnes
            MakeContiguous(list);

            if(mover.Order == 0 && orderMovement == OrderMovement.Down)
                return;//Nothing to do because this is already the first in the list

            if (mover.Order == list.Count() && orderMovement == OrderMovement.Up)
                return;//Nothing to do because this is already the last in the list

            int delta;

            switch (orderMovement)
            {
                case OrderMovement.Up:
                    delta = -1;
                    break;
                case OrderMovement.Down:
                    delta = 1;
                    break;
                default:
                    throw new System.NotImplementedException();
            }
            

            foreach (var iIsOrdered in list.OrderBy(i => i.Order))
            {
                if(iIsOrdered.Order == mover.Order + delta)
                {
                    iIsOrdered.Order += -1 * delta;
                    mover.Order += delta;
                    
                    break; //There is no need to continue
                }
            }
        }

        public static void MakeContiguous<T>(IEnumerable<T> list) where T : class, IIsOrdered
        {
            int order = 0;
            foreach (var iIsOrdered in list.OrderBy(i => i.Order))
            {
                iIsOrdered.Order = order;
                order++;
            }
        }

        public static bool IsContiguous<T>(IEnumerable<T> list) where T : class, IIsOrdered
        {
            int expectedOrder = 0;

            foreach (var iIsOrdered in list.OrderBy(i => i.Order))
            {
                if (iIsOrdered.Order != expectedOrder)
                    return false;

                expectedOrder++;
            }

            //we got this far - this is good
            return true;
        }
    }
}
