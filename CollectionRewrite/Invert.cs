using CollectionRewrite;
using System.Collections.Generic;

namespace TestCollection
{
    public class ListShould
    {
        public IEnumerable<float> Invert(IEnumerable<int> IntEnum) 
        {
            IEnumerable<float> listFloat = new IEnumerable<float>();

            foreach (int elem in IntEnum) {
                listFloat.Add(1 / elem);
            }
            return (listFloat as IEnumerable<float>);
        }
    }
}