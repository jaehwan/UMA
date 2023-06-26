using System.Collections;
using System.Collections.Generic;
using UMA;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;

public class RecipeLoader : MonoBehaviour
{
    public GameObject avatars;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        // Preload all the races.
        List<string> labels = new List<string>();
        labels.Add("UMA_Recipes");

        var op = Addressables.LoadResourceLocationsAsync("UMA_Recipes");
        yield return op;
        if (op.Result != null )
        {
            Debug.Log("recipe location  " + op.Result.Count);

            foreach (IResourceLocation item in op.Result)
            {
                Debug.Log("resource key " + item.PrimaryKey + " Type : "+ item.ResourceType);
            }

            if (op.Result.Count > 0)
            {
                var recipeOp = UMAAssetIndexer.Instance.LoadLabelList(labels, false); // Load the recipes!
                recipeOp.Completed += Recipes_Loaded;
            }
            else
            {
                avatars.SetActive(true);
            }
        }
    }

    private void Recipes_Loaded(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<IList<Object>> obj)
    {
        Debug.Log("Recipes loaded: " + obj.Status.ToString());

        if (obj.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
        {
            foreach (Object item in obj.Result)
            {
                Debug.Log("add item " + item.name);
            }

            avatars.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
