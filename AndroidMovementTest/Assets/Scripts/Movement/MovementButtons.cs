using UnityEngine;
using UnityEngine.EventSystems;

public class MovementButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Declare variables.
    private Joystick _joystickScript;
    [SerializeField] private Direction _direction;
    private MovementLogic _movementLogicScript;
    
    /// <summary>
    /// Movement directions for player.
    /// </summary>
    private enum Direction
    {
        None,
        Right,
        Left
    }
    
    /// <summary>
    /// Calling before start.
    /// </summary>
    private void Awake()
    {
        // Get scripts and components.
        _joystickScript = GetComponent<Joystick>();
        _movementLogicScript = FindObjectOfType<MovementLogic>();
    }
    
    /// <summary>
    /// Calling per frame.
    /// </summary>
    private void Update()
    {
        // Set horizontal value for movement.
        if (_joystickScript != null && _joystickScript.Horizontal < 0.0f || _joystickScript != null && _joystickScript.Horizontal > 0.0f) // Virtual stick movement.
            _movementLogicScript.Horizontal = _joystickScript.Horizontal;
        else if (Input.GetAxis("Horizontal") < 0.0f || Input.GetAxis("Horizontal") > 0.0f) // Keyboard / Controller movement.
            _movementLogicScript.Horizontal = Input.GetAxis("Horizontal");
    }

    // Calling by clicking or touching.
    public void OnPointerDown(PointerEventData eventData) 
    {
        // Control pad movement.
        switch (_direction)
        {
            case Direction.None:
                return;
            case Direction.Right:
                _movementLogicScript.Horizontal = 1.0f;
                break;
            case Direction.Left:
                _movementLogicScript.Horizontal = -1.0f;
                break;
            default:
                return;
        }
    }
    
    // Calling after by clicking or touching.
    public void OnPointerUp(PointerEventData eventData)
    {
        // Control pad movement.
        _movementLogicScript.Horizontal = 0.0f;
    }
}