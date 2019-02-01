using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM2.Structures
{
    class Table<A, B> : IEnumerable<Tuple<A, B>>
    {
        private IList<Tuple<A, B>> _table;

        public void Add(Tuple<A, B> tuple) => _table.Add(tuple);

        public void Add(A first, B second) => Add(new Tuple<A, B>(first, second));

        public int Size() => _table.Count();
        
        public Tuple<A, B> this[int i]
        {
            get => _table[i];
            set => _table[i] = value;
        }

        public IEnumerator<Tuple<A, B>> GetEnumerator() => _table.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _table.GetEnumerator();
    }

}
