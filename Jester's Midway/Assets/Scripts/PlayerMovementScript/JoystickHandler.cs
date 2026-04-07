using UnityEngine;
using UnityEngine.EventSystems; 

public class JoystickHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public PlayerMovement player;
    public bool isLookStick = false; 
    public float range = 50f;
<<<<<<< HEAD
    public float sensitivity = 1f;

=======
>>>>>>> 1d0d5342be01540c560d61f82a74b4e023c074bd
    private Vector2 inputVector;
    private RectTransform stickTransform;

    void Start()
    {
        stickTransform = GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(stickTransform.parent as RectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / (stickTransform.parent as RectTransform).sizeDelta.x);
            pos.y = (pos.y / (stickTransform.parent as RectTransform).sizeDelta.y);

            inputVector = new Vector2(pos.x * 2, pos.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
            stickTransform.anchoredPosition = new Vector2(inputVector.x * range, inputVector.y * range);
            if (isLookStick)
                player.lookJoystickInput = inputVector * sensitivity;
            else
                player.moveJoystickInput = inputVector * sensitivity;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        stickTransform.anchoredPosition = Vector2.zero;
        if (isLookStick) player.lookJoystickInput = Vector2.zero;
        else player.moveJoystickInput = Vector2.zero;
    }
}