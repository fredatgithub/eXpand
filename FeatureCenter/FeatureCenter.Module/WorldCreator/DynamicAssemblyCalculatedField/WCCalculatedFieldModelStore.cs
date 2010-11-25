﻿using System.IO;
using Xpand.ExpressApp.ModelDifference.Core;

namespace FeatureCenter.Module.WorldCreator.DynamicAssemblyCalculatedField {
    public class WCCalculatedFieldModelStore : ModelApplicationFromStreamStoreBase {
        protected override Stream GetStream() {
            return GetType().Assembly.GetManifestResourceStream(GetType(), "WCCalculatedField.xafml");
        }
    }
}