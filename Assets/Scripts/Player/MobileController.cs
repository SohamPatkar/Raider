using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform handle;
    private Vector2 inputVector;
    private Vector2 handleVector;
    private Vector3 inputVector3;

    public float Horizontal => inputVector.x;
    public float Vertical => inputVector.y;

    void Start()
    {
        handleVector = transform.GetComponent<RectTransform>().position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        handle.position = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        handle.position = this.transform.position;
    }
}