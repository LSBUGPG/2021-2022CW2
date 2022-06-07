using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_KeyHolder : MonoBehaviour
{
    [SerializeField] private KeyHolder keyHolder;

    private Transform container;
    private Transform keyTemplate;

    private void Awake()
    {
        container = transform.Find("Container");
        keyTemplate = container.Find("KeyTemplate");
        keyTemplate.gameObject.SetActive(false);
    }


    void Start()
    {
        keyHolder.OnKeysChanged += KeyHolder_OnKeysChanged;
    }

    void KeyHolder_OnKeysChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    void UpdateVisual()
    {
        foreach (Transform child in container) {
            if (child == keyTemplate) continue;
            Destroy(child.gameObject);
        }
        List<Key.KeyType> keyList = keyHolder.GetKeyList();
        container.GetComponent<RectTransform>().anchoredPosition = new Vector2(-(keyList.Count - 1) * 80 / 2f, -220);
        for (int i = 0; i < keyList.Count; i++)
        {
            Key.KeyType keyType = keyList[i];
            Transform keyTransform = Instantiate(keyTemplate, container);
            keyTransform.gameObject.SetActive(true);
            keyTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(80 * i, 0);
            Image keyImage = keyTransform.Find("Image").GetComponent<Image>();
            switch (keyType)
            {
                default:
                case Key.KeyType.Red: keyImage.color = Color.red; break;
                case Key.KeyType.Green: keyImage.color = Color.green; break;
                case Key.KeyType.Blue: keyImage.color = Color.blue; break;
                case Key.KeyType.Yellow: keyImage.color = Color.yellow; break;
            }
        } 
     }
}
