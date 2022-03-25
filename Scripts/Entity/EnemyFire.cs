using UnityEngine;

// ���˵Ĺ���

[System.Serializable]
public class EnemyFire 
{
    private string type; //Pong AirPlane AirPlaneTail
    private Vector3 position; //λ��
    private float airPlaneTailTime; //AirPlaneTail �ĳ���ʱ��(����)

    public EnemyFire()
    {

    }

    public EnemyFire(string type, Vector3 position, float airPlaneTailTime)
    {
        this.Type = type;
        this.Position = position;
        this.AirPlaneTailTime = airPlaneTailTime;
    }

    public EnemyFire(EnemyFireForJson enemyFireForJson)
    {
        this.Type = enemyFireForJson.Type;
        this.Position = TypeChange.StringToVector3(enemyFireForJson.Position);
        this.AirPlaneTailTime = enemyFireForJson.AirPlaneTailTime;
    }

    public EnemyFire(string type, string position, float airPlaneTailTime)
    {
        this.Type = type;
        this.Position = TypeChange.StringToVector3(position);
        this.AirPlaneTailTime = airPlaneTailTime;
    }

    public string Type { get => type; set => type = value; }
    public Vector3 Position { get => position; set => position = value; }
    public float AirPlaneTailTime { get => airPlaneTailTime; set => airPlaneTailTime = value; }

    public override string ToString()
    {
        return this.type + "," + this.position + "," + this.airPlaneTailTime;
    }
}
