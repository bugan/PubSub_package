using System;
using Codice.CM.SEIDInfo;
using UnityEngine;
namespace GameEventSystem.Chanels
{
    [CreateAssetMenu(fileName = "Void Event Chanel", menuName = "UI Chanels/Void Event Chanel")]
    public class VoidEventChanel : BaseEventChanel<EmptyEvent>
    { 
        public VoidEventChanel()
        {
            this.currentValue = new EmptyEvent();
        }
    }
}