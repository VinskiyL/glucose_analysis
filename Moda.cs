using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaPredeleVozmozshnostey
{
    internal class Moda
    {
        Hashtable hash = new Hashtable();
        public double Mod(List<double> array, int n)
        {
            double moda = 0;
            int count = 0, max = 0;
            for (int i = 0; i < n; i++) 
            {
                if (hash.ContainsKey(array[i]))
                {
                    count = (int)hash[array[i]];
                    hash[array[i]] = ++count;
                }
                else
                {
                    hash[array[i]] = 1;
                }
            }
            ICollection keys = hash.Keys;
            foreach(double  key in keys)
            {
                if ((int)hash[key] > max)
                {
                    max = (int)hash[key];
                    moda = key;
                }
            }
            return moda;
        } 
    }
}
