using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CreateColorfullPanel : MonoBehaviour
{
    int num;
    // Start is called before the first frame update
    void Start()
    {
        num = 20;

        Vector2 sz = new Vector2(100, 100);

        this.GetComponent<RectTransform>().offsetMin = new Vector2(this.GetComponent<RectTransform>().offsetMin.x,
            this.GetComponent<RectTransform>().offsetMin.y + 320 - 130 * (num / 3));

        float height = this.GetComponent<RectTransform>().sizeDelta.y;
        float width = this.GetComponent<RectTransform>().sizeDelta.x;

        for (int i = 0; i < num; ++i)
        {
            Vector3 pos = new Vector3(this.transform.position.x - width/3 + width / 3 * (i % 3), this.transform.position.y + height/2 - 80 - width / 3 * (i / 3), this.transform.position.z);

            CreateButton(this.transform, pos, sz, i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateButton(Transform panel, Vector3 position, Vector2 sz, int i)
    {
        GameObject button = new GameObject();
        button.transform.parent = panel;

        button.AddComponent<RectTransform>();
        button.AddComponent<Button>();
        button.AddComponent<ColorChange>();
        button.AddComponent<Image>();

        button.transform.position = position;

        button.GetComponent<RectTransform>().sizeDelta = sz;
        button.GetComponent<Image>().color = Color.HSVToRGB((i * 1f / num), 1f, 1f);

        ColorChange myScriptInstance = FindObjectOfType<ColorChange>();
        myScriptInstance.body = GameObject.Find("Mesh1");

        UnityAction<int> action = new UnityAction<int>(myScriptInstance.ChangeOnClick);
        button.GetComponent<Button>().onClick.AddListener(() => action(1));
        //UnityEventTools.AddIntPersistentListener(button.GetComponent<Button>().onClick, action, 1);

    }
}
