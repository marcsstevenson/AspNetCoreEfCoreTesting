using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Framework.Helpers.ExceptionHanlding
{
    public static class ExceptionHelper
    {
        public static Exception GetInnerMostException(this Exception exception)
        {
            var innerMostexception = exception;

            while (innerMostexception.InnerException != null)
                innerMostexception = innerMostexception.InnerException;

            return innerMostexception;
        }
    }
}
