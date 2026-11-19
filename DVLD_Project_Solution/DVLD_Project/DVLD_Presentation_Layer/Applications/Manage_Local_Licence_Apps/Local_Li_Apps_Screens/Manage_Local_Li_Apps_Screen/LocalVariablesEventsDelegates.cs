using DVLD_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Presentation_Layer.Applications.Manage_Local_Driving_Licence_Applications.Local_Driving_License_Applications_Screens.Manage_Local_Driving_License_Applications_Screen
{
    public partial class frmManageLocalLiApp
    {
        //------------------ Initialize Variables--------------------------

        private DataTable _dtAllLocalDrivingLicenseApplications;

        private enum enFilterBy { None = 0, LocalDVLsAppID = 1, NationalNo = 2, FullName = 3, AppStatus = 4 };
        private enFilterBy _CurrentSelectedFilter;

        // ----------------Local Events ---------------------------------------

        public event Action<clsApplication.enApplicationStatus> OnApplicationStatusUpdated;
        protected virtual void ApplicationStatusUpdated(clsApplication.enApplicationStatus NewApplicationStatus)
        {
            OnApplicationStatusUpdated?.Invoke(NewApplicationStatus);
        }

        public event Action OnApplicationStatusNotUpdated;
        protected virtual void ApplicationStatusNotUpdated()
        {
            OnApplicationStatusNotUpdated?.Invoke();
        }



    

        public event Action OnLocalDrivingLicenseApplicationDeleted;
        protected virtual void LocalDrivingLicenseApplicationDeleted()
        {
            OnLocalDrivingLicenseApplicationDeleted?.Invoke();
        }

        public event Action OnLocalDrivingLicenseApplicationNotDeleted;
        protected virtual void LocalDrivingLicenseApplicationNotDeleted()
        {
            OnLocalDrivingLicenseApplicationNotDeleted?.Invoke();
        }



    }
}
