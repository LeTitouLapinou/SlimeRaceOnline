using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI colorVoteTimerText;

    private void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnGameStateChangedEvent += HandleGameStateChanged; //Subscribe to the event of the GameManager OnGameStateChangedEvent
            GameManager.Instance.OnColorSelectionTimerChangedEvent += HandleColorSelectionTimerChanged;
        }
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnColorSelectionTimerChangedEvent -= HandleColorSelectionTimerChanged; //Unsubscribe to event when disabled
        }
    }

    private void HandleGameStateChanged(GameState newState)
    {
        Debug.Log("Game State Changed");
    }

    private void HandleColorSelectionTimerChanged(float newTime)
    {
        colorVoteTimerText.text = Mathf.CeilToInt(newTime).ToString(); //Convert float to ceil int
    }


}
