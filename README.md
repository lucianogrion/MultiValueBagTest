# MultiValueBagTest
MultiValueBagTest : the Latest proj is ConsoleMultiValueBagTestRestrict

Vstudio 2022


```
using NUnitLite;
using System.Reflection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
 
  
// TASK: Write an implementation that will FUNCTIONALLY pass the Test
// CHALLENGE: Try to avoid using Dictionary<Tkey, List<TValue>>
public class MultiValueBag<TKey, TValue>
{
    public MultiValueBag()
    {
    }

    public void AddValue(TKey key, TValue value)
    {
        throw new NotImplementedException();
    }
  
    public IEnumerable<TValue> GetValues(TKey key)
    {
        throw new NotImplementedException();
    }
  
    public bool RemoveValues(TKey key)
    {
        throw new NotImplementedException();
    }
}

  

public class Runner
{

    public static int Main(string[] args)
    {
        return new AutoRun(Assembly.GetCallingAssembly()).Execute(new String[] { "--labels=All" });
    }

    public class MultiValueBagTests
    {

        [Test]
        public void Returns_values_by_key()
        {
            var sut = new MultiValueBag<string, int>();
            sut.AddValue("a", 1);
            sut.AddValue("b", 7);
            sut.AddValue("b", 8);

            CollectionAssert.AreEquivalent(new[] { 1 }, sut.GetValues("a"));
            CollectionAssert.AreEquivalent(new[] { 7, 8 }, sut.GetValues("b"));
            CollectionAssert.IsEmpty(sut.GetValues("c"));
  
            Assert.IsTrue(sut.RemoveValues("a"));
            CollectionAssert.IsEmpty(sut.GetValues("a"));
            Assert.IsFalse(sut.RemoveValues("c"));
        }
    }
}
```
