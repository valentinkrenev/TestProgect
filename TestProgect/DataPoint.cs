namespace TestProgect
{
    public struct DataPoint
    {
        public int Metric { get; set; }
        public int Value { get; set; }

        public DataPoint(int metric, int value)
        {
            Metric = metric;
            Value = value;
        }
    }
}
