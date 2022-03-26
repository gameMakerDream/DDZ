using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Mediator;
using UnityEngine.UI;
using PureMVC.Interfaces;

namespace DDZ
{
    public class DDZMainMediator : Mediator
    {
        public new const string NAME = "DDZMainMediator";

        public GameObject view
        {
            get { return (GameObject)ViewComponent; }
        }

        private GameObject menu;
        private Toggle tgeMenu;
        private SPGroup spGroup;
        private Clock clock;
        private PlayerHead[] playerHeadArray = new PlayerHead[3];
        private CPGroup[] cpGroupArray = new CPGroup[3];
        private Transform[] clockPosArray = new Transform[3];


        public DDZMainMediator(object viewComponent) : base(NAME, viewComponent)
        {
            menu = Util.FindDeepChild(view.transform, "menu").gameObject;
            tgeMenu = Util.FindDeepChildAndGetComponent<Toggle>(view.transform, "tgeMenu");
            spGroup = Util.FindDeepChildAndGetComponent<SPGroup>(view.transform, "handCardGroup");
            clock = Util.FindDeepChildAndGetComponent<Clock>(view.transform, "timer");
            for (int i = 0; i < 3; i++)
            {
                playerHeadArray[i] = Util.FindDeepChildAndGetComponent<PlayerHead>(view.transform, "playerHead" + i);
                playerHeadArray[i].Initialize(i);

            }
            for (int i = 0; i < 3; i++)
            {
                cpGroupArray[i] = Util.FindDeepChildAndGetComponent<CPGroup>(view.transform, "playCardGroup" + i);
                cpGroupArray[i].Initialize(i);
            }
            for (int i = 0; i < 3; i++)
            {
                clockPosArray[i] = Util.FindDeepChildAndGetComponent<Transform>(view.transform, "clockPos" + i);
            }
            tgeMenu.onValueChanged.AddListener(OnValueChangedMenu);
        }

        public override string[] ListNotificationInterests()
        {
            List<string> _list = new List<string>();
            _list.Add(EventName.GameStateNotify);
            _list.Add(EventName.MatchResponse);
            _list.Add(EventName.PlayerEnterRoomNotif);
            _list.Add(EventName.PlayerExitRoomNotify);
            _list.Add(EventName.SendCardNotify);
            _list.Add(EventName.CallBankerNotify);
            _list.Add(EventName.CallBankerResultNotify);
            _list.Add(EventName.ShowBankerNotify);
            _list.Add(EventName.JiaBeiNotify);
            _list.Add(EventName.JiaBeiResultNotify);
            _list.Add(EventName.PlayCardNotify);
            _list.Add(EventName.PlayCardResultNotify);
            _list.Add(EventName.SettleNotify);
            return _list.ToArray();
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case "RoundNotify":
                    OnHandleRoundNotify(notification.Body);
                    break;
                case "MatchResponse":
                    OnHandleMatchResponse(notification.Body);
                    break;
                case "PlayerEnterRoomNotif":
                    OnHandlePlayerEnterRoomNotify(notification.Body);
                    break;
                case "PlayerExitRoomNotify":
                    OnHandlePlayerExitRoomNotify(notification.Body);
                    break;
                case "SendCardNotify":
                    OnHandleSendCardNotify(notification.Body);
                    break;
                case "CallBankerNotify":
                    OnHandleCallBankerNotify(notification.Body);
                    break;
                case "CallBankerResultNotify":
                    OnHandleCallBankerResultNotify(notification.Body);
                    break;
                case "ShowBankerNotify":
                    OnHandleShowBankerNotify(notification.Body);
                    break;
                case "JiaBeiNotify":
                    OnHandleJiaBeiNotify(notification.Body);
                    break;
                case "JiaBeiResultNotify":
                    OnHandleJiaBeiResultNotify(notification.Body);
                    break;
                case "PlayCardNotify":
                    OnHandlePlayCardNotify(notification.Body);
                    break;
                case "PlayCardResultNotify":
                    OnHandlePlayCardResultNotify(notification.Body);
                    break;
                case "SettleNotify":
                    OnHandleSettleNotify(notification.Body);
                    break;
                default: 
                    break;
            }
            Debug.Log(NAME + ":收到" + notification.Name + "消息");
        }
        private void OnHandleRoundNotify(object data)
        {
            object[] _args = (object[])data;
            GameState _gameState = (GameState)_args[0];
            switch (_gameState)
            {
                case GameState.Match:
                    break;
                case GameState.SendCard:
                    break;
                case GameState.CallBanker:
                    break;
                case GameState.ShowBanker:
                    break;
                case GameState.JiaBei:
                    break;
                case GameState.PlayCard:
                    break;
                case GameState.Settle:
                    break;
                default:
                    break;
            }
        }
        private void OnHandleMatchResponse(object data)
        {
            //开始匹配
        }
        private void OnHandlePlayerEnterRoomNotify(object data)
        {

        }
        private void OnHandlePlayerExitRoomNotify(object data)
        {

        }
        private void OnHandleSendCardNotify(object data)
        {

        }
        private void OnHandleCallBankerNotify(object data)
        {

        }
        private void OnHandleCallBankerResultNotify(object data)
        {

        }
        private void OnHandleShowBankerNotify(object data)
        {

        }
        private void OnHandleJiaBeiNotify(object data)
        {

        }
        private void OnHandleJiaBeiResultNotify(object data)
        {

        }
        private void OnHandlePlayCardNotify(object data)
        {

        }
        private void OnHandlePlayCardResultNotify(object data)
        {

        }
        private void OnHandleSettleNotify(object data)
        {

        }
        public override void OnRegister()
        {
            base.OnRegister();
        }

        public override void OnRemove()
        {
            base.OnRemove();
        }


        private void OnValueChangedMenu(bool value)
        {
            menu.SetActive(value);
        }

    }

}