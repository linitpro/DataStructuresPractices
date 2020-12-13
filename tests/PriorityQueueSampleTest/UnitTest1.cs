using System;
using Newtonsoft.Json;
using PriorityQueueSample;
using Xunit;
using Xunit.Abstractions;

namespace PriorityQueueSampleTest
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }
        
        [Fact]
        public void Test1()
        {
            var queue = new PriorityQueue<string>();
            
            queue.Add(1, "as");
            queue.Add(100, "qw");
            queue.Add(10, "er");
            queue.Add(12, "ty");
            queue.Add(50, "gh");
            
            this.output.WriteLine(queue.ToString());
            
            Assert.Equal("as", queue.ExtractMinimum());
            Assert.Equal("qw", queue.ExtractMaximum());
            
            this.output.WriteLine(queue.ToString());
            
            Assert.False(queue.Contains(1));
            Assert.False(queue.Contains(100));
            Assert.True(queue.Contains(12));
        }
    }
}