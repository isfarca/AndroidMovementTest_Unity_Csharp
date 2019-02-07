using UnityEngine;

public class MovementSelectionCanvas : MonoBehaviour 
{
    // Declare variables.
    [SerializeField] private GameObject _virtualStickGameObject;
    [SerializeField] private GameObject _controlPadGameObject;
    [SerializeField] private GameObject _swipeGameObject;
    [SerializeField] private Canvas _actionCanvas;
    [SerializeField] private Animator _movementOneButtonAnimator;
    [SerializeField] private Animator _movementTwoButtonAnimator;
    [SerializeField] private Animator _movementThreeButtonAnimator;
    
    /// <summary>
    /// Callig before start.
    /// </summary>
    private void Awake()
    {
        // Set the default movement, when the player don't setting movement before.
        if (MovementSelectId < 1 || MovementSelectId > 3)
            MovementSelectId = 1;
        
        // Select the movement.
        switch (MovementSelectId)
        {
            case 1:
                ClickMovementOneButton();
                break;
            case 2:
                ClickMovementTwoButton();
                break;
            case 3:
                 ClickMovementThreeButton();
                break;
            default:
                return;
        }
    }

    /// <summary>
    /// Calling by clicking.
    /// </summary>
    public void ClickMovementOneButton()
    {
        MovementSelectId = 1;
        
        // Activate virtual stick movement.
        _virtualStickGameObject.SetActive(true);
        _controlPadGameObject.SetActive(false);
        _swipeGameObject.SetActive(false);
        _actionCanvas.gameObject.SetActive(true);
        
        PlayButtonAnimation(_movementOneButtonAnimator, _movementTwoButtonAnimator, _movementThreeButtonAnimator);
    }
    
    /// <summary>
    /// Calling by clicking.
    /// </summary>
    public void ClickMovementTwoButton()
    {
        MovementSelectId = 2;
        
        // Activate control pad movement.
        _virtualStickGameObject.SetActive(false);
        _controlPadGameObject.SetActive(true);
        _swipeGameObject.SetActive(false);
        _actionCanvas.gameObject.SetActive(true);
        
        PlayButtonAnimation(_movementTwoButtonAnimator, _movementOneButtonAnimator, _movementThreeButtonAnimator);
    }
    
    /// <summary>
    /// Calling by clicking.
    /// </summary>
    public void ClickMovementThreeButton()
    {
        MovementSelectId = 3;
        
        // Activate swipe movement.
        _virtualStickGameObject.SetActive(false);
        _controlPadGameObject.SetActive(false);
        _swipeGameObject.SetActive(true);
        _actionCanvas.gameObject.SetActive(false);
        
        PlayButtonAnimation(_movementThreeButtonAnimator, _movementOneButtonAnimator, _movementTwoButtonAnimator);
    }
    
    /// <summary>
    /// Buttons go forward or backward animation.
    /// </summary>
    private static void PlayButtonAnimation(Animator goForward, Animator goForBackward0, Animator goForBackward1)
    {
        // Button go forward.
        goForward.SetBool("GoForward", true);
        
        // Buttons go backward.
        if (goForBackward0.GetBool("GoForward"))
            goForBackward0.SetBool("GoForward", false);
        else if (goForBackward1.GetBool("GoForward"))
            goForBackward1.SetBool("GoForward", false);
    }
    
    // Auto-properties.
    public int MovementSelectId { get; private set; }
}