[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/GameClub.Models")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/GameClub.Models", IsNullable = false)]
public partial class ArrayOfMessages
{

    private ArrayOfMessagesMessages[] messagesField;

    [System.Xml.Serialization.XmlElementAttribute("Messages")]
    public ArrayOfMessagesMessages[] Messages
    {
        get
        {
            return this.messagesField;
        }
        set
        {
            this.messagesField = value;
        }
    }
}

