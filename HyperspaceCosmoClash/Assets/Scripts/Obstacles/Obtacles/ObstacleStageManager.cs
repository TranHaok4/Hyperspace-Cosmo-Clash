using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleStageManager : HaroMonoBehaviour
{
    [SerializeField] protected Camera mainCamera;
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
            if(obj.StageID==stageid)
            {
                obj.Obstaclesctrl.ObstaclesLazercontrol.TurnOnLazer();
            }
        }
    }
    public virtual void TurnOffObstacleStage(int stageid)
    {
        foreach (ObstacleLazerStageActiver obj in obstacleLazerS)
        {
            //Debug.Log(stageid + ":" + obj.StageID);
            if (obj.StageID == stageid)
            {
                StartCoroutine(MoveCameraAndTurnOffLazer(obj));
            }
        }
    }
    IEnumerator MoveCameraAndTurnOffLazer(ObstacleLazerStageActiver obj)
    {
        Vector3 originalCameraPosition = mainCamera.transform.position;
        Vector3 targetPosition=obj.transform.position;
        targetPosition=new Vector3(targetPosition.x,targetPosition.y,-10f);

        Time.timeScale = 0f;

        float timeElapsed = 0f;
        float duration = 2f; 

        while (timeElapsed < duration) {
            float t = timeElapsed / duration;
            mainCamera.transform.position = Vector3.Lerp(originalCameraPosition, targetPosition, t);
            timeElapsed += Time.unscaledDeltaTime; 
            yield return null;
        }

        obj.Obstaclesctrl.ObstaclesLazercontrol.TurnOffLazer(); 
        
        timeElapsed = 0;
        while (timeElapsed < duration) {
            float t = timeElapsed / duration;
            mainCamera.transform.position = Vector3.Lerp(targetPosition, originalCameraPosition, t);
            timeElapsed += Time.unscaledDeltaTime; 
            yield return null;
        }
        

        Time.timeScale = 1f; 
    }
}
