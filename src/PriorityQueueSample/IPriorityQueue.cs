namespace PriorityQueueSample
{
    public interface IPriorityQueue<TValue>
    {
        public void Add(int key, TValue value);

        public TValue ExtractMinimum();

        public TValue ExtractMaximum();
    }
}