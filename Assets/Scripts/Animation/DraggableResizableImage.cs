using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableResizableImage : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public MouseManager mouseManager;
    private Vector2 originalLocalPointerPosition;
    private Vector2 originalSizeDelta;
    private Vector2 originalScreenPosition;

    public void OnPointerDown(PointerEventData data)
    {
        if (mouseManager.rotation_on == false)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, data.position, data.pressEventCamera, out originalLocalPointerPosition);
            originalSizeDelta = (transform as RectTransform).sizeDelta;
            originalScreenPosition = data.position;
        }
    }

    public void OnDrag(PointerEventData data)
    {
        if (mouseManager.rotation_on == false)
        {
            if (data.button == PointerEventData.InputButton.Left)
            {
                Vector2 localPointerPosition;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, data.position, data.pressEventCamera, out localPointerPosition);
                Vector3 offsetToOriginal = localPointerPosition - originalLocalPointerPosition;
                (transform as RectTransform).anchoredPosition += new Vector2(offsetToOriginal.x, offsetToOriginal.y);
            }
            else if (data.button == PointerEventData.InputButton.Right)
            {
                Vector2 sizeDelta = originalSizeDelta + (data.position - originalScreenPosition);
                (transform as RectTransform).sizeDelta = sizeDelta;
            }
        }
    }
    public void OnEndDrag(PointerEventData data)
    {
        if (mouseManager.rotation_on == false)
        {
            Debug.Log("Drag Ended!");
            Debug.Log((transform as RectTransform).anchoredPosition);
            Debug.Log((transform as RectTransform).sizeDelta);
            // 여기에 드래그가 끝날 때 실행하고 싶은 코드를 작성하면 됩니다.
        }
    }
}
