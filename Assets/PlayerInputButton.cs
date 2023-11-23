using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isButtonDown = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isButtonDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isButtonDown = false;
    }

    internal bool ButtonState()
    {
        return isButtonDown;
    }
}