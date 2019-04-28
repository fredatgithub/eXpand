﻿using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.DC;
using Xpand.Persistent.Base.AdditionalViewControls;
using Xpand.Persistent.Base.General;
using Xpand.Persistent.Base.General.Model;
using Xpand.XAF.Modules.CloneModelView;

namespace FeatureCenter.Module.Win.ControllingXtraGrid.GuessAutoFilterRowValues {
    public class AttributeRegistrator : Xpand.Persistent.Base.General.AttributeRegistrator {
        public override IEnumerable<Attribute> GetAttributes(ITypeInfo typesInfo) {
            if (typesInfo.Type != typeof(WinCustomer)) yield break;
            yield return new AdditionalViewControlsRuleAttribute(Module.Captions.ViewMessage + " " + Captions.HeaderGuessAutoFilterRowValuesFromFilter, "1=1", "1=1",
                Captions.ViewMessageGuessAutoFilterRowValuesFromFilter, Position.Bottom) { View = "GuessAutoFilterRowValues_ListView" };
            yield return new AdditionalViewControlsRuleAttribute(Module.Captions.Header + " " + Captions.HeaderGuessAutoFilterRowValuesFromFilter, "1=1", "1=1",
                Captions.HeaderGuessAutoFilterRowValuesFromFilter, Position.Top) { View = "GuessAutoFilterRowValues_ListView" };
            yield return new CloneModelViewAttribute(CloneViewType.ListView, "GuessAutoFilterRowValues_ListView");
            yield return new XpandNavigationItemAttribute("Controlling XtraGrid/Guess Auto FilterRow Values", "GuessAutoFilterRowValues_ListView");
            yield return new DisplayFeatureModelAttribute("GuessAutoFilterRowValues_ListView");
        }
    }
}
