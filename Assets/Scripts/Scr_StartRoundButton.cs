using UnityEngine;

public class Scr_StartRoundButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClicked()
    {
        GameManager.Instance.ChangeGameState(GameState.ChoosingColorRound);
    }
}
