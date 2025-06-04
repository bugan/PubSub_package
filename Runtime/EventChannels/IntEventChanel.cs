using UnityEngine;
namespace GameEventSystem.Chanels
{
    [CreateAssetMenu(fileName = "Void Event Chanel", menuName = "UI Chanels/Int Event Chanel")]
    public class IntEventChanel : BaseEventChanel<int>
    {
        public int min;
        public int max;
     }
}