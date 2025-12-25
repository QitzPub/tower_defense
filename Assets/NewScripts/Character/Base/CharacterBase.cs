using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public abstract class CharacterBase : MonoBehaviour
{
    [SerializeField]
    CharacterParameter characterParameter;

    Vector2 MoveDirection=>affiliation == AffiliationType.SUPPORTER?Vector2.left:Vector2.right;
    [SerializeField]
    protected AffiliationType affiliation;

    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected Rigidbody2D rigidbody;
    //protected bool moving=true;
    protected CharacterBase target;
    [SerializeField]
    protected UnityEvent deathEvent;

    public void Initialize(AffiliationType affiliation)
    {
        //今回落下させないように重力の度合いを0にする
        this.rigidbody.gravityScale=0;
        this.affiliation = affiliation;
        this.gameObject.name=affiliation.ToString();

        if(affiliation == AffiliationType.SUPPORTER)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    protected virtual void Update()
    {
        if (target==null)
        {
            Move();
        }
        else
        {
            Attack(target);
        }

        if(characterParameter.HP <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        deathEvent.Invoke();
        Destroy(gameObject);
    }
    public virtual void TakeDamage(int value)
    {
        characterParameter.TakeDamage(value);
    }
    protected virtual void Attack(CharacterBase target)
    {        
        rigidbody.linearVelocity=Vector2.zero;
        target.TakeDamage(characterParameter.Power);
        animator?.Play("Attack");
    }
    
    protected virtual void Move()
    {
        rigidbody.linearVelocity=MoveDirection*characterParameter.Speed*Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        bool engaged = affiliation == AffiliationType.SUPPORTER
            ?collision.gameObject.name==AffiliationType.ENEMY.ToString()
            :collision.gameObject.name==AffiliationType.SUPPORTER.ToString();
        if (engaged)
        {
            this.target = collision.gameObject.GetComponent<CharacterBase>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        bool disEngaged = affiliation == AffiliationType.SUPPORTER
            ?collision.gameObject.name==AffiliationType.ENEMY.ToString()
            :collision.gameObject.name==AffiliationType.SUPPORTER.ToString();
        if (disEngaged)
        {
            this.target = null;
        }    
    }
}
