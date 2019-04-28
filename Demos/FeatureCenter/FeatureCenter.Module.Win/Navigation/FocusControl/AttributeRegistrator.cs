﻿using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.DC;
using Xpand.Persistent.Base.AdditionalViewControls;
using Xpand.Persistent.Base.General;
using Xpand.Persistent.Base.General.Model;
using Xpand.XAF.Modules.CloneModelView;

namespace FeatureCenter.Module.Win.Navigation.FocusControl {
    public class AttributeRegistrator : Xpand.Persistent.Base.General.AttributeRegistrator {
        public override IEnumerable<Attribute> GetAttributes(ITypeInfo typesInfo) {
            if (typesInfo.Type != typeof(WinCustomer)) yield break;
            yield return new AdditionalViewControlsRuleAttribute(Module.Captions.ViewMessage + " " + Captions.HeaderFocusControl, "1=1", "1=1",
                Captions.ViewMessageFocusControl, Position.Bottom) { View = "FocusControl_DetailView" };
            yield return new AdditionalViewControlsRuleAttribute(Module.Captions.Header + " " + Captions.HeaderFocusControl, "1=1", "1=1",
                Captions.HeaderFocusControl, Position.Top) { View = "FocusControl_DetailView" };
            yield return new CloneModelViewAttribute(CloneViewType.DetailView, "FocusControl_DetailView");
            yield return new XpandNavigationItemAttribute("Navigation/Focus Control", "FocusControl_DetailView");
            yield return new DisplayFeatureModelAttribute("FocusControl_DetailView");
        }
    }
}
