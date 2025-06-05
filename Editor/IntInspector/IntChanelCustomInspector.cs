using GameEventSystem.Chanels;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEngine;
using System;


namespace GameEventSystem
{
    [CustomEditor(typeof(IntEventChanel))]
    public class IntChanelCustomInspector : Editor
    {
        public VisualTreeAsset visualTreeAsset;
        private IntEventChanel chanel;
        private SliderInt slider;

        private IntegerField min;
        private IntegerField max;

        void OnEnable()
        {
            chanel = (IntEventChanel)target;
        }
        public override VisualElement CreateInspectorGUI()
        {

            visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("ChanelInt.uxml");
            
            VisualElement myInspector = visualTreeAsset.Instantiate();

            slider = myInspector.Q<SliderInt>("slider");
            var sendMessageButton = myInspector.Q<Button>("botao-envia-mensagem");
            sendMessageButton.RegisterCallback<ClickEvent>(SendMessage);

            min = SetCallbackOnField(myInspector,"min-value", setMinValue);
            max = SetCallbackOnField(myInspector,"max-value", setMaxValue);
            return myInspector;

        }

        private IntegerField SetCallbackOnField(VisualElement myInspector, string fileName, EventCallback<ChangeEvent<int>> callback)
        {
            var field = myInspector.Q<IntegerField>(fileName);
            field.RegisterValueChangedCallback(callback);
            return field;
        }

        private void setMinValue(ChangeEvent<int> evt)
        {
            min.value = Math.Min(evt.newValue,max.value);
            UpdateSlider();
        }

        private void setMaxValue(ChangeEvent<int> evt)
        {
            max.value = Math.Max(evt.newValue,min.value);
            UpdateSlider();
        }

        private void UpdateSlider()
        {
            slider.lowValue = min.value;
            slider.highValue = max.value;
        }

        private void SendMessage(ClickEvent evt)
        {
            chanel.Publish(chanel.currentValue);
        }
    
    }
}
