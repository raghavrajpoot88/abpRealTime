using System;
using System.Collections.Generic;
using System.Text;

namespace chatterBox.Mapping
{
    public interface IConnectionMapping<T>
    {
        public void Add(T key, string connectionId);
        public IEnumerable<string> GetConnections(T key);
        public void Remove(T key, string connectionId);
    }
}
