using System.Collections.Generic;
using Entitas;
using Game.Component;
using Game.Enums;
using NotImplementedException = System.NotImplementedException;

namespace Game.System.Input
{
    /// <summary>
    /// entitas相应系统的基类
    /// </summary>
    public abstract class InputButtonSystemBase : ReactiveSystem<InputEntity>
    {
        protected Contexts contexts;

        public InputButtonSystemBase(Contexts context) : base(context.input)
        {
            this.contexts = context;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.GameComponentInputButton);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasGameComponentInputButton && filterCondition(entity);
        }

        /// <summary>
        /// 事件执行的筛选条件
        /// </summary>
        /// <returns></returns>
        protected abstract bool filterCondition(InputEntity entity);
    }
}