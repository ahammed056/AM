using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TSEntity
{
    public class PROBO
    {
 #region [ Contructors ]

        public PROBO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region [ Objects ]

        #region [ Instances ]

        public string PrId { get; set; }
        public string TransId { get; set; }
        public string VisitorName { get; set; }
        public string FatherName { get; set; }
        public string VillageId { get; set; }
        public string VillageName { get; set; }
        public string MandalId { get; set; }
        public string MandalName { get; set; }
        public string DistId { get; set; }
        public string DistrictName { get; set; }
        public string ProofTypeId { get; set; }
        public string ProofTypeName { get; set; }
        public string ProofId { get; set; }
        public string ContactNo { get; set; }
        public DateTime VisitDate { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string VisitPurpose { get; set; }
        public DateTime NextCallDate { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<PROBO> PRODtls { get; set; }

        #endregion

        #endregion

    }

    public class PROMasterBO
    {

        #region [ Contructors ]

        public PROMasterBO()
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

        public string DistId { get; set; }
        public string MandalId { get; set; }

        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<PROMasterBO> Masters { get; set; }


        #endregion

        #endregion

    }


    public class ITPROSearchCriteria
    {
        #region [ Contructors ]

        public ITPROSearchCriteria()
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
