using System;
using UnityEngine;

public class PlayerInterfaceController : MonoBehaviour, IDisposable
{
    [SerializeField] private Viewer _viewer;
    [SerializeField] private Vampirism _vampirism;

    private Presenter _presenter;
    private Model _model;

    private void Awake()
    {
        _model = new Model(_vampirism);

        _presenter = new Presenter(_model, _viewer);
    }

    public void Dispose()
    {
        _presenter?.Dispose();
        _model?.Dispose();
    }
}
