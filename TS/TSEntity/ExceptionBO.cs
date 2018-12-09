using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSEntity
{
    public class ExceptionBO
    {

        #region [ Contructors ]

        public ExceptionBO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region [ Objects ]

        public string TrackerID { get; set; }
        public string FileName { get; set; }
        public string Method { get; set; }
        public int LineNumber { get; set; }
        public int ColumnNumber { get; set; }
        public string Class { get; set; }
        public string Exception { get; set; }
        public string InnerException { get; set; }
        public string HostName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<ExceptionBO> Exceptions { get; set; }

        #endregion

    }
}
