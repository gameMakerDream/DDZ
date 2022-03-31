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
        public List<CardData>[] spCardListArray;
        public List<CardData> dpCardList;
        public SendCardNotify(int maxPlayer)
        {
            spCardListArray = new List<CardData>[maxPlayer];
            dpCardList = new List<CardData>();
        }
    }
    public class CallBankerRequest: CallBankerResultNotify
    {

    }
    public class CallBankerNotify
    {
        public PlayerData playerData;
        public int time;//ʣ��ʱ��
    }
    public class CallBankerResultNotify
    {
        public PlayerData playerData;
        public int callScore;//������������ 0���� 1��1�� 2��2�� 3��3��
        public int callBanker;//��ͨ�������� 0���� 1�е��� 2������ 3����
        public int callType;//0�з��� 1��ͨ��
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
        public int jbNumber;//0���ӱ� 1�ӱ� 
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
        public List<CardData> cpList;
        public PlayCardResultNotify()
        {
            cpList = new List<CardData>();
        }
    }
    public class GameSettleNotify
    {
        
    }
    public class BSChangeNotify//�����ı�֪ͨ
    {
        public int bsNumber;
    }















    public class RoomData
    {
        public string roomId;
        public string roomName;
    }
    public class CardData//�ͷ�����ͨ��
    {

        public string color;
        public int number;
        public string name 
        {
            get { return color + number.ToString("D2"); }
        }
        public CardData()
        {
            
        }
        public CardData(string color, int number)
        {
            this.color = color;
            this.number = number;
        }
    }
    public class PlayerData//�ͷ�����ͨ��
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
            callBankerMaxScore=2;
            bankerData = new PlayerData();
            dpCardList=new List<CardData>();
            lastCpCardData=new LastPlayCardData();
        }
    }
}