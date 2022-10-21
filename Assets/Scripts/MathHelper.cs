using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace helpers
{
    public abstract class MathHelper
    {
        public static Vector3 Vector2ToVector3(Vector2 inputVector2)
        {
            return new Vector3(inputVector2.x, inputVector2.y, 0);
        }

    }
}