using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDZ
{
    public enum GameState
    {
        None,
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
    public class MatchRequest
    {
        public PlayerData player;

    }
    public class MatchResponse
    {
        
    }
    public class MatchResultNotify
    {
        public PlayerData[] playerDataArray;
        public MatchResultNotify(int maxPlayer)
        {
            playerDataArray = new PlayerData[maxPlayer];
        }
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
        public List<int>[] spCardListArray;
        public List<int> dpCardList;
        public SendCardNotify(int maxPlayer)
        {
            spCardListArray = new List<int>[maxPlayer];
            dpCardList = new List<int>();
        }
    }
    public class CallBankerRequest: CallBankerResultNotify
    {

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
        public int callBanker;//普通制抢地主 0不叫 1叫地主 2抢地主 3不抢
        public int callType;//0叫分制 1普通制
    }
    public class ShowBankerNotify
    {
        public PlayerData playerData;
    }
    public class JiaBeiRequest:JiaBeiResultNotify
    {
        
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
    public class PlayCardRequest: PlayCardResultNotify
    {
        
    }
    public class PlayCardNotify
    {
        public PlayerData playerData;
        public int time;
    }
    public class PlayCardResultNotify
    {
        public PlayerData playerData;
        public List<int> cpList;
        public PlayCardResultNotify()
        {
            cpList = new List<int>();
        }
    }
    public class GameSettleNotify
    {
        
    }
    public class BSChangeNotify//倍数改变通知
    {
        public int bsNumber;
    }















    public class RoomData
    {
        public string roomId;
        public string roomName;
    }
    public class CardData//和服务器通用
    {

        public int color;
        public int number;
        public int code;
        public string name;
        public CardData()
        {
            
        }
        public CardData(int code)
        {
            this.color = code & 0xF0;
            this.number = code & 0x0F;
            this.code = code;
            this.name = code.ToString();
            switch (this.number)
            {
                case 1:
                    this.number = 14;
                    break;
                case 2:
                    this.number = 15;
                    break;
                case 14:
                    this.number = 16;
                    break;
                case 15:
                    this.number = 17;
                    break;
                default:
                    break;
            }
        }
    }
    public class PlayerData//和服务器通用
    {
        public int userId;
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
        public PlayerData[] playerDataArray;
        public PlayerCardData[] playerCardDataArray;
        public GameState gameState;
        public int callBankerMaxScore;
        public PlayerData bankerData;
        public List<CardData> dpCardList;
        public LastPlayCardData lastCpCardData;

        public DDZMainData()
        {
            roomData=new RoomData();
            playerDataArray=new PlayerData[3];
            playerCardDataArray=new PlayerCardData[3];
            gameState = GameState.None;
            callBankerMaxScore=0;
            bankerData = new PlayerData();
            dpCardList=new List<CardData>();
            lastCpCardData=new LastPlayCardData();
        }
    }
}