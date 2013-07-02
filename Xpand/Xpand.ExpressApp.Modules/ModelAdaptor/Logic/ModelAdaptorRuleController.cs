﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xpand.ExpressApp.Logic;
using Xpand.ExpressApp.Logic.Conditional.Logic;
using Xpand.ExpressApp.Model.Options;
using Xpand.ExpressApp.ModelAdaptor.Model;
using Xpand.Persistent.Base.Logic.Model;
using Xpand.Persistent.Base.ModelAdapter;

namespace Xpand.ExpressApp.ModelAdaptor.Logic {
    public class ModelAdaptorRuleController : ConditionalLogicRuleViewController<IModelAdaptorRule,ModelAdaptorModule> {
        readonly Dictionary<Type,List<IModelNodeEnabled>> _ruleTypeActiveModels = new Dictionary<Type, List<IModelNodeEnabled>>();

        public Dictionary<Type, List<IModelNodeEnabled>> RuleTypeActiveModels {
            get { return _ruleTypeActiveModels; }
        }

        public override void ExecuteRule(LogicRuleInfo<IModelAdaptorRule> info, ExecutionContext executionContext) {
            if (info.Active) {
                if (!_ruleTypeActiveModels.ContainsKey(info.Rule.RuleType))
                    _ruleTypeActiveModels.Add(info.Rule.RuleType, new List<IModelNodeEnabled>());
                List<IModelNodeEnabled> modelNodeEnableds = _ruleTypeActiveModels[info.Rule.RuleType];
                var modelAdaptorModule = Application.Modules.FindModule<ModelAdaptorModule>();
                IModelLogicRules modelLogicRules = modelAdaptorModule.GetModelLogic(Application.Model).Rules;
                IModelLogicRule modelLogicRule = modelLogicRules[info.Rule.Id];
                modelNodeEnableds.Add((IModelOptionsGridView) modelLogicRule);
            }            
        }

        public void ExecuteLogic<TModelAdaptorRule, TModelModelAdaptorRule>(Action<TModelModelAdaptorRule> action)
            where TModelAdaptorRule : IModelAdaptorRule
            where TModelModelAdaptorRule : IModelModelAdaptorRule {
            var type = typeof (TModelAdaptorRule);
            if (RuleTypeActiveModels.ContainsKey(type)) {
                var activeModels = RuleTypeActiveModels[type];
                foreach (var modelOptionsGridView in activeModels.ToList().OfType<TModelModelAdaptorRule>()) {
                    action.Invoke(modelOptionsGridView);
                    activeModels.Remove((IModelNodeEnabled) modelOptionsGridView);
                }
                RuleTypeActiveModels.Remove(type);
            }
        }
    }
}