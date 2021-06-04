using System;

namespace Computer_club
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/GameClub.Models")]
    public partial class ArrayOfOrdersOrders
    {
        private object computersField;

        private int computersIDField;

        private int idField;

        private uint mFTBField;

        private int timeField;

        private object usersField;

        private int usersIDField;

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object Computers
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

        public int ComputersID
        {
            get
            {
                return this.computersIDField;
            }
            set
            {
                this.computersIDField = value;
            }
        }

        public int ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        public uint MFTB
        {
            get
            {
                return this.mFTBField;
            }
            set
            {
                this.mFTBField = value;
            }
        }

        public int Time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object Users
        {
            get
            {
                return this.usersField;
            }
            set
            {
                this.usersField = value;
            }
        }

        public int UsersID
        {
            get
            {
                return this.usersIDField;
            }
            set
            {
                this.usersIDField = value;
            }
        }
    }
}