namespace CodeCamp2008.DIP
{
    public class Product
    {
        private int _id;
        private string _name;
        private string _category;

        public Product(int id, string name, string category)
        {
            _id = id; 
            _name = name;
            _category = category;
        }
        
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}