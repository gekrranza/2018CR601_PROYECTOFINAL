using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace _2018CR601.Models
{
    public class JoinMascota
    {
        public mascota GetMascota { get; set; }
        public adoptante GetAdoptante { get; set; }
        public cita_paseo GetCita { get; set; }
        public voluntario GetVoluntario { get; set; }

    }
}
