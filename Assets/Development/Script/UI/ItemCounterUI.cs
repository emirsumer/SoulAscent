using TMPro;
using UnityEngine;

public class ItemCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemCountText;
    [SerializeField] private int requiredCount = 3;

    public void UpdateCount(int currentCount)
    {
        itemCountText.text = "Item: " + currentCount + "/" + requiredCount;
    }
}
