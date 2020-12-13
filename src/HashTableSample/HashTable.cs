using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace HashTableSample
{
    /// <summary>
    /// Хэштаблица
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public class HashTable<TItem> where TItem: IHashTableItem
    {
        private readonly Md5 md5;
        private readonly Dictionary<string, List<TItem>> hashTable;
        
        public HashTable(int hashTableCapacity = 100)
        {
            this.md5 = new Md5();
            this.hashTable = new Dictionary<string, List<TItem>>(hashTableCapacity);
        }

        /// <summary>
        /// Добавляет новый элемент в хэштаблицу
        /// </summary>
        /// <param name="item"></param>
        public void Add(TItem item)
        {
            this.TryArgumentNullException(item?.GetKey(), nameof(item));
            var hash = this.GetHash(item?.GetKey());
            
            if (this.hashTable.ContainsKey(hash))
            {
                this.hashTable[hash].Add(item);
            }
            else
            {
                this.hashTable.Add(hash, new List<TItem>() {item});
            }
        }

        /// <summary>
        /// Удаляет объект из хэштаблицы
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Remove(TItem item)
        {
            this.TryArgumentNullException(item?.GetKey(), nameof(item));
            
            var hash = this.GetHash(item?.GetKey());

            var items = this.hashTable[hash];

            if (items?.Count > 0)
            {
                items.Remove(item);

                if (items.Count == 0)
                {
                    this.hashTable.Remove(hash);
                }
            }
        }

        /// <summary>
        /// Удаляет данные из хэштаблицы по ключу.
        /// Предупреждение! Если по хэшу содержится более одного элемента, будут удалены все
        /// </summary>
        /// <param name="key"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Remove(string key)
        {
            this.TryArgumentNullException(key, nameof(key));
            this.hashTable.Remove(this.GetHash(key));
        }

        /// <summary>
        /// Возвращает найденные по ключу элементы
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<TItem> Find(string key)
        {
            this.TryArgumentNullException(key, nameof(key));
            var hash = this.GetHash(key);

            if (this.hashTable.ContainsKey(hash))
            {
                return this.hashTable[hash];
            }
            else
            {
                return new List<TItem>();
            }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this.hashTable);
        }

        /// <summary>
        /// Генерирует исключение, если аргумент является пустой строкой или нулл
        /// </summary>
        /// <param name="value"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        private void TryArgumentNullException(string value, string argumentName = "arg")
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(argumentName);
            }
        }
        
        private string GetHash(string value)
        {
            this.TryArgumentNullException(value, nameof(value));
            return this.md5.CreateMd5(value);
        }
        
        
    }
}