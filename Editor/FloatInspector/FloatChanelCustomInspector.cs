using GameEventSystem.Chanels;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEngine;
using System;
using System.IO;


namespace GameEventSystem
{
    [CustomEditor(typeof(FloatEventChanel))]
    public class FloatChanelCustomInspector : Editor
    {
        public VisualTreeAsset visualTreeAsset;
        private FloatEventChanel chanel;
        private FloatField min;
        private FloatField max;
         private Slider slider;
        void OnEnable()
        {
            chanel = (FloatEventChanel)target;
        }
        public override VisualElement CreateInspectorGUI()
        {
            
            
            var path =Path.Join(Application.dataPath, "PubSub/Editor/FloatInspector/ChanelFloat.uxml");
            Debug.Log(path);
            var relativePath = Path.GetRelativePath(Application.dataPath,path);
            Debug.Log(relativePath);
            relativePath = Path.Join("Assets", relativePath);
            visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(relativePath);
            
            VisualElement myInspector = visualTreeAsset.Instantiate();
            slider = myInspector.Q<Slider>("slider");
            var sendMessageButton = myInspector.Q<Button>("botao-envia-mensagem");
            sendMessageButton.RegisterCallback<ClickEvent>(SendMessage);


            min = SetCallbackOnField(myInspector,"min-value", setMinValue);
            max = SetCallbackOnField(myInspector,"max-value", setMaxValue);
            return myInspector;

        }
         private FloatField SetCallbackOnField(VisualElement myInspector, string fileName, EventCallback<ChangeEvent<float>> callback)
        {
            var field = myInspector.Q<FloatField>(fileName);
            field.RegisterValueChangedCallback(callback);
            return field;
        }

        private void setMinValue(ChangeEvent<float> evt)
        {
            min.value = Math.Min(evt.newValue,max.value);
            UpdateSlider();
        }

        private void setMaxValue(ChangeEvent<float> evt)
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