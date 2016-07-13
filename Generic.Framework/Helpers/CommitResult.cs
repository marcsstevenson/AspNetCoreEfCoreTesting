using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Generic.Framework.AbstractClasses;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers.ExceptionHanlding;
using Generic.Framework.Interfaces.Entity;

namespace Generic.Framework.Helpers
{
    public class CommitResult : GenericResult
    {
        public CommitResult()
            : base()
        {
            this.CommitActions = new Dictionary<IEntity, CommitAction>();
            this.Data = new Dictionary<string, object>();
        }

        public CommitResult(Exception e)
            : this()
        {
            this.Error = e;
        }

        public CommitResult(IEntity entity, CommitAction commitAction)
            : this()
        {
            this.CommitActions.Add(entity, commitAction);
        }
        
        public bool Success => !this.HasError;
        public bool NotFound { get; private set; }

        public new bool HasError { get { return this.Error != null || (this.CommitActions != null && this.CommitActions.Any(i => i.Value == CommitAction.Error)); } }

        public Dictionary<string, object> Data { get; set; }

        [XmlIgnore]
        [ScriptIgnore]
        public Dictionary<IEntity, CommitAction> CommitActions { get; set; }

        public Dictionary<T, CommitAction> GetCommitActionsForType<T>()
            where T : IEntity
        {
            var tpyeFiltered = this.CommitActions.Where(i => i.Key.GetType() == typeof(T))
                .Select(i => new KeyValuePair<T, CommitAction>((T)i.Key, i.Value)).ToList();
            return tpyeFiltered.ToDictionary(keyValuePair => keyValuePair.Key, keyValuePair => keyValuePair.Value);
        }

        public bool HasKeyForType<T>() where T : IEntity
        {
            return this.GetCommitActionsForType<T>().Any();
        }
        public T GetFirstKeyForType<T>()
            where T : IEntity
        {
            return this.GetCommitActionsForType<T>().First().Key;
        }
        
        public void Merge(CommitResult commitResult2)
        {
            foreach (var commitAction in commitResult2.CommitActions)
                this.CommitActions.Add(commitAction.Key, commitAction.Value);
        }

        public override string ToString()
        {
            return this.Success ? this.Success.ToString() : this.Error.ToString();
        }
    }
}
