using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleStageManager : HaroMonoBehaviour
{
    [SerializeField] protected Transform mainCamera;
    private static ObstacleStageManager instance;
    public static ObstacleStageManager Instance { get => instance; }
    protected override void Awake()
    {
        if (ObstacleStageManager.instance != null) Debug.LogError("only 1 ObstacleStageManager");
        ObstacleStageManager.instance = this;
    }
    [SerializeField] protected List<ObstacleLazerStageActiver> obstacleLazerS;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObstacleLazerStageActiver();
    }

    protected virtual void LoadObstacleLazerStageActiver()
    {
        if (this.obstacleLazerS.Count > 0) return;
        foreach(Transform obj in transform)
        {
            ObstacleLazerStageActiver _obstacleLazerStageActiver = obj.gameObject.GetComponentInChildren<ObstacleLazerStageActiver>();
            if (_obstacleLazerStageActiver != null)
            {
                obstacleLazerS.Add(_obstacleLazerStageActiver);
            }
        }
        foreach(ObstacleLazerStageActiver obj in obstacleLazerS)
        {
            Debug.Log(obj.transform.parent.name);
            obj.Obstaclesctrl.ObstaclesLazercontrol.TurnOnLazer();
        }
        Debug.Log(transform.name + "LoadObstacleLazerStageActiver", gameObject);
    }
    public virtual void TurnOnObstacleStage(int stageid)
    {
        foreach (ObstacleLazerStageActiver obj in obstacleLazerS)
        {
            if(obj.StageData.StageID==stageid)
            {
                obj.Obstaclesctrl.ObstaclesLazercontrol.TurnOnLazer();
            }
        }
    }
    public virtual void TurnOffObstacleStage(int stageid)
    {
        List<ObstacleLazerStageActiver> objs = new List<ObstacleLazerStageActiver>();
        foreach (ObstacleLazerStageActiver obj in obstacleLazerS)
        {
            //Debug.Log(stageid + ":" + obj.StageID);
            if (obj.StageData.StageID == stageid)
            {
                objs.Add(obj);
            }
        }
        StartCoroutine(MoveCameraAndTurnOffLazer(objs));
    }
    IEnumerator MoveCameraAndTurnOffLazer(List<ObstacleLazerStageActiver> objs)
    {
        float timeElapsed = 0f;
        float duration = 2f; 
        Vector3 originalCameraPosition = mainCamera.transform.position;
        Vector3 targetPosition=new Vector3();
        Vector3 lastPosition = new Vector3(originalCameraPosition.x,originalCameraPosition.y,-10f);
        for(int i=0;i<objs.Count;i++)
        {
            targetPosition=objs[i].transform.position;
            targetPosition=new Vector3(targetPosition.x,targetPosition.y,-10f);
            Time.timeScale = 0f;
            while (timeElapsed < duration) {
                float t = timeElapsed / duration;
                mainCamera.transform.position = Vector3.Lerp(lastPosition, targetPosition, t);
                timeElapsed += Time.unscaledDeltaTime; 
                yield return null;
            }
            timeElapsed=0;
            lastPosition=new Vector3(targetPosition.x,targetPosition.y,-10f);
            objs[i].Obstaclesctrl.ObstaclesLazercontrol.TurnOffLazer(); 
        }
        
        timeElapsed = 0;
        while (timeElapsed < duration) {
            float t = timeElapsed / duration;
            mainCamera.transform.position = Vector3.Lerp(lastPosition, originalCameraPosition, t);
            timeElapsed += Time.unscaledDeltaTime; 
            yield return null;
        }
        

        Time.timeScale = 1f; 
    }
}
