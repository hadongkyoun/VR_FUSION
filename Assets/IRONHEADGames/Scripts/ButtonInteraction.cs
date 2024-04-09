using System;
using UnityEngine;
using UnityEngine.Events;



[RequireComponent(typeof(BoxCollider))]
public class ButtonInteraction : MonoBehaviour, IInteractiveUI
{
   

    public UnityEvent OnClicked;

    [SerializeField] private Material mainMaterial;
    [SerializeField] private Material highlightedMaterial;

    private Renderer _renderer;

    private bool _isHighlighted = false;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material = mainMaterial;
    }

    public void HighlightUIObject()
    {
        if (!_isHighlighted)
        {
            _renderer.material = highlightedMaterial;
        }
        else
        {
            _renderer.material = mainMaterial;
        }
    }

    public UnityEvent GetUnityEvent()
    {
        return OnClicked;
    }


}
public interface IInteractiveUI
{

    public void HighlightUIObject();

    public UnityEvent GetUnityEvent();
}

