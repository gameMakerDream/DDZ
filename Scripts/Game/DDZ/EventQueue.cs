using System.Collections.Generic;
using UnityTimer;
using DDZ;
using UnityEngine;

public class QueueMessage
{
    public string name;
    public object[] args;
    public QueueMessage(string name, object[] args)
    {
        this.name = name;
        this.args = args;
    }
}
public class EventQueue
{
    private static EventQueue instance;
    public static EventQueue Instance
    {
        get
        {
            if(instance == null)
                instance=new EventQueue();
            return instance;
        }
    }

    private Timer timer;
    private Queue<QueueMessage> eventQueue;
    private  static bool @lock;
    public EventQueue()
    {
        @lock = false;
        eventQueue = new Queue<QueueMessage>();
        timer = Timer.Register(0.1f, null, Update, true);
    }


    private void Update(float arg)
    {
        if (eventQueue.Count != 0 && !@lock)
        {
            @lock = true;
            QueueMessage _qm =eventQueue.Dequeue();
            AppFacade.Instance.SendNotification(_qm.name, _qm.args);
        }
    }

    public void Add(QueueMessage qm)
    {
        eventQueue.Enqueue(qm);
    }

    public static void UnLock()
    {
        @lock=false;
    }



}

