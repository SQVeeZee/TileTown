using System;
using Gameplay.Map;
using Gameplay.Tile;
using Zenject;

public class InteractionViewModel: IInitializable, IDisposable
{
    public event Action<TileController> EmptyTileClicked = null;
    public event Action<TileController> FilledTileClicked = null;

    private readonly MapGenerationSystem m_mapGenerationSystem = null;
    
    [Inject]
    public InteractionViewModel(
        MapGenerationSystem mapGenerationSystem
        )
    {
        m_mapGenerationSystem = mapGenerationSystem;
    }

    private void OnClicked()
    {
        
    }
    
    public void TileClicked(TileController tileController)
    {
        
    }

    void IInitializable.Initialize()
    {
    }

    void IDisposable.Dispose()
    {
    }
}
