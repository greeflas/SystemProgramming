namespace App.Models
{
    class Goods
    {
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public string ManufacturerName { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public decimal GoodCount { get; set; }

        public override string ToString()
        {
            return $"{GoodName}";
        }
    }
}
