using Assets.Script.Inventories;
using TMPro;
using UnityEngine;
using Zenject;

public class InventoryBehaviour : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _mSpinTextMeshPro = null;
    [SerializeField]
    private TMP_Text _mSpeedTextMeshPro = null;
    [SerializeField]
    private TMP_Text _mPowerTextMeshPro = null;

    //[Inject]
    //private IInventory _inventory = null;

    //void Start()
    //{
    //    _mSpinTextMeshPro.text = _inventory.SpinnoteList.Count.ToString();
    //    _mSpeedTextMeshPro.text = _inventory.SpeedupnoteList.Count.ToString();
    //    _mSpinTextMeshPro.text = _inventory.SpinnoteList.Count.ToString();
    //}

    //private void Update()
    //{
    //    _mSpinTextMeshPro.text = _inventory.SpinnoteList.Count.ToString();
    //    _mSpeedTextMeshPro.text = _inventory.SpeedupnoteList.Count.ToString();
    //    _mPowerTextMeshPro.text = _inventory.PowernoteList.Count.ToString();
    //}
}
