using Labostic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.ViewModels
{
    public class VmNavbar
    {
        public List<Doctor> Doctor { get; set; }
        public Doctor Doctors { get; set; }
        //public List<Social> Social { get; set; }
        public Appointment Appointment { get; set; }
    }
}
