using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool IsMaintenance { get; set; }
        public bool IsAvailable
        {
            get
            {
                if (this.IsMaintenance || this.HasGuest)
                {
                    return false;
                }
                return true;
            }
        }
        public bool HasGuest { get { return true; } }
    }
}
