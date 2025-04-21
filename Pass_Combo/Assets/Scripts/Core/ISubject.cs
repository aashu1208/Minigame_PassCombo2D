using UnityEngine;

public interface ISubject
{
    void Subscribe(ISubscriber subscriber);
    void UnSubscribe(ISubscriber subscriber);
    void Notify(string eventType, object data = null);
}
