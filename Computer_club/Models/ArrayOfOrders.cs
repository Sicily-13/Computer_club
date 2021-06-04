namespace Computer_club
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/GameClub.Models")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/GameClub.Models", IsNullable = false)]
    public partial class ArrayOfOrders
    {
        private ArrayOfOrdersOrders[] ordersField;

        [System.Xml.Serialization.XmlElementAttribute("Orders")]
        public ArrayOfOrdersOrders[] Orders
        {
            get
            {
                return this.ordersField;
            }
            set
            {
                this.ordersField = value;
            }
        }
    }



}
