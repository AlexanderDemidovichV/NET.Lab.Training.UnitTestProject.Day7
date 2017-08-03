using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public static class EqualityComparerFactory
    {
        public static IEqualityComparer<T> CreateEqualityComparer<T>(Func<T, int> getHashCode, Func<T, T, bool> equals) => new DelegatedEqualityComparer<T>(getHashCode, equals);

        public class DelegatedEqualityComparer<T> : EqualityComparer<T>
        {
            private Func<T, int> getHashCode;
            private Func<T, T, bool> equals;
            public DelegatedEqualityComparer(Func<T, int> getHashCode, Func<T, T, bool> equals)
            {
                this.getHashCode = getHashCode ?? throw new ArgumentNullException(nameof(getHashCode));
                this.equals = equals ?? throw new ArgumentNullException(nameof(equals));
            }
            public override int GetHashCode(T x) => getHashCode(x);
            public override bool Equals(T x, T y) => equals(x, y);
        }
    }
}
