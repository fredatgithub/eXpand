using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;

namespace Xpand.ExpressApp.FilterDataStore.Web {
    public class Updater : ModuleUpdater {
        public Updater(ObjectSpace objectSpace, Version currentDBVersion)
            : base(objectSpace, currentDBVersion) {
        }
    }
}