using PlanningRZA.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningRZA.Models.Equipments
{ 
    public class Breaker : Equipment
    { 
       public BreakerAppointment Appointment { get; set; }
       public BreakerType Type { get; set; }

       public override string ToString()
       {
           return $"Breaker  {base.ToString()}";
       }
    }
}
