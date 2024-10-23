using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public static class WeightUnitConverter
    {
        public static float TrueWeight(float weight, int unit)
        {
            /*if(weight<0)
            {
                return weight*(-1)* Mathf.Pow(10, 3 - unit);
            }
            else*/
            {
                return weight * Mathf.Pow(10, 3 - unit);
            }
        }
    }
}
