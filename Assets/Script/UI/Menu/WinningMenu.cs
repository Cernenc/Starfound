using UnityEngine;

public class WinningMenu : MonoBehaviour
{
    [field: SerializeField]
    public GameObject WinningMenuObject { get; set; }

    [field: SerializeField]
    public GameObject NextLevelBtn { get; set; }

    [field: SerializeField]
    public GameObject RepeatBtn { get; set; }

    [field: SerializeField]
    public GameObject MenuBtn { get; set; }

    private void Start()
    {
        WinningMenuObject.SetActive(false);
    }
}
