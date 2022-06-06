using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item3DViewer : MonoBehaviour, IDragHandler
{
    [SerializeField] private InventoryManager inventoryManager;
    
    [SerializeField] Transform viewPoint;
    GameObject currObject;

    private Transform itemPrefab;


    public void Start()
    {
        inventoryManager.OnItemSelected += InventoryManager_OnItemSelected;
    }

    public void InventoryManager_OnItemSelected(object sender, Item item)
    {
        Debug.Log("e");
        if (itemPrefab != null)
        {
            Destroy(itemPrefab.gameObject);
        }

        itemPrefab = Instantiate(item.prefab, new Vector3(1000, 1000, 1000), Quaternion.identity);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (currObject == null) return;
        currObject.transform.eulerAngles += new Vector3(-eventData.delta.y, -eventData.delta.x);

        float rotationXInput = Input.GetAxisRaw("Horizontal");
        float rotationYInput = Input.GetAxisRaw("Vertical");
    }
    public void SetViewItem(Item _item)
    {
        if (currObject != null) Destroy(currObject); currObject = null;
        currObject = Instantiate(_item.prefab.gameObject, viewPoint.position, _item.prefab.rotation);
    }
}
