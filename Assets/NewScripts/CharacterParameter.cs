using UnityEngine;

[System.Serializable]
public class CharacterParameter
{
    [SerializeField]
    protected float speed;
    public float Speed=>speed;
    [SerializeField]
    protected int hp;
    public int HP=>hp;
    public void TakeDamage(int value)
    {
        this.hp-=value;
    }
    [SerializeField]
    protected int power;
    public int Power=>power;
}
