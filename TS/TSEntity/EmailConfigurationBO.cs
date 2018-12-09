using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSEntity
{
    public class EmailConfigurationBO
    {
        #region [ Contructors ]

        public EmailConfigurationBO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region [ Objects ]

        public int ApprovalTypeID { get; set; }
        public string ApprovalType { get; set; }
        public string EmailID { get; set; }
        public string DL { get; set; }
        public string Module { get; set; }
        public int ApprovalStatusID { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<EmailConfigurationBO> EmailConfigurations { get; set; }

        #endregion

    }
}
