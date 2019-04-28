﻿using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.DC;
using Xpand.Persistent.Base.General;
using Xpand.Persistent.Base.General.Model;
using Xpand.XAF.Modules.CloneModelView;

namespace FeatureCenter.Module.ViewVariants {
    public class AttributeRegistrator : Xpand.Persistent.Base.General.AttributeRegistrator {
        public override IEnumerable<Attribute> GetAttributes(ITypeInfo typesInfo) {
            if (typesInfo.Type != typeof(Customer)) yield break;
            var list = new List<string> { "ViewVariants_ListView", "Hong Kong Customers", "London Customers", "Paris Customers", "New York Customers" };
            foreach (string t in list) {
                yield return new DisplayFeatureModelAttribute(t, "ViewVariants");
            }
            yield return new CloneModelViewAttribute(CloneViewType.ListView, "ViewVariants_ListView");
            yield return new XpandNavigationItemAttribute("View Variants", "ViewVariants_ListView");
            yield return new DisplayFeatureModelAttribute("ViewVariants_ListView", "ViewVariants");
        }
    }
}
