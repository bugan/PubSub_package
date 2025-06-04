using UnityEngine;
namespace GameEventSystem.Chanels
{
    [CreateAssetMenu(fileName = "Void Event Chanel", menuName = "UI Chanels/Float Event Chanel")]
    public class FloatEventChanel : BaseEventChanel<float>
    {

        public float min;
        public float max;
    }
}