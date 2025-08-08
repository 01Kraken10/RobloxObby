using UnityEngine;

public class Block : MonoBehaviour
{
    public Panel RightPanel, LeftPanel;
    public Material DeadlyMat, SafeMat;
    private void Start()
    {
        bool isPanelDeadly = Random.value < 0.5f;
        RightPanel.Setup(DeadlyMat, SafeMat, isPanelDeadly);
        LeftPanel.Setup(DeadlyMat, SafeMat, !isPanelDeadly);
    }
}
