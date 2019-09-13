using System;
using System.Collections.Generic;

namespace Bookish.Web.Models {
    public class BookExceptionList {
        public IEnumerable<Exception> Exceptions { get; set; }
        
        public BookExceptionList(IEnumerable<Exception> exceptions) {
            Exceptions = exceptions;
        }
    }
}