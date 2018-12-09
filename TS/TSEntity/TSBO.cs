using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSEntity
{
    public class TSBO
    {

        #region [ Contructors ]

        public TSBO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region [ Objects ]

        #region [ Instances ]

        public string SRNo { get; set; }
        public string TaskId { get; set; }
        public string TaskName { get; set; }
        public string ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string Description { get; set; }
        public DateTime TSDate { get; set; }
        public string TSDateDisplay { get; set; }
        public string TSHrs { get; set; }
        public string TSId { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public int TSFlag { get; set; }
                        
        public string RequestorEmail { get; set; }
        public string ToEmail { get; set; }
        public string CCEmail { get; set; }
        public DateTime CurrDate { get; set; }
        public DateTime StartDate { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ToEmailID { get; set; }
        public string CCEmailID { get; set; }
        public List<TSBO> Instances { get; set; }

        #endregion

        #endregion

    }

    public class TSMasterBO
    {

        #region [ Contructors ]

        public TSMasterBO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region [ Objects ]

        #region [ Masters ]

        public int MasterType { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<TSMasterBO> Masters { get; set; }

        #endregion

        #endregion

    }


    public class ITTSSearchCriteria
    {
        #region [ Contructors ]

        public ITTSSearchCriteria()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region [ Objects ]

        #region [ Search fields ]

        public string EmpId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        #endregion

        #endregion

    }
}
