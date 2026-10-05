using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelExit : MonoBehaviour
{
    [SerializeField] private int requiredItemCount = 3;
    [SerializeField] private string nextSceneName;
    [SerializeField] private bool isFinalLevel = false;

    private CharacterController _characterController;

    private void Update()
    {
        if (_characterController != null)
        {
            if (InputManager.Instance.InteractPressed)
            {
                PassLevel();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterController characterItems = other.GetComponent<CharacterController>();

        if (characterItems != null)
        {
            _characterController = characterItems;
            ShowMessage();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CharacterController characterItems = other.GetComponent<CharacterController>();
        if (characterItems != null)
        {
            if (characterItems == _characterController)
            {
                _characterController = null;
                UIManager.Instance.HideItemPrompt();
            }
        }
    }

    private void ShowMessage()
    {
        if (_characterController.ItemCount >= requiredItemCount)
        {
            if (isFinalLevel)
            {
                UIManager.Instance.ShowItemPrompt("Press E - Finish Game");
            }
            else
            {
                UIManager.Instance.ShowItemPrompt("Press E - Go to Next Level");
            }
        }
        else
        {
            int needed = requiredItemCount - _characterController.ItemCount;

            if (needed > 1)
            {
                UIManager.Instance.ShowItemPrompt("Collect " + needed + " more items!");
            }
            else
            {
                UIManager.Instance.ShowItemPrompt("Collect " + needed + " more item!");
            }
        }
    }

    private void PassLevel()
    {
        if (_characterController.ItemCount < requiredItemCount)
        { 
            return; 
        }
        
        UIManager.Instance.HideItemPrompt();

        if (isFinalLevel)
        {
            UIManager.Instance.ShowVictory();
        }
        else
        {
            SoundManager.Instance.PlayLevelUpSFX();
            ButtonActions.Instance.GoToNextLevel(nextSceneName);
        }
    }
}
