using UnityEngine;
using System.Collections;

public class scrollviewtest: MonoBehaviour {

    private GameObject scrollview;
    private UIGrid grid;
    private UIButton addBtn, delBtn;
    private UILabel countLbl;
    void Start()
    {
        countLbl = GameObject.Find("countLbl").GetComponent<UILabel>();
        scrollview = GameObject.Find("Scroll View");
        grid = scrollview.GetComponentInChildren<UIGrid>();
        addBtn = GameObject.Find("AddButton").GetComponent<UIButton>();
        delBtn = GameObject.Find("DelButton").GetComponent<UIButton>();
        EventDelegate.Add(addBtn.onClick, AddItem);
        EventDelegate.Add(delBtn.onClick, DelAllItems);
    }

    void AddItem()
    {
        int count = grid.transform.childCount + 1;
        //克隆预设
        GameObject o = (GameObject)Instantiate(Resources.Load("Prefabs/Item 0"));  //预设物放在Resources目录下
        //将预设放在panel下面
        o.transform.parent = grid.transform;
        //这段代码很重要，创建预设的时候总是自动修改它的旋转系数，所以要重新赋值
        o.transform.localPosition = Vector3.zero;
        o.transform.localScale = new Vector3(1, 1, 1);
        //列表添加之后用于刷新
        grid.repositionNow = true;
        countLbl.text = "ItemsCount:" + count;
    }

    void DelAllItems()
    {
        foreach(Transform trans in grid.transform)
        {
            Destroy(trans.gameObject);
        }
        countLbl.text = "ItemsCount:0";
    }
}


//NGUI创建按钮
//NGUI->Open->Widget Wizard 字体到C://window/fonts下找