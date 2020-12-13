using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace PriorityQueueSample
{
    public class PriorityQueue<TValue>: IPriorityQueue<TValue>
    {
        private readonly SortedDictionary<int, TValue> queue;

        public PriorityQueue()
        {
            this.queue = new SortedDictionary<int, TValue>();
        }
        
        /// <summary>
        /// Добавляет элемент в очередь
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(int key, TValue value)
        {
            this.queue.Add(key, value);
        }

        /// <summary>
        /// Проверяет, содержит ли очередь элемент по его индексу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(int key)
        {
            return this.queue.ContainsKey(key);
        }
        
        /// <summary>
        /// Извлекает и возвращает минимальный элемент из очереди
        /// </summary>
        /// <returns></returns>
        public TValue ExtractMinimum()
        {
            var value = this.queue.First();
            this.queue.Remove(value.Key);
            return value.Value;
        }

        /// <summary>
        /// Извлекает и возвращает максимальный элемент из очереди
        /// </summary>
        /// <returns></returns>
        public TValue ExtractMaximum()
        {
            var value = this.queue.Last();
            this.queue.Remove(value.Key);
            return value.Value;
        }

        /// <summary>
        /// Возвращает строку, представляющую очередь
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this.queue);
        }
    }
}