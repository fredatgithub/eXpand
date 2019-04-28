﻿using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using Xpand.Persistent.Base.General;
using Xpand.Persistent.Base.General.Model;
using Xpand.XAF.Modules.CloneModelView;

namespace SystemTester.Module.Win.FunctionalTests.GridView {
    [XpandNavigationItem("GridView/Default","GridViewObject_ListView")]
    [CloneModelView(CloneViewType.ListView, "ImmediateRefresh_ListView")]
    [XpandNavigationItem("GridView/ImmediateRefresh", "ImmediateRefresh_ListView")]

    [XpandNavigationItem("GridView/Options","GridViewObjectOptions_ListView")]
    [CloneModelView(CloneViewType.ListView, "GridViewObjectOptions_ListView")]
    public class GridViewObject:BaseObject {
        public GridViewObject(Session session) : base(session){
        }

        [PersistentAlias("Number")]
        public int NumberAlias {
            get { return (int) EvaluateAlias("NumberAlias"); }
        }
        
        private int _number;
        public int Number{
            get { return _number; }
            set { SetPropertyValue("Number", ref _number, value); }
        }
    }
}
