using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AirplaneManager : MonoBehaviour
{
    [System.Serializable]
    public class Character
    {
        public string name;
    }

    [SerializeField] private Character[] _characters;
    [SerializeField] private Button[] _airplaneButtons;
    [SerializeField] private GameObject _demonstration;
    [SerializeField] private Material[] _allMaterials;

    private int _selectedIndex;

    private void Start()
    {
        _selectedIndex = PlayerPrefs.GetInt("selectedAirplaneIndex", 0);
        UpdateDemonstration(_selectedIndex);

        for (int i = 0; i < _characters.Length; i++)
        {
            int index = i;
            var button = _airplaneButtons[index];

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => SelectAirplane(index));
        }

        UpdateButtonStates();
    }

    private void SelectAirplane(int index)
    {
        _selectedIndex = index;
        PlayerPrefs.SetInt("selectedAirplaneIndex", index);
        UpdateDemonstration(index);
        UpdateButtonStates();
    }

    private void UpdateDemonstration(int index)
    {
        _demonstration.GetComponent<SkinnedMeshRenderer>().material = _allMaterials[index];
    }

    private void UpdateButtonStates()
    {
        for (int i = 0; i < _airplaneButtons.Length; i++)
        {
            var text = _airplaneButtons[i].GetComponentInChildren<TMP_Text>();
            text.text = (i == _selectedIndex) ? "Selected" : "Select";
        }
    }
}