using UnityEditor;

[CustomEditor(typeof(interactable),true)]
public class InteractableEditor : Editor
{
  public override void OnInspectorGUI()
  {
    interactable interactable = (interactable)target;
    base.OnInspectorGUI();
    if (interactable.useEvents)
    {
      if(interactable.GetComponent<interactionEvents>()==null)
          interactable.gameObject.AddComponent<interactionEvents>();
    }
    else
    {
      if (interactable.GetComponent<interactionEvents>()!=null)
                DestroyImmediate(interactable.GetComponent<interactionEvents>());
    }
  }
}
