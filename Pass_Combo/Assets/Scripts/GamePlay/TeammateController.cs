using UnityEngine;
using UnityEngine.EventSystems;

public class TeammateController : MonoBehaviour, ISubscriber, IPointerClickHandler
{
    private SpriteRenderer sr;
    private Vector3 originalScale;
    private Color defaultColor = new Color(1f, 0.76f, 0.03f); // Yellow
    private Color highlightColor = new Color(0.88f, 0.96f, 0.996f); // Light Cyan

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;
    }

    void Start()
    {
        GameManager.Instance.Subscribe(this);
    }

    void OnEnable()
    {
        //GameManager.Instance.Subscribe(this);
    }

    void OnDisable()
    {
        GameManager.Instance.Unsubscribe(this);
    }

    public void OnNotify(string eventType, object data = null)
    {
        if (eventType == "HIGHLIGHT_TEAMMATE")
        {
            GameObject target = data as GameObject;
            if (target == this.gameObject)
            {
                Highlight(true);
            }
            else
            {
                Highlight(false);
            }
        }

        if (eventType == "RESET_HIGHLIGHTS")
        {
            Highlight(false);
        }
    }

    private void Highlight(bool on)
    {
        if (on)
        {
            sr.color = highlightColor;
            transform.localScale = originalScale * 1.5f;
        }
        else
        {
            sr.color = defaultColor;
            transform.localScale = originalScale;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log($"{gameObject.name} clicked.");

        if(HighlightManager.currentHighlighted == this.gameObject)
        {
            Debug.Log("Correct Pass.");
            GameManager.Instance.PlayerPassed(this.gameObject);
        }
        else
        {
            Debug.Log("Not the highlighted teammate.");
            GameManager.Instance.Notify("MISS");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(HighlightManager.currentHighlighted == this.gameObject)
        {
            GameManager.Instance.PlayerPassed(this.gameObject);
        }

        else
        {
            GameManager.Instance.Notify("MISS");
        }
    }
}
