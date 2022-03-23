using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMgr : MonoBehaviour
{
    public static PanelMgr instance;

    private Dictionary<PanelType,IPanel> panelDic = new Dictionary<PanelType, IPanel>();
    private void Awake()
    {
        instance = this;
    }

    public void AddPanel(PanelType panelType,IPanel panel)
    {
        if (panelDic.ContainsKey(panelType))
        {
            Debug.LogError(panelType + ":�ظ����");
            return;
        }
        panelDic[panelType] = panel;
    }
    public void RemovePanel(PanelType panelType)
    {
        if (!panelDic.ContainsKey(panelType))
        {
            Debug.LogError(panelType + ":�����ڽ���");
            return;
        }
        panelDic.Remove(panelType);
    }
    public IPanel GetPanel(PanelType panelType)
    {
        if (panelDic.TryGetValue(panelType, out IPanel _panel))
            return _panel;
        return null;
    }
}
