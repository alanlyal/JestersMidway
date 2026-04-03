using UnityEngine;
using UnityEngine.EventSystems; // Required for touch events

public class JoystickHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public PlayerMovement player;
    public bool isLookStick = false; // Check this for the Right Stick
    public float range = 50f;

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
            // Calculate stick offset
            pos.x = (pos.x / (stickTransform.parent as RectTransform).sizeDelta.x);
            pos.y = (pos.y / (stickTransform.parent as RectTransform).sizeDelta.y);

            inputVector = new Vector2(pos.x * 2, pos.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            // Move the visual stick UI
            stickTransform.anchoredPosition = new Vector2(inputVector.x * range, inputVector.y * range);

            // Send data to PlayerMovement
            if (isLookStick)
                player.lookJoystickInput = inputVector;
            else
                player.moveJoystickInput = inputVector;
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