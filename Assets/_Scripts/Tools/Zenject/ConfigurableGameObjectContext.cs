using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zenject.Internal;

namespace Tools.Zenject
{
    public class ConfigurableGameObjectContext : GameObjectContext
    {
        [Header("CONFIGS")]
        [SerializeField]
        private bool _injectInChildrenMonoBehaviours = true;
        [SerializeField]
        private bool _injectInChildrenAnimators = true;


        protected override void GetInjectableMonoBehaviours(List<MonoBehaviour> monoBehaviours)
        {
            if (_injectInChildrenMonoBehaviours && _injectInChildrenAnimators)
            {
                base.GetInjectableMonoBehaviours(monoBehaviours);
                return;
            }
            
            if (_injectInChildrenAnimators)
            {
                ZenUtilInternal.AddStateMachineBehaviourAutoInjectersUnderGameObject(gameObject);
            }

            foreach (var monoBehaviour in GetComponents<MonoBehaviour>())
            {
                if (monoBehaviour == null)
                {
                    // Missing script
                    continue;
                }

                if (!ZenUtilInternal.IsInjectableMonoBehaviourType(monoBehaviour.GetType()))
                {
                    continue;
                }

                if (monoBehaviour == this)
                {
                    continue;
                }

                monoBehaviours.Add(monoBehaviour);
            }

            if (_injectInChildrenMonoBehaviours)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    var child = transform.GetChild(i);

                    if (child != null)
                    {
                        ZenUtilInternal.GetInjectableMonoBehavioursUnderGameObject(
                            child.gameObject, monoBehaviours);
                    }
                }
            }
        }
    }
}
