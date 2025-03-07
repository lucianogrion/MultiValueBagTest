using System.Collections.Generic;

namespace MultiValueBagTest
{

    public class Record<TKey, TValue>
    {
        public Record(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public TKey Key { get; set; }

        public TValue Value { get; set; }
    }

    public class MultiValueBag<TKey, TValue>
    {
        private List<Record<TKey, TValue>> _list = new List<Record<TKey, TValue>>();

        public void AddValue(TKey key, TValue value)
        {
            var record = _list.Find(r => r.Key!.Equals(key));
            
            _list.Add(new Record<TKey, TValue>(key, value));
            
        }

        public IEnumerable<TValue> GetValues(TKey key)
        {
            var records = _list.Where(r => r.Key!.Equals(key)).Select(s=>s.Value);
            return records?.ToList() ?? Enumerable.Empty<TValue>();
        }

        public bool RemoveValues(TKey key)
        {
            return _list.RemoveAll(r => r.Key!.Equals(key)) > 0;
        }
    }


    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod2()
        {
            var sut = new MultiValueBag<string, int>();
            sut.AddValue("a", 1);
            sut.AddValue("b", 7);
            sut.AddValue("b", 8);

            foreach (var item in sut.GetValues("b").ToList())
            {
                Console.WriteLine(item);
            }

            List<int> emptylist = new List<int>();


            CollectionAssert.AreEqual(new[] { 1 }, sut.GetValues("a").ToList());
            CollectionAssert.AreEqual(new[] { 7, 8 }, sut.GetValues("b").ToArray());
            CollectionAssert.AreEqual(emptylist, sut.GetValues("c").ToList());

            Assert.IsTrue(sut.RemoveValues("a"));
            CollectionAssert.AreEqual(emptylist, sut.GetValues("a").ToList());

            Assert.IsFalse(sut.RemoveValues("c"));
        }
    }
}
