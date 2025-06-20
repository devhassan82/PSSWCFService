using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PSSWCFService.App_Code
{
    public class clsPerformance
    {
        public string EmployeeCode { get; set; }
        public string ProjectCode { get; set; }
        public string RelatedObjective { get; set; }
        public int NoOfTasks { get; set; }
        public int ProjectCompletion { get; set; }
        public int EfficiencyPerformance { get; set; }
        public int AttendancePercentage { get; set; }
        public int YearID { get; set; }
        public int MonthID { get; set; }
        public int CreatedBy { get; set; }
        public DataTable DataTable_EmpPerformance { get; set; }
        public DataTable DataTable_Attendance { get; set; }

    }
}