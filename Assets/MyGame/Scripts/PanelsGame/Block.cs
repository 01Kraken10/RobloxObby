using UnityEngine;

public class Block : MonoBehaviour // блок - это пара панелей
{
    public Panel RightPanel, LeftPanel;
    public Material DeadlyMat, SafeMat;
    private void Start()
    {
        bool isPanelDeadly = Random.value < 0.5f; // определяем какая панель опасна а какая - нет
        RightPanel.Setup(DeadlyMat, SafeMat, isPanelDeadly); // вводим параметры панелей
        LeftPanel.Setup(DeadlyMat, SafeMat, !isPanelDeadly);
    }
}
