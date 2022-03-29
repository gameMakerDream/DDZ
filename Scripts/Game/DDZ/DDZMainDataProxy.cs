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
            userDataProxy = Facade.RetrieveProxy(userDataProxy.ProxyName) as UserDataProxy;
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
            return new object[] { VO.gameState };
        }
        public object[] OnSetMatchResponse(MatchResponse data)
        {
            return new object[0];
        }
        public object[] OnSetMatchResultNotify(MatchResultNotify data)
        {
            int _index = 0;
            int _count = 0;
            List<PlayerData> _temp = new List<PlayerData>();
            while (_count < 3)
            {
                PlayerData _pd = data.playerDataList[_index];
                if (_pd.userId == userDataProxy.VO.userId || _temp[0] != null)
                {
                    _temp.Add(_pd);
                    _count++;
                }
                _index = (_index + 1) % data.playerDataList.Count;
            }
            VO.playerDataList = _temp;
            return new object[] { VO.playerDataList };
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
            VO.playerCardDataList.RemoveAt(_clientSeatIndex);
            return new object[] { _clientSeatIndex };
        }
        public object[] OnSetSendCardNotify(SendCardNotify data)
        {
            for (int i = 0; i < data.spCardListArray.Count; i++)
            {
                VO.playerCardDataList[i] = new PlayerCardData();
                int _clientSeatIndex = GetPlayerClientSeatIndexByServerSeat(i);
                VO.playerCardDataList[i].spCardList = data.spCardListArray[_clientSeatIndex];
            }
            VO.dpCardList = data.dpCardList;
            return new object[] { VO.playerCardDataList };
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
            VO.playerCardDataList[_clientSeatIndex].spCardList.AddRange(VO.dpCardList);
            return new object[] { _clientSeatIndex, VO.dpCardList, VO.playerCardDataList[_clientSeatIndex].spCardList };
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
            VO.lastCpCardData.cpList = data.cpList;
            return new object[] { VO.lastCpCardData.clientSeat, VO.lastCpCardData.cpList };
        }
        public object[] OnSetGameSettleNotify(GameSettleNotify data)
        {
            return new object[0];
        }



        private int GetPlayerClientSeatIndexByServerSeat(int serverSeatIndex)
        {
            for (int i = 0; i < VO.playerDataList.Count; i++)
            {
                if (serverSeatIndex == VO.playerDataList[i].serverSeatIndex)
                    return i;
            }
            return -1;
        }
    }
}
