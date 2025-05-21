using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AirplaneManager : MonoBehaviour
{
    [System.Serializable]
    public class Characters
    {
        public string name;
        public int unlockLevel;
    }

    public Characters[] _characters;
    public Button[] airplaneButtons;

    private int currentLevelIndex;

    void Start()
    {
        currentLevelIndex = PlayerPrefs.GetInt("levelIndex", 1000);

        int selectedAirplaneIndex = PlayerPrefs.GetInt("selectedAirplaneIndex", 0);

        for (int i = 0; i < _characters.Length; i++)
        {
            int index = i;
            Button button = airplaneButtons[index];

            if (currentLevelIndex >= _characters[index].unlockLevel)
            {
                button.GetComponentInChildren<TMP_Text>().text = "Select";
                button.onClick.AddListener(() => SelectAirplane(index));
                if (selectedAirplaneIndex == index)
                {
                    button.GetComponentInChildren<TMP_Text>().text = "Selected";
                }
            }
            else
            {
                button.GetComponentInChildren<TMP_Text>().text = "Unlocks at level " + _characters[index].unlockLevel;
                button.interactable = false;
            }
        }
    }

    void SelectAirplane(int index)
    {
        for (int i = 0; i < airplaneButtons.Length; i++)
        {
            airplaneButtons[i].GetComponentInChildren<TMP_Text>().text = currentLevelIndex >= _characters[i].unlockLevel ? "Select" : "Unlocks at level " + _characters[i].unlockLevel;
        }

        airplaneButtons[index].GetComponentInChildren<TMP_Text>().text = "Selected";
        PlayerPrefs.SetInt("selectedAirplaneIndex", index);
    }
}
