using GameEventSystem.Chanels;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEngine;
using System;
using System.IO;

namespace GameEventSystem
{
    [CustomEditor(typeof(VoidEventChanel))]
    public class VoidChanelCustomInspector : Editor
    {
        public VisualTreeAsset visualTreeAsset;
        private VoidEventChanel chanel;
    

        void OnEnable()
        {
            chanel = (VoidEventChanel)target;
        }
        public override VisualElement CreateInspectorGUI()
        {

            visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Packages/com.bugan.pubsub/Assets/ChanelVoid.uxml");
            
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
