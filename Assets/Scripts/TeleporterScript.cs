using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
    public Transform portal1;  // Het eerste portaal
    public Transform portal2;  // Het tweede portaal
    public float afstandVanPortaal = 1f;  // De afstand van het spawningspunt ten opzichte van het portaal

    private Transform vorigPortaal;  // Houdt bij welk portaal de speler het laatst heeft gebruikt

    private void OnTriggerEnter(Collider other)
    {
        // Controleer of het object dat de trigger raakt de speler is
        if (other.CompareTag("Player"))
        {
            // Verplaats de speler naar het andere portaal
            if (vorigPortaal == portal1)
            {
                Teleporteer(other.transform, portal2, true);
                vorigPortaal = portal2;
            }
            else
            {
                Teleporteer(other.transform, portal1, false);
                vorigPortaal = portal1;
            }
        }
    }

    private void Teleporteer(Transform target, Transform doelPortaal, bool spawnRechts)
    {
        // Bereken de spawnpositie aan de andere kant van het portaal
        Vector3 spawnPos = doelPortaal.position + (spawnRechts ? doelPortaal.right : -doelPortaal.right) * afstandVanPortaal;

        // Zet de Y-coördinaat van de spawnpositie op dezelfde hoogte als het portaal
        spawnPos.y = doelPortaal.position.y;

        // Zet de speler op de spawnpositie
        target.position = spawnPos;
    }
}
