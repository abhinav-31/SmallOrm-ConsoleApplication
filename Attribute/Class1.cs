namespace AttributeLib
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Table : Attribute
    {
        private string name;

        public string Name { get => name; set => name = value; }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class Column : Attribute
    {
        private string name;
        private string datatype;
        private string key;
        private string increment;
        private string linktotable;
        private string deletecascade;
        private string linktocolumn;

        public string Name { get => name; set => name = value; }
        public string Datatype { get => datatype; set => datatype = value; }
        public string Key { get => key; set => key = value; }
        public string Increment { get => increment; set => increment = value; }
        public string Linktotable { get => linktotable; set => linktotable = value; }
        public string Deletecascade { get => deletecascade; set => deletecascade = value; }
        public string Linktocolumn { get => linktocolumn; set => linktocolumn = value; }
    }
}
