using System;
using System.Security;

namespace HashTableSample
{
    public class HashTableItem: IHashTableItem
    {
        public HashTableItem(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        
        public string Name { set; get; }
        
        public int Age { set; get; }

        public string GetKey() => $"{this.Name}_{this.Age}";
    }
}