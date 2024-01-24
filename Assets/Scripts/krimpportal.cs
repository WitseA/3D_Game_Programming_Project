using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class krimpportal : MonoBehaviour
{
    public Transform portal1;  // Het eerste portaal
    public Transform portal2;  // Het tweede portaal
    public float afstandVanPortaal = 1f;  // De afstand van het spawningspunt ten opzichte van het portaal
    public float krimpFactor = 0.5f;  // De factor waarmee de speler wordt verkleind

    private bool isTerugDoorPortaalGegaan = false;  // Geeft aan of de speler teruggaat door een portaal

    private void OnTriggerEnter(Collider other)
    {
        // Controleer of het object dat de trigger raakt de speler is
        if (other.CompareTag("Player"))
        {
            // Krimp de speler als de krimpfactor niet 0 is
            if (krimpFactor != 0f)
            {
                if (isTerugDoorPortaalGegaan)
                {
                    // Vergroot de speler als deze teruggaat door een portaal
                    VergrootSpeler(other.transform);
                }
                else
                {
                    // Verklein de speler als deze voor het eerst door een portaal gaat
                    KrimpSpeler(other.transform);
                }
            }

            // Verplaats de speler naar het andere portaal
            if (isTerugDoorPortaalGegaan)
            {
                Teleporteer(other.transform, portal1);
            }
            else
            {
                Teleporteer(other.transform, portal2);
                isTerugDoorPortaalGegaan = true; // Markeer dat de speler teruggaat door een portaal
            }
        }
    }

    private void KrimpSpeler(Transform target)
    {
        // Verklein de speler
        target.localScale *= krimpFactor;
    }

    private void VergrootSpeler(Transform target)
    {
        // Breng de speler terug naar de normale grootte
        target.localScale = Vector3.one;
    }

    private void Teleporteer(Transform target, Transform doelPortaal)
    {
        // Bereken de spawnpositie aan de andere kant van het portaal
        Vector3 spawnPos = doelPortaal.position + doelPortaal.TransformDirection(Vector3.up) * afstandVanPortaal;

        // Zet de Y-coördinaat van de spawnpositie op dezelfde hoogte als het portaal
        spawnPos.y = doelPortaal.position.y;

        // Zet de speler op de spawnpositie
        target.position = spawnPos;
    }

}
