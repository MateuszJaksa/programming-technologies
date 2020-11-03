using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class EventService
    {
        public abstract string getProperText();
    }
    public class BorrowingService : EventService
    {
        public override string getProperText()
        {
            return " borrowed ";
        }
    }

    public class ReturningService : EventService
    {
        public override string getProperText()
        {
            return " returned ";
        }
    }
}
