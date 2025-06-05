using GameEventSystem.Chanels;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEngine;
using System;


namespace GameEventSystem
{
    [CustomEditor(typeof(BooleanEventChanel))]
    public class BoolChanelCustomInspector : Editor
    {
        public VisualTreeAsset visualTreeAsset;
        private BooleanEventChanel chanel;
    

        void OnEnable()
        {
            chanel = (BooleanEventChanel)target;
        }
        public override VisualElement CreateInspectorGUI()
        {

            visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("BoolInspector/ChanelBool.uxml");
            
            VisualElement myInspector = visualTreeAsset.Instantiate();

            var sendMessageButton = myInspector.Q<Button>("botao-envia-mensagem");
            sendMessageButton.RegisterCallback<ClickEvent>(SendMessage);
                        
            return myInspector;

        }

        private void SendMessage(ClickEvent evt)
        {
            chanel.Publish(chanel.currentValue);
        }
    
    }
}
