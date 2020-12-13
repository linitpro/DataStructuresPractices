using System;
using System.Collections;
using HashTableSample;
using Xunit;
using Xunit.Abstractions;

namespace HashTableSampleTests
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper outputHelper;

        public UnitTest1(ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
        }
        
        [Fact]
        public void Test1()
        {
            var hashTable = new HashTable<HashTableItem>();
            hashTable.Add(new HashTableItem("Asd", 12));
            hashTable.Add(new HashTableItem("Asd", 12));
            hashTable.Add(new HashTableItem("Asd", 26));
            hashTable.Add(new HashTableItem("Qwe", 45));
            hashTable.Add(new HashTableItem("Tyu", 20));
            
            this.outputHelper.WriteLine(hashTable.ToString());
            
            hashTable.Remove("Asd_12");
            var foundedResults = hashTable.Find("Asd_12");
            Assert.NotNull(foundedResults);
            Assert.Empty(foundedResults);

            foundedResults = hashTable.Find("Asd_26");
            Assert.NotNull(foundedResults);
            Assert.NotEmpty(foundedResults);
            var foundedResult = foundedResults[0];
            Assert.NotNull(foundedResult);
            Assert.Equal("Asd", foundedResult.Name);
            Assert.Equal(26, foundedResult.Age);
            
            hashTable.Remove(foundedResult);
            foundedResults = hashTable.Find("Asd_26");
            Assert.NotNull(foundedResults);
            Assert.Empty(foundedResults);
        }
    }
}