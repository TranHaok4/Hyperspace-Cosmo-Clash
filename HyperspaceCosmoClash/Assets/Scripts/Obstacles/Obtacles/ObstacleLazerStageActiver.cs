using UnityEngine;

public class ObstacleLazerStageActiver : HaroMonoBehaviour
{
    [SerializeField] protected ObstaclesCtrl obstaclesCtrl;
    public ObstaclesCtrl Obstaclesctrl { get => obstaclesCtrl; }
    [SerializeField] protected StageDataSO stageData;
    public StageDataSO StageData { get => stageData; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObstacleCtrl();
    }
    protected virtual void LoadObstacleCtrl()
    {
        if (this.obstaclesCtrl != null) return;
        this.obstaclesCtrl = transform.parent.GetComponent<ObstaclesCtrl>();
        Debug.Log(transform.name + "LoadObstacleCtrl", gameObject);
    }




}
