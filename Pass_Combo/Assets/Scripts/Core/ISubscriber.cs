using UnityEngine;

public interface ISubscriber
{
    void OnNotify(string eventType, object data = null);
}
