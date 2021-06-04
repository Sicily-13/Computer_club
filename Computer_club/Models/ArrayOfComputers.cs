using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_club
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/GameClub.Models")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/GameClub.Models", IsNullable = false)]
    public partial class ArrayOfComputers
    {

        private ArrayOfComputersComputers[] computersField;
        [System.Xml.Serialization.XmlElementAttribute("Computers")]
        public ArrayOfComputersComputers[] Computers
        {
            get
            {
                return this.computersField;
            }
            set
            {
                this.computersField = value;
            }
        }
    }
}
