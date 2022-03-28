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
            object[] _args = (object[])notification.Body;
            switch (notification.Name)
            {
                case "GameStateNotify":
                    OnHandleGameStateNotify(_args);
                    break;
                case "MatchResponse":
                    OnHandleMatchResponse(_args);
                    break;
                case "MatchResultNotify":
                    OnHandleMatchResponse(_args);
                    break;
                case "PlayerEnterRoomNotif":
                    OnHandlePlayerEnterRoomNotify(_args);
                    break;
                case "PlayerExitRoomNotify":
                    OnHandlePlayerExitRoomNotify(_args);
                    break;
                case "SendCardNotify":
                    OnHandleSendCardNotify(_args);
                    break;
                case "CallBankerNotify":
                    OnHandleCallBankerNotify(_args);
                    break;
                case "CallBankerResultNotify":
                    OnHandleCallBankerResultNotify(_args);
                    break;
                case "ShowBankerNotify":
                    OnHandleShowBankerNotify(_args);
                    break;
                case "JiaBeiNotify":
                    OnHandleJiaBeiNotify(_args);
                    break;
                case "JiaBeiResultNotify":
                    OnHandleJiaBeiResultNotify(_args);
                    break;
                case "PlayCardNotify":
                    OnHandlePlayCardNotify(_args);
                    break;
                case "PlayCardResultNotify":
                    OnHandlePlayCardResultNotify(_args);
                    break;
                case "GameSettleNotify":
                    OnHandleGameSettleNotify(_args);
                    break;
                default: 
                    break;
            }
            Debug.Log(NAME + ":收到" + notification.Name + "消息");
        }
        private void OnHandleGameStateNotify(object[] data)
        {
            GameState _gameState = (GameState)data[0];
            switch (_gameState)
            {
                case GameState.Idle:
                    break;
                //case GameState.Match:
                //    break;
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
        private void OnHandleMatchResponse(object[] data)
        {
            //开始匹配

        }
        private void OnHandleMatchResultNotify(object[] data)
        {
            List<PlayerData> _list = data[0] as List<PlayerData>;
            for (int i = 0; i < _list.Count; i++)
            {
                PlayerData _pd = _list[i];
                playerHeadArray[i].SitDown(_pd);
            }
        }
        private void OnHandlePlayerEnterRoomNotify(object[] data)
        {
            //PlayerData _pd = data[0] as PlayerData;
            //暂时放弃 不一定用不用
        }
        private void OnHandlePlayerExitRoomNotify(object[] data)
        {
            int _seatIndex = (int)data[0];
            playerHeadArray[_seatIndex].SitUp();
        }
        private void OnHandleSendCardNotify(object[] data)
        {
            var _spList = (List<CardData>)data[0];
            var _dpList = (List<CardData>)data[1];
        }
        private void OnHandleCallBankerNotify(object[] data)
        {

        }
        private void OnHandleCallBankerResultNotify(object[] data)
        {

        }
        private void OnHandleShowBankerNotify(object[] data)
        {

        }
        private void OnHandleJiaBeiNotify(object[] data)
        {

        }
        private void OnHandleJiaBeiResultNotify(object[] data)
        {

        }
        private void OnHandlePlayCardNotify(object[] data)
        {

        }
        private void OnHandlePlayCardResultNotify(object[] data)
        {

        }
        private void OnHandleGameSettleNotify(object[] data)
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