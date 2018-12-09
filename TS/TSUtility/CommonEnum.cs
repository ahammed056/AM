using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSUtility
{
    public class CommonEnum
    {
    }

    /// <summary>
    /// Summary description for DropDownOption
    /// </summary>
    public enum DropDownOption
    {
        _Select = -1,
        _All = 0,
        _NA = -2
    }

    #region [ Modules ]

    public enum CMDBModule
    {
        ITTS = 1001,
        ITPRO = 1002
       
    }

    #endregion

    #region [ MasterTypes ]
       
    public enum ITTS_MasterType
    {
        _Select = -1,
        Task = 1001,
        Application = 1002,
    }
    public enum ITPRO_MasterType
    {
        _Select = -1,
        District = 1001,
        Mandal = 1002,
        Village = 1003,
        ProofType = 1004,
        VisitStatus = 1005
    }

    #endregion

    #region [ Approvals ]

    public enum ApprovalType
    {
        General = 1,
        L1 = 2,
        L2 = 3
    }

    public enum ApprovalStatus
    {
        Addition_Pending_for_L1_Approval = 1,
        Addition_Approved_by_L1 = 2,
        Addition_Rejected_by_L1 = 3,
        Addition_Approved_by_L2 = 4,
        Addition_Rejected_by_L2 = 5,
        Updation_Pending_for_L1_Approval = 6,
        Updation_Approved_by_L1 = 7,
        Updation_Rejected_by_L1 = 8,
        Updation_Approved_by_L2 = 9,
        Updation_Rejected_by_L2 = 10,
        Deletion_Pending_for_L1_Approval = 11,
        Deletion_Approved_by_L1 = 12,
        Deletion_Rejected_by_L1 = 13,
        Deletion_Approved_by_L2 = 14,
        Deletion_Rejected_by_L2 = 15,
        Pending_for_Updation = 16
    }

    public enum ApprovalLevel
    {
        L1 = 1,
        L2 = 2,
        Approved = 3,
        Rejected = 4,
        Deleted = 5,
        Addition = 6
    }

    public enum ITTS_UserRole
    {
        General = 1,
        TS_Admin = 2,
        TS_Manager = 3
    }

    public enum ITPRO_UserRole
    {
        General = 1,
        PRO_Admin = 2,
    }


    #endregion

   
}
