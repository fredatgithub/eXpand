﻿using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.DC;
using Xpand.Persistent.Base.AdditionalViewControls;
using Xpand.Persistent.Base.General;
using Xpand.Persistent.Base.General.Model;
using Xpand.XAF.Modules.CloneModelView;

namespace FeatureCenter.Module.Win.Wizard {
    public class AttributeRegistrator : Xpand.Persistent.Base.General.AttributeRegistrator {
        public static readonly string WizardCustomerDetailView = "WizardCustomer_DetailView";

        public override IEnumerable<Attribute> GetAttributes(ITypeInfo typesInfo) {
#if EASYTEST
            yield break;
#endif

            if (typesInfo.Type != typeof(WizardCustomer)) yield break;
            yield return new AdditionalViewControlsRuleAttribute(Module.Captions.Header + " " + Captions.HeaderWizard, "1=1", "1=1", Captions.HeaderWizard, Position.Top) { View = WizardCustomerDetailView + 1 };
            yield return new AdditionalViewControlsRuleAttribute(Module.Captions.ViewMessage + " " + Captions.HeaderWizard, "1=1", "1=1",
                Captions.ViewMessageWizard, Position.Bottom) { View = WizardCustomerDetailView + 1 };
            yield return new CloneModelViewAttribute(CloneViewType.DetailView, WizardCustomerDetailView + 1);
            yield return new CloneModelViewAttribute(CloneViewType.DetailView, WizardCustomerDetailView + 2);
            var navigationItemAttribute = new XpandNavigationItemAttribute(Module.Captions.DetailViewCotrol + "Wizard", WizardCustomerDetailView);
            yield return navigationItemAttribute;
            yield return new WhatsNewAttribute(new DateTime(2012,3,16), navigationItemAttribute);
            yield return new DisplayFeatureModelAttribute(WizardCustomerDetailView);
        }
    }
}
