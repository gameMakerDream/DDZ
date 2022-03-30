using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDZ
{
    public class test : MonoBehaviour
    {
        // Start is called before the first frame update
    void Start()
        {
            UserData ud = new UserData();
            ud.userId = "1";
            AppFacade.Instance.RegisterProxy(new UserDataProxy(ud));
            AppFacade.Instance.RegisterProxy(new DDZMainDataProxy());
            AppFacade.Instance.RegisterMediator(new DDZMainMediator(GameObject.Find("Canvas")));
            SCMessage.Instance.Initialize();
            StartCoroutine("test1");
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator test1()
        {
            ServerMessage sm = new ServerMessage();
            MatchResultNotify mrn=new MatchResultNotify(3);
            for (int i = 0; i < 3; i++)
            {
                var pd = new PlayerData();
                pd.nickName = "asdasd" + i;
                pd.coin = 123123123;
                pd.serverSeatIndex = i;
                pd.userId = i.ToString();
                mrn.playerDataArray[i]=pd;
            }
            sm.name = EventName.MatchResultNotify;
            sm.body = mrn;
            SCMessage.Instance.Decode(sm);
            yield return new WaitForSeconds(2);
            SendCardNotify scn=new SendCardNotify(3);
            for (int i = 0; i < 3; i++)
            {
                var a = new List<CardData>();
                for (int j = 0; j < 17; j++)
                {
                    var d = Random.Range(1, 3).ToString();
                    var c = Random.Range(3, 12);
                    var b = new CardData(d, c);
                    a.Add(b);
                    Debug.Log(d);
                }
                scn.spCardListArray[i] = a;
            }
            for (int i = 0; i < 3; i++)
            {
                var a = Random.Range(1, 3).ToString();
                var c = Random.Range(3, 12);
                var b = new CardData(a, c);
                scn.dpCardList.Add(b);
                Debug.Log(a);
            }
            sm.name = EventName.SendCardNotify;
            sm.body = scn;
            SCMessage.Instance.Decode(sm);
            yield return new WaitForSeconds(1);
            CallBankerNotify cbn=new CallBankerNotify();
            var pd1 = new PlayerData();
            pd1.nickName = "asdasd";
            pd1.coin = 123123123;
            pd1.serverSeatIndex = 1;
            pd1.userId = "1";
            cbn.playerData = pd1;
            cbn.time = 50;
            sm.name = EventName.CallBankerNotify;
            sm.body = cbn;
            SCMessage.Instance.Decode(sm);
        }
    }
}
