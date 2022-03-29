using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDZ
{
    public enum GameState
    {
        Idle,
        Match,
        SendCard,
        CallBanker,
        ShowBanker,
        JiaBei,
        PlayCard,
        Settle
    }
  
    public class ServerMessage
    {
        public string name;
        public object body;
    }
    public class ErrorNotify
    {
        public string errorCode;
    }

    public class GameStateNotify
    {
        public GameState gameState;
    }
    public class MatchResponse
    {
        
    }
    public class MatchResultNotify
    {
        public List<PlayerData> playerDataList;
    }
    public class PlayerEnterRoomNotify
    {
        public PlayerData player;
    }
    public class PlayerExitRoomNotify
    {
        public PlayerData player;
    }
    public class SendCardNotify
    {
        public List<List<CardData>> spCardListArray;
        public List<CardData> dpCardList;
    }
    public class CallBankerNotify
    {
        public PlayerData playerData;
        public int time;//剩余时间
    }
    public class CallBankerResultNotify
    {
        public PlayerData playerData;
        public int callScore;//分数制抢地主 0不叫 1叫1分 2叫2分 3叫3分
        public int callType;//普通制抢地主 0不叫 1叫地主 2抢地主 3不抢
    }
    public class ShowBankerNotify
    {
        public PlayerData playerData;
    }
    public class JiaBeiNotify
    {
        public PlayerData playerData;
        public int time;
    }
    public class JiaBeiResultNotify
    {
        public PlayerData playerData;
        public int jbNumber;//0不加倍 1加倍 
    }
    public class PlayCardNotify
    {
        public PlayerData playerData;
        public int time;
    }
    public class PlayCardResultNotify
    {
        public PlayerData playerData;
        public List<CardData> cpList;
    }
    public class GameSettleNotify
    {
        
    }















    public class RoomData
    {
        public string roomId;
        public string roomName;
    }
    public class CardData//和服务器通用
    {

        public string color;
        public int number;
        public string name { get; private set; }
        public CardData()
        {
            
        }
        public CardData(string color, int number)
        {
            this.color = color;
            this.number = number;
            this.name =color+ number.ToString("D2");
        }
    }
    public class PlayerData//和服务器通用
    {
        public string userId;
        public string nickName;
        public float coin;
        public int sex;
        public int iconIndex;
        public int serverSeatIndex;
    }
    public class PlayerCardData
    {
        public List<CardData> spCardList;
        public PlayerCardData()
        {
            spCardList = new List<CardData>();
        }
    }
    public class PlayerJiaBeiData:JiaBeiResultNotify
    {
        
    }
    public class LastPlayCardData
    {
        public int clientSeat;
        public List<CardData> cpList;
    }
    public class DDZMainData
    {
        public RoomData roomData;
        public List<PlayerData> playerDataList;
        public List<PlayerCardData> playerCardDataList;
        public GameState gameState;
        public int callBankerMaxScore;
        public PlayerData bankerData;
        public List<CardData> dpCardList;
        public LastPlayCardData lastCpCardData;
    }
}