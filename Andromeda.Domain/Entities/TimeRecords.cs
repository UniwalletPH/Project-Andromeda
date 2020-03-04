using Andromeda.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Andromeda.Domain.Entities
{
    [Table("tbl_TimeRecord")]
    public class TimeRecords
    {
        public int ID { get; set; }

        public DateTime Time { get; set; }

        public RecordType RecordType { get; set; }

        public int EmployeeDetailsID { get; set; }

        public EmployeeDetails EmployeeDetails { get; set; }

    }
}
