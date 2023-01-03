namespace MongoDBCRUD.Models
{
    public record DatabaseNameModel
    {
        public string Name { get; set; }
        public long SizeOnDisk { get; set; }
        public bool IsEmpty { get; set; }

        public DatabaseNameModel(string name, long sizeOnDisk, bool isEmpty)
        {
            this.Name = name;
            this.SizeOnDisk = sizeOnDisk;
            this.IsEmpty = isEmpty;
        }
    }
}
