﻿using System;
using System.Collections.Generic;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using Xpand.Persistent.Base.AdditionalViewControls;
using Xpand.Persistent.Base.General;
using Xpand.Persistent.Base.General.Model;
using Xpand.XAF.Modules.CloneModelView;

namespace FeatureCenter.Module.AdditionalViewControls.ConditionalControlAndMessage {
    public class AttributeRegistrator : Xpand.Persistent.Base.General.AttributeRegistrator {
        public override IEnumerable<Attribute> GetAttributes(ITypeInfo typesInfo) {
            if (typesInfo.Type != typeof(Customer)) yield break;
            yield return new AdditionalViewControlsRuleAttribute(Captions.Header + " " + Captions.HeaderConditionalControlAndMessage, "1=1", "1=1",
        Captions.HeaderConditionalControlAndMessage, Position.Top) { View = "ConditionalControlAndMessage_ListView" };
            yield return new AdditionalViewControlsRuleAttribute(Captions.ConditionalAdditionalViewControlAndMessage, "Orders.Count>7", "1=1", null,
        Position.Bottom) { ViewType = ViewType.ListView, MessageProperty = "ConditionalControlAndMessage", View = "ConditionalControlAndMessage_ListView" };
            yield return new AdditionalViewControlsRuleAttribute(Captions.ViewMessage + " " + Captions.HeaderConditionalControlAndMessage, "1=1", "1=1",
        Captions.ViewMessageAdditionalViewControls, Position.Bottom) {
            ViewType = ViewType.ListView, View = "ConditionalControlAndMessage_ListView",
            ExecutionContextGroup = "ConditionalControlAndMessage"
        };
            yield return new CloneModelViewAttribute(CloneViewType.ListView, "ConditionalControlAndMessage_ListView");
            yield return new XpandNavigationItemAttribute("Additional View Controls/Conditional control with conditional Message", "ConditionalControlAndMessage_ListView");
            yield return new DisplayFeatureModelAttribute("ConditionalControlAndMessage_ListView");
        }
    }
}
