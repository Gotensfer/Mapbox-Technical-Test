using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePokemonFromRightClick : MonoBehaviour
{
    [SerializeField] Camera cam;

    [Tooltip("Esto debería ser 131072 (La LayerMask del RaycastPlane)")]
    [SerializeField] int layerid; // Algún día entenderé porque las capas que trae Mapbox son tan extrañas -Juanfer

    [SerializeField] GameObject[] pokemons;

    LayerMask layerMask; // Layer para el Raycast

    

    private void Start()
    {
        layerMask = layerid;
    }

    private void Update()
    {
        // Lanzar un RayCast a la posición del mouse cuando se presiona click derecho y crear un Pokemon
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Vector3 positionInMap = hit.point;
                CreatePokemon(positionInMap);
            }
        }
    }

    /// <summary>
    /// Crea un nuevo Pokemon en la escena
    /// </summary>
    /// <param name="position">El vector posición en donde se creará el Pokemon</param>
    void CreatePokemon(Vector3 position)
    {
        int index = Random.Range(0, pokemons.Length);
        Instantiate(pokemons[index], position, Quaternion.identity);
    }
}
