using UnityEngine;

public sealed class DestroyAndInstantiateObjects : MonoBehaviour
{
    private GameObject _initObject;
    
    public void InitObject(GameObject targetObject) => _initObject = Instantiate(targetObject);

    public void DestroyObject()
    { 
        if(_initObject) Destroy(_initObject);
    }
}
