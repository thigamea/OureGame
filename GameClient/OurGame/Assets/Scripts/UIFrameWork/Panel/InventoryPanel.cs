using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : BasePanel {
    private CanvasGroup canvasGroup;

    private void Start()
    {
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
    }


    public override void OnEnter()
    {
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    public override void OnExit()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnReturnButtonClick()
    {
        UIManager.Instance.PopPanel();
    }
}
