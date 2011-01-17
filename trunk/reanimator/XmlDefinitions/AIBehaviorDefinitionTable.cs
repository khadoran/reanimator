﻿namespace Reanimator.XmlDefinitions
{
    class AIBehaviorDefinitionTable : XmlDefinition
    {
        private new static readonly XmlCookElement[] Elements =
        {
            new XmlCookElement
            {
                Name = "pBehaviors",
                DefaultValue = 0,
                ElementType = ElementType.TableCount,
                ChildType = typeof(AIBehaviorDefinition)
            }
        };

        public AIBehaviorDefinitionTable()
        {
            RootElement = "AI_BEHAVIOR_DEFINITION_TABLE";
            base.Elements.AddRange(Elements);
        }
    }
}