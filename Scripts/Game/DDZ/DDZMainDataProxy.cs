using PureMVC.Patterns.Proxy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDZ
{
    public class DDZMainDataProxy : Proxy
    {
        public new const string NAME = "DDZMainDataProxy";
        private UserDataProxy userDataProxy;
        public DDZMainData VO
        {
            get { return (DDZMainData)Data; }
        }
        public DDZMainDataProxy() : base(NAME)
        {
            Data = new DDZMainData();
        }

        public override void OnRegister()
        {
            userDataProxy = Facade.RetrieveProxy(UserDataProxy.NAME) as UserDataProxy;
            base.OnRegister();
        }

        public override void OnRemove()
        {
            base.OnRemove();
        }



        public object[] OnSetGameStateNotify(GameStateNotify data)
        {
            VO.gameState = data.gameState;
            Constants.gameState = data.gameState;
            List<object> _result = new List<object>();
            _result.Add(VO.gameState);
            switch (data.gameState)
            {
                case GameState.None:
                    break;
                case GameState.Idle:
                    break;
                case GameState.Match:
                    break;
                case GameState.SendCard:
                    break;
                case GameState.CallBanker:
                    break;
                case GameState.ShowBanker:
                    _result.Add(GetLeftCard());
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
            return _result.ToArray();
        }
        public object[] OnSetMatchResponse(MatchResponse data)
        {
            return new object[0];
        }
        public object[] OnSetMatchResultNotify(MatchResultNotify data)
        {
            int _index = 0;
            int _count = 0;
            while (_count < 3)
            {
                PlayerData _pd = data.playerDataArray[_index];
                if (_pd.userId == userDataProxy.VO.userId || VO.playerDataArray[0]!=null)
                {
                    VO.playerDataArray[_count] = _pd;
                    _count++;
                }
                _index = (_index + 1) % data.playerDataArray.Length;
            }
            return new object[] { VO.playerDataArray };
        }
        public object[] OnSetPlayerEnterRoomNotify(PlayerEnterRoomNotify data)
        {
            //PlayerData _pd = data.player;
            //VO.playerDataList.Add(_pd);
            //return new object[] { _pd };
            //暂时放弃 不一定用不用
            return new object[0];
        }

        public object[] OnSetPlayerExitRoomNotify(PlayerExitRoomNotify data)
        {
            PlayerData _pd = data.player;
            int _clientSeatIndex = GetPlayerClientSeatIndexByServerSeat(_pd.serverSeatIndex);
            VO.playerCardDataArray[_clientSeatIndex] = null;
            return new object[] { _clientSeatIndex };
        }
        public object[] OnSetSendCardNotify(SendCardNotify data,bool immediately)
        {

            for (int i = 0; i < data.spCardListArray.Length; i++)
            {
                PlayerCardData _pcd = new PlayerCardData();
                int _clientSeatIndex = GetPlayerClientSeatIndexByServerSeat(i);
                _pcd.spCardList = Translate2CardDataList(data.spCardListArray[i]);
                if (_clientSeatIndex == 0)
                    _pcd.spCardList.Sort(CompareDown);
                else
                    _pcd.spCardList.Sort(CompareUp);
                VO.playerCardDataArray[_clientSeatIndex] = _pcd;
            }
            VO.dpCardList = Translate2CardDataList(data.dpCardList);
            return new object[] { VO.playerCardDataArray, immediately };
        }

        public object[] OnSetCallBankerNotify(CallBankerNotify data)
        {
            int _clientSeatIndex = GetPlayerClientSeatIndexByServerSeat(data.playerData.serverSeatIndex);
            return new object[] { _clientSeatIndex, data.time,VO.callBankerMaxScore };
        }
        public object[] OnSetCallBankerResultNotify(CallBankerResultNotify data)
        {
            int _clientSeatIndex = GetPlayerClientSeatIndexByServerSeat(data.playerData.serverSeatIndex);
            if (data.callScore > VO.callBankerMaxScore)
                VO.callBankerMaxScore = data.callScore;
            return new object[] { _clientSeatIndex, data.callScore };
        }
        public object[] OnSetShowBankerNotify(ShowBankerNotify data)
        {
            VO.bankerData = data.playerData;
            int _clientSeatIndex = GetPlayerClientSeatIndexByServerSeat(VO.bankerData.serverSeatIndex);
            VO.playerCardDataArray[_clientSeatIndex].spCardList.AddRange(VO.dpCardList);
            return new object[] { _clientSeatIndex, VO.dpCardList, VO.playerCardDataArray[_clientSeatIndex].spCardList };
        }
        public object[] OnSetJiaBeiNotify(JiaBeiNotify data)
        {
            int _clientSeatIndex = GetPlayerClientSeatIndexByServerSeat(data.playerData.serverSeatIndex);
            return new object[] { _clientSeatIndex, data.time };
        }
        public object[] OnSetJiaBeiResultNotify(JiaBeiResultNotify data)
        {
            int _clientSeatIndex = GetPlayerClientSeatIndexByServerSeat(data.playerData.serverSeatIndex);
            return new object[] { _clientSeatIndex, data.jbNumber };
        }
        public object[] OnSetPlayCardNotify(PlayCardNotify data)
        {
            int _clientSeatIndex = GetPlayerClientSeatIndexByServerSeat(data.playerData.serverSeatIndex);
            return new object[] { _clientSeatIndex, data.time };
        }
        public object[] OnSetPlayCardResultNotify(PlayCardResultNotify data)
        {
            int _clientSeatIndex = GetPlayerClientSeatIndexByServerSeat(data.playerData.serverSeatIndex);
            VO.lastCpCardData.clientSeat = _clientSeatIndex;
            VO.lastCpCardData.cpList = Translate2CardDataList(data.cpList);
            VO.lastCpCardData.cpList.Sort(CompareUp);
            var _spList = VO.playerCardDataArray[_clientSeatIndex].spCardList;
            for (int i = 0; i < data.cpList.Count; i++)
            {
                var _a=data.cpList[i];
                for (int j = 0; j < _spList.Count; j++)
                {
                    var _b=_spList[j];
                    if (_a == _b.code)
                    {
                        _spList.Remove(_b);
                        break;
                    }
                }
            }
            return new object[] { VO.lastCpCardData.clientSeat, VO.lastCpCardData.cpList,_spList };
        }
        public object[] OnSetGameSettleNotify(GameSettleNotify data)
        {
            return new object[0];
        }



        private int GetPlayerClientSeatIndexByServerSeat(int serverSeatIndex)
        {
            for (int i = 0; i < VO.playerDataArray.Length; i++)
            {
                if (VO.playerDataArray[i]!=null)
                {
                    if (serverSeatIndex == VO.playerDataArray[i].serverSeatIndex)
                        return i;
                }
            }
            return -1;
        }
        private string[] GetLeftCard()
        {
            List<string> _resultList = new List<string>();
            for (int i = 1; i < VO.playerCardDataArray.Length; i++)
            {
                PlayerCardData _pcd = VO.playerCardDataArray[i];
                foreach (CardData _cd in _pcd.spCardList)
                {
                    _resultList.Add(_cd.name);
                }
            }
            return _resultList.ToArray();
        }
        private List<CardData> Translate2CardDataList(List<int> cardCodeList)
        {
            List<CardData> _cardDataList = new List<CardData>();
            for (int i = 0; i < cardCodeList.Count; i++)
            {
                int _cc = cardCodeList[i];
                CardData _cd = new CardData(_cc);
                _cardDataList.Add(_cd);
            }
            return _cardDataList;
        }
        private int CompareUp(CardData a, CardData b)
        {
            return a.number.CompareTo(b.number);
        }
        private int CompareDown(CardData a, CardData b)
        {
            return -a.number.CompareTo(b.number);
        }
    }
}
