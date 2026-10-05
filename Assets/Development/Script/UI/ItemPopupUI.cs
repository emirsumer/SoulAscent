using System.Collections;
using TMPro;
using UnityEngine;

public class ItemPopupUI : MonoBehaviour
{
    [SerializeField] private GameObject popupPanel;
    [SerializeField] private TextMeshProUGUI popupText;
    [SerializeField] private float displayDuration = 1.5f;

    private Coroutine _activeRoutine;

    private void Start()
    {
        popupPanel.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        if (_activeRoutine != null)
        {
            StopCoroutine(_activeRoutine);
        }
        _activeRoutine = StartCoroutine(ShowMessageCoroutine(message));
    }

    private IEnumerator ShowMessageCoroutine(string message)
    {
        popupText.text = message;
        popupPanel.SetActive(true);
        yield return new WaitForSeconds(displayDuration);
        popupPanel.SetActive(false);
    }
}
