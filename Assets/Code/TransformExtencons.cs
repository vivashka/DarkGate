using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code
{
    public static class TransformExtencons
    {
        public static int GetSortingOrder(this Transform transform, float yOffset = 0)
        {
            return -(int)((transform.position.y - yOffset) * 100);
        }
    }
}
