using UnityEngine;

public class Castle : CharacterBase
{
    void Start()
    {
        Initialize(affiliation);
    }
    protected override void Move()
    {
        //お城は移動しないので何も書かない処理でoverrideする
    }
    protected override void Attack(CharacterBase target)
    {
        //お城は攻撃しないので何も書かない処理でoverrideする
    }
}
