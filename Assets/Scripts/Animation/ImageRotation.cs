using UnityEngine;
using UnityEngine.EventSystems;

public class ImageRotation : MonoBehaviour, IDragHandler
{
    public MouseManager mouseManager;
    public float rotationSpeed = 5f;

    private Vector3 startPoint;

    public void OnDrag(PointerEventData eventData)
    {
        if(mouseManager.rotation_on == true)
        {
            Vector3 currentPoint = Input.mousePosition;
            Vector3 delta = currentPoint - startPoint;

            float rotationAmount = delta.x * rotationSpeed;
            Vector3 rotation = new Vector3(0f, 0f, rotationAmount);
            transform.Rotate(rotation, Space.World);

            startPoint = currentPoint;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (mouseManager.rotation_on == true)
        {
            startPoint = Input.mousePosition;
        }
    }
}
