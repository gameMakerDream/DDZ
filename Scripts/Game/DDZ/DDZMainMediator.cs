using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Mediator;
using UnityEngine.UI;
using PureMVC.Interfaces;
using System;

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
        private SPGroup[] spGroupArray = new SPGroup[3];
        private Clock clock;
        private Helper helper;
        private PlayerHead[] playerHeadArray = new PlayerHead[3];
        private CPGroup[] cpGroupArray = new CPGroup[3];
        private Transform[] clockPosArray = new Transform[3];
        private GameObject ctpCallBanker;
        private GameObject ctpPlayCard;
        private GameObject ctpJiaBei;
        private Button[] callBankerBtnArray = new Button[4];
        private Button btnPlayCard;
        private Button btnHint;
        private Button btnPass;
        private Button btnJB;
        private Button btnCJJB;
        private Button btnBJB;
        private Button btnHelper;
        private Chat[] chatArray = new Chat[3];
        public DDZMainMediator(object viewComponent) : base(NAME, viewComponent)
        {
            menu = Util.FindDeepChild(view.transform, "menu").gameObject;
            tgeMenu = Util.FindDeepChildAndGetComponent<Toggle>(view.transform, "tgeMenu");
            clock = Util.FindDeepChildAndGetComponent<Clock>(view.transform, "clock");
            helper = Util.FindDeepChildAndGetComponent<Helper>(view.transform, "helper");
            ctpCallBanker = Util.FindDeepChild(view.transform, "ctpCallBanker").gameObject;
            ctpPlayCard = Util.FindDeepChild(view.transform, "ctpPlayCard").gameObject;
            ctpJiaBei = Util.FindDeepChild(view.transform, "ctpJiaBei").gameObject;
            btnPlayCard = Util.FindDeepChildAndGetComponent<Button>(view.transform, "btnPlayCard");
            btnHint = Util.FindDeepChildAndGetComponent<Button>(view.transform, "btnHint");
            btnPass = Util.FindDeepChildAndGetComponent<Button>(view.transform, "btnPass");
            btnJB = Util.FindDeepChildAndGetComponent<Button>(view.transform, "btnJB");
            btnCJJB = Util.FindDeepChildAndGetComponent<Button>(view.transform, "btnCJJB");
            btnBJB = Util.FindDeepChildAndGetComponent<Button>(view.transform, "btnBJB");
            btnHelper = Util.FindDeepChildAndGetComponent<Button>(view.transform, "btnHelper");

            for (int i = 0; i < 3; i++)
            {
                spGroupArray[i] = Util.FindDeepChildAndGetComponent<SPGroup>(view.transform, "spGroup" + i);
                spGroupArray[i].Initialize(i);
            }
            for (int i = 0; i < 3; i++)
            {
                playerHeadArray[i] = Util.FindDeepChildAndGetComponent<PlayerHead>(view.transform, "playerHead" + i);
                playerHeadArray[i].Initialize(i);

            }
            for (int i = 0; i < 3; i++)
            {
                cpGroupArray[i] = Util.FindDeepChildAndGetComponent<CPGroup>(view.transform, "cpGroup" + i);
                cpGroupArray[i].Initialize(i);
            }
            for (int i = 0; i < 3; i++)
            {
                clockPosArray[i] = Util.FindDeepChildAndGetComponent<Transform>(view.transform, "clockPos" + i);
            }
            for (int i = 0; i < 4; i++)
            {
                int callScore = i;
                callBankerBtnArray[i] = Util.FindDeepChildAndGetComponent<Button>(view.transform, i.ToString());
                callBankerBtnArray[i].onClick.AddListener(delegate
                {
                    OnClickCallBanker(callScore);
                });
            }
            for (int i = 0; i < 3; i++)
            {
                chatArray[i] = Util.FindDeepChildAndGetComponent<Chat>(view.transform, "chat" + i);
                chatArray[i].Initialize(i);

            }
            clock.Initialize();
            helper.Initialize();

            tgeMenu.onValueChanged.AddListener(OnValueChangedMenu);
            btnPlayCard.onClick.AddListener(OnClickPlayCard);
            btnHint.onClick.AddListener(OnClickHint);
            btnPass.onClick.AddListener(OnClickPass);
            btnJB.onClick.AddListener(OnClickJB);
            btnCJJB.onClick.AddListener(OnClickCJJB);
            btnBJB.onClick.AddListener(OnClickBJB);
            btnHelper.onClick.AddListener(OnClickHelper);
        }

        public override string[] ListNotificationInterests()
        {
            List<string> _list = new List<string>();
            _list.Add(EventName.GameStateNotify);
            _list.Add(EventName.MatchResponse);
            _list.Add(EventName.MatchResultNotify);
            _list.Add(EventName.PlayerEnterRoomNotify);
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
            _list.Add(EventName.GeShowCardUpdate);
            _list.Add(EventName.GeShowCardComplete);
            return _list.ToArray();
        }

        public override void HandleNotification(INotification notification)
        {
            object[] _args = (object[])notification.Body;
            switch (notification.Name)
            {
                case EventName.GameStateNotify:
                    OnHandleGameStateNotify(_args);
                    break;
                case EventName.MatchResponse:
                    OnHandleMatchResponse(_args);
                    break;
                case EventName.MatchResultNotify:
                    OnHandleMatchResultNotify(_args);
                    break;
                case EventName.PlayerEnterRoomNotify:
                    OnHandlePlayerEnterRoomNotify(_args);
                    break;
                case EventName.PlayerExitRoomNotify:
                    OnHandlePlayerExitRoomNotify(_args);
                    break;
                case EventName.SendCardNotify:
                    OnHandleSendCardNotify(_args);
                    break;
                case EventName.CallBankerNotify:
                    OnHandleCallBankerNotify(_args);
                    break;
                case EventName.CallBankerResultNotify:
                    OnHandleCallBankerResultNotify(_args);
                    break;
                case EventName.ShowBankerNotify:
                    OnHandleShowBankerNotify(_args);
                    break;
                case EventName.JiaBeiNotify:
                    OnHandleJiaBeiNotify(_args);
                    break;
                case EventName.JiaBeiResultNotify:
                    OnHandleJiaBeiResultNotify(_args);
                    break;
                case EventName.PlayCardNotify:
                    OnHandlePlayCardNotify(_args);
                    break;
                case EventName.PlayCardResultNotify:
                    OnHandlePlayCardResultNotify(_args);
                    break;
                case EventName.SettleNotify:
                    OnHandleGameSettleNotify(_args);
                    break;
                case EventName.GeShowCardUpdate:
                    OnHandleShowCardUpdate(_args);
                    break;
                case EventName.GeShowCardComplete:
                    OnHandleShowCardComplete(_args);
                    break;
                case EventName.BSChangeNotify:
                    OnHandleBSChangeNotify(_args);
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
            PlayerData[] _array = data[0] as PlayerData[];
            for (int i = 0; i < _array.Length; i++)
            {
                PlayerData _pd = _array[i];
                playerHeadArray[i].SitDown(_pd);
            }
            EventQueue.UnLock();
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
            var _playerCardDataArray = (PlayerCardData[])data[0];
            bool _immediately = (bool)data[1];
            for (int i = 0; i < _playerCardDataArray.Length; i++)
            {
                spGroupArray[i].ShowSP(_playerCardDataArray[i].spCardList, _immediately);
            }
        }
        /// <summary>
        /// 更新牌张数 因为发牌是有动画的
        /// </summary>
        /// <param name="args"></param>
        private void OnHandleShowCardUpdate(object[] data)
        {
            int _seatIndex = (int)data[0];
            int _count = (int)data[1];
            playerHeadArray[_seatIndex].SetSPLeft(_count);
        }
        /// <summary>
        /// 做底牌动画 此时不需要知道底牌
        /// </summary>
        private void OnHandleShowCardComplete(object[] data)
        {
            bool _immediately = (bool)data[0];
            if (_immediately)
            {

            }
            else
            {
                
            }
            EventQueue.UnLock();
        }
        private void OnHandleCallBankerNotify(object[] data)
        {
            int _seatIndex = (int)data[0];
            int _time = (int)data[1];
            int _maxScore = (int)data[2];
            clock.SetClock(clockPosArray[_seatIndex].position, _time);
            if (_seatIndex == 0)
            {
                ctpCallBanker.SetActive(true);
                EnableCallBankerBtn(_maxScore);
            }
        }
        private void EnableCallBankerBtn(int score)
        {
            for (int i = 1; i <= score; i++)
                callBankerBtnArray[i].interactable = false;
        }
        private void OnHandleCallBankerResultNotify(object[] data)
        {
            int _seatIndex = (int)data[0];
            int _callScore = (int)data[1];
            clock.StopClock();
            if (_seatIndex == 0)
                ctpCallBanker.SetActive(false);
            chatArray[_seatIndex].ShowChat(_callScore.ToString()+"f");
        }
        private void OnHandleShowBankerNotify(object[] data)
        {
            int _seatIndex = (int)data[0];
            List<CardData> _dpList = (List<CardData>)data[1];
            List<CardData> _spList = (List<CardData>)data[2];
            if (_seatIndex == 0)
                spGroupArray[_seatIndex].BeBanker(_spList, _dpList);
            playerHeadArray[_seatIndex].SetSPLeft(_spList.Count);
        }
        private void OnHandleJiaBeiNotify(object[] data)
        {
            int _seatIndex = (int)data[0];
            float _time = (float)data[1];
            clock.SetClock(clockPosArray[_seatIndex].position, _time);
            if (_seatIndex == 0)
                ctpJiaBei.SetActive(true);
        }
        private void OnHandleJiaBeiResultNotify(object[] data)
        {
            int _seatIndex = (int)data[0];
            int _jbNumber = (int)data[1];
            clock.StopClock();
            if (_seatIndex == 0)
                ctpJiaBei.SetActive(false);
            chatArray[_seatIndex].ShowChat(_jbNumber.ToString()+"b");
        }
        private void OnHandlePlayCardNotify(object[] data)
        {
            int _seatIndex = (int)data[0];
            float _time = (float)data[1];
            clock.SetClock(clockPosArray[_seatIndex].position, _time);
            if (_seatIndex == 0)
                ctpPlayCard.SetActive(true);
        }
        private void OnHandlePlayCardResultNotify(object[] data)
        {
            int _seatIndex = (int)data[0];
            List<CardData> _cpList = (List<CardData>)data[1];
            List<CardData> _spList = (List<CardData>)data[2];
            cpGroupArray[_seatIndex].ShowCP(_cpList);
            spGroupArray[_seatIndex].ShowSP(_spList, true);
            if (_seatIndex == 0)
                ctpPlayCard.SetActive(false);
        }
        private void OnHandleGameSettleNotify(object[] data)
        {

        }
        private void OnHandleBSChangeNotify(object[] data)
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
        private void OnClickCallBanker(int callScore)
        {

        }
        private void OnClickPlayCard()
        {

        }
        private void OnClickHint()
        {

        }
        private void OnClickPass()
        {

        }
        private void OnClickJB()
        {
            
        }
        private void OnClickCJJB()
        {

        }
        private void OnClickBJB()
        {

        }
        private void OnClickHelper()
        {

        }
    }

}