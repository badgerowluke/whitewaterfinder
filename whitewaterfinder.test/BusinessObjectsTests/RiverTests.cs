using System;
using System.Collections.Generic;
using whitewaterfinder.BusinessObjects.Rivers;
using Xunit;
namespace whitewaterfinder.test.BusinessobjectsTests
{
    public class RiverExtensionTests
    {
        [Fact]
        public void RiverExtensions_DoesReturnDataArray()
        {
            var river = new River();
            var array = river.PopulateRiverData();
            Assert.NotNull(array);
        }
        [Fact]
        public void RiverExtensions_ReturnedArrayHasFlowData()
        {
            var river = new River()
            {
                Flow = new List<RiverData>(){
                    new RiverData()
                    {
                        DateTime = DateTime.Now,
                        
                    }
                }.ToArray()
            };
        }

    }
}