using System.Collections.Generic;
using UnityTimer;
using DDZ;
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
    private bool @lock;
    public void Initialize()
    {
        @lock = false;
        eventQueue = new Queue<QueueMessage>();
        timer = Timer.Register(0.1f, null, Update, true);
    }


    private void Update(float arg)
    {
        if (eventQueue.Count != 0 && !@lock)
        {
            QueueMessage _qm=eventQueue.Dequeue();
            AppFacade.Instance.SendNotification(_qm.name, _qm.args);
            @lock = true;
        }
    }

    public void Add(QueueMessage qm)
    {
        eventQueue.Enqueue(qm);
    }

    public void UnLock()
    {
        @lock=false;
    }



}

