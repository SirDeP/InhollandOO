namespace QueueOpdr
{
    public class QueueElement
    {
        private int _data;

        public QueueElement? Next { get; set; }
        public QueueElement? Prev { get; set; }
        public int Data { get => _data; }

        public QueueElement(int data, QueueElement element)
        {
            _data = data;
            Prev = element;
        }

        public void Print()
        {
            Console.WriteLine(_data);

            if (Next != null)
            { 
                Next.Print();
            }
        }
    }
}
