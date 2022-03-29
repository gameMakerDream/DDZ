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
        public int time;//ʣ��ʱ��
    }
    public class CallBankerResultNotify
    {
        public PlayerData playerData;
        public int callScore;//������������ 0���� 1��1�� 2��2�� 3��3��
        public int callType;//��ͨ�������� 0���� 1�е��� 2������ 3����
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
        public int jbNumber;//0���ӱ� 1�ӱ� 
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
    public class CardData//�ͷ�����ͨ��
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
    public class PlayerData//�ͷ�����ͨ��
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