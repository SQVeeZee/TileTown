using System;
using Gameplay.Tile;
using Gameplay.UI.Control;
using Zenject;

public class InteractionModel: IInitializable
{
    public event Action<TileController> ExistTileClicked;
    
    private readonly ControlController m_controlController = null;
    
    [Inject]
    public InteractionModel(
        ControlController controlController
    )
    {
        m_controlController = controlController;
    }

    public void Initialize()
    {
        
    }
}
