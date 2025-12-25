using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    enum CharacterSpawneMode
    {
        MANUAL,
        AUTO,
    }

    [SerializeField]
    CharacterSpawneMode characterSpawneMode;

    [SerializeField]
    float spawneInterval=7;
    float currentSpawneTimer=0;

    [SerializeField]
    AffiliationType affiliation;
    [SerializeField]
    Transform spawnePoint;
    [SerializeField]
    CharacterBase spawneCharacter;

    public void Spawn()
    {
        if (spawnePoint == null)
        {
            return;
        }
        var character = Instantiate(spawneCharacter, spawnePoint.position, Quaternion.identity);
        character.Initialize(affiliation);
    }
    void Update()
    {
        currentSpawneTimer+= Time.deltaTime;
        if (characterSpawneMode == CharacterSpawneMode.AUTO&&currentSpawneTimer > spawneInterval)
        {
            Spawn();
            currentSpawneTimer=0;
        }
    }

}
