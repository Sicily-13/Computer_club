[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/GameClub.Models")]
public partial class ArrayOfMessagesMessages
{

    private object computersField;

    private int computersIDField;

    private string contentField;

    private System.DateTime dateField;

    private int idField;

    private object usersField;

    private int usersIDField;

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

    public string Content
    {
        get
        {
            return this.contentField;
        }
        set
        {
            this.contentField = value;
        }
    }

    public System.DateTime Date
    {
        get
        {
            return this.dateField;
        }
        set
        {
            this.dateField = value;
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

