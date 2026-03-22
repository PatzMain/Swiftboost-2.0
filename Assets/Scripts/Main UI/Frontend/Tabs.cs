using UnityEngine;
using UnityEngine.UI;

public class Tabs : MonoBehaviour
{
    [Header("Navigation Toggles")]
    [SerializeField] private Toggle[] navToggles; // assign your 3 toggles

    [Header("Tab Content")]
    [SerializeField] private GameObject[] tabContents; // assign your 3 content GameObjects

    private void Start()
    {
        // Wire up each toggle to its corresponding tab
        for (int i = 0; i < navToggles.Length; i++)
        {
            int index = i; // capture for closure
            navToggles[i].onValueChanged.AddListener((isOn) =>
            {
                if (isOn) SwitchTab(index);
            });
        }

        // Activate the first tab by default
        SwitchTab(1);
    }

    private void SwitchTab(int index)
    {
        for (int i = 0; i < tabContents.Length; i++)
        {
            bool isActive = i == index;
            tabContents[i].SetActive(isActive);

            if (isActive)
            {
                // Reset scroll position to top-left
                ScrollRect scroll = tabContents[i].GetComponentInChildren<ScrollRect>();
                if (scroll != null)
                    scroll.verticalNormalizedPosition = 1f;
            }
        }
    }
}