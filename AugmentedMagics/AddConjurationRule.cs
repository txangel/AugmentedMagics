﻿using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic;
using AugmentedMagics.Utilities;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics;

namespace AugmentedMagics
{    public class AddConjurationRule : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAbilityParams>, IRulebookHandler<RuleCalculateAbilityParams>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public void OnEventAboutToTrigger(RuleCalculateAbilityParams evt)
        {
            //Main.Log("AddConjurationRule Handler");
            if (!SpellTools.ValidateEventSpellSchool(evt, SpellSchool.Conjuration))
            {
                //Main.Log("AddConjurationRule Failed");
                return;
            }
            //Main.Log("AddConjurationRule Passed");
            evt.AddBonusDC(evt.Initiator.Stats.Constitution.Bonus + 3, Kingmaker.Enums.ModifierDescriptor.Feat);
            SpellTools.ConditionalAddMetamagic(evt, Metamagic.Selective);
            //Main.Log("AddConjurationRule End");
        }

        public void OnEventDidTrigger(RuleCalculateAbilityParams evt)
        {
        }
    }
}
