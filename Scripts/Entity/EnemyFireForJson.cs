
using UnityEngine;

public class EnemyFireForJson
{
    private string type; //Pong AirPlane AirPlaneTail
    private string position; //位置
    private float airPlaneTailTime; //AirPlaneTail 的持续时间(长度)



    public EnemyFireForJson(string type, string position, float airPlaneTailTime)
    {
        this.Type = type;
        this.Position = position;
        this.AirPlaneTailTime = airPlaneTailTime;
    }

    public EnemyFireForJson(EnemyFire enemyFire)
    {
        this.Type = enemyFire.Type;
        this.Position = enemyFire.Position.ToString();
        this.AirPlaneTailTime = enemyFire.AirPlaneTailTime;
    }

    public EnemyFireForJson(string type, Vector3 position, float airPlaneTailTime)
    {
        this.Type = type;
        this.Position = position.ToString();
        this.AirPlaneTailTime = airPlaneTailTime;
    }

    public string Type { get => type; set => type = value; }
    public string Position { get => position; set => position = value; }
    public float AirPlaneTailTime { get => airPlaneTailTime; set => airPlaneTailTime = value; }
}
