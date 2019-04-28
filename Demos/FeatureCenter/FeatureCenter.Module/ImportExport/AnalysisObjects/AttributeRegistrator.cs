﻿using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.DC;
using Xpand.Persistent.Base.General;
using Xpand.Persistent.Base.General.Model;
using Xpand.XAF.Modules.CloneModelView;

namespace FeatureCenter.Module.ImportExport.AnalysisObjects {
    public class AttributeRegistrator : Xpand.Persistent.Base.General.AttributeRegistrator {
        private const string ViewId = "IOAnalysis_ListView";
        public override IEnumerable<Attribute> GetAttributes(ITypeInfo typesInfo) {
            if (typesInfo.Type == typeof(DevExpress.Persistent.BaseImpl.Analysis)) {
                yield return new CloneModelViewAttribute(CloneViewType.ListView, ViewId);
                yield return new XpandNavigationItemAttribute(Captions.Importexport + "Analysis", ViewId);
                yield return new DisplayFeatureModelAttribute(ViewId, "Analysis");
            }

        }
    }
}
