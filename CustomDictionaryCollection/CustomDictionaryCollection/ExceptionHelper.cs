using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionaryCollection
{
    public class ExceptionHelper : Exception
    {
        public ExceptionHelper()
            : base() { }

        public ExceptionHelper(string message)
            : base(message) { }

        public ExceptionHelper(string format, params object[] args)
            : base(string.Format(format, args)) { }
    }
}
