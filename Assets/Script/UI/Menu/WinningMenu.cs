using Assets.Script.Scenes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WinningMenu : MonoBehaviour
{
    [field: SerializeField]
    public GameObject WinningMenuObject { get; set; }

    [field: SerializeField]
    public Button NextLevelBtn { get; set; }

    [field: SerializeField]
    public Button RepeatBtn { get; set; }

    [field: SerializeField]
    public Button MenuBtn { get; set; }

    private void Start()
    {
        WinningMenuObject.SetActive(false);
    }

    public void LevelClear()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(RepeatBtn.gameObject);
    }

    public void NextLevel()
    {
        Loader loader = new Loader();
        loader.LoadNextLevel();
    }

    public void RepeatLevel()
    {
        Loader loader = new Loader();
        loader.LoadCurrentLevel();
    }
}
